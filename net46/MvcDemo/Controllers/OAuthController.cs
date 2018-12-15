using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using LinqToTwitter;
using MvcDemo.Models;

namespace MvcDemo.Controllers
{
    public class OAuthController : AsyncController
    {

        public ActionResult Index()
        {
            return View();
        }

        [ActionName("Begin")]
        public async Task<ActionResult> BeginAsync()
        {
            //var auth = new MvcSignInAuthorizer
            var auth = new MvcAuthorizer
            {
                CredentialStore = new SessionStateCredentialStore
                {
                    ConsumerKey = ConfigurationManager.AppSettings["consumerKey"],
                    ConsumerSecret = ConfigurationManager.AppSettings["consumerSecret"]
                }
            };



            string twitterCallbackUrl = Request.Url.ToString().Replace("Begin", "Complete");
            return await auth.BeginAuthorizationAsync(new Uri(twitterCallbackUrl));


            //return await auth.BeginAuthorizationAsync(new Uri(ConfigurationManager.AppSettings["urlCallback"].ToString()));

        }

        [ActionName("Complete")]
        public async Task<ActionResult> CompleteAsync()
        {

            var auth = new MvcAuthorizer
            {
                CredentialStore = new SessionStateCredentialStore()
            };
            await auth.CompleteAuthorizeAsync(Request.Url);
            var authCredentials = auth.CredentialStore;

            // É assim que você acessa as credenciais após a autorização.
            // O oauthToken e oauthTokenSecret não expiram.
            // Você pode usar o userID para associar as credenciais ao usuário.
            // Você pode salvar credenciais da maneira que quiser - banco de dados,
            // armazenamento isolado, etc. - depende de você.
            // Você pode recuperar e carregar todas as 4 credenciais em subseqüentes
            // consultas para evitar a necessidade de autorizar novamente.
            // Quando você tiver carregado todas as 4 credenciais, o LINQ to Twitter permitirá
            // você fazer consultas sem re-autorizar.
            //================================================================================

            Credenciais credenciais = new Credenciais
            {
                ConsumerKey = authCredentials.ConsumerKey,
                ConsumerSecret = authCredentials.ConsumerSecret,
                OAuthToken = authCredentials.OAuthToken,
                OAuthTokenSecret = authCredentials.OAuthTokenSecret,
                ScreenName = authCredentials.ScreenName,
                UserID = authCredentials.UserID
            };

            // Carreegando propriedades static da class CredenciaisAuth
            // ========================================================
            CredenciaisAuth.ConsumerKey = authCredentials.ConsumerKey;
            CredenciaisAuth.ConsumerSecret = authCredentials.ConsumerSecret;
            CredenciaisAuth.OAuthToken = authCredentials.OAuthToken;
            CredenciaisAuth.OAuthTokenSecret = authCredentials.OAuthTokenSecret;
            CredenciaisAuth.ScreenName = authCredentials.ScreenName;
            CredenciaisAuth.UserID = authCredentials.UserID;

            // Carreegando propriedades num Cokie
            // ==================================
            //HttpCookie httpcookie = new HttpCookie("twitterdesk");
            //httpcookie.Value = credenciais.ToString();
            //httpcookie.Expires = DateTime.Now.AddMonths(1);
            //Response.Cookies.Add(httpcookie);

            return RedirectToAction("Index", "StatusDemos");
        }
    }
}