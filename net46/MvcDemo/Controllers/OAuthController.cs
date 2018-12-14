using System;
using System.Configuration;
using System.Threading.Tasks;
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
                    //ScreenName = "desk_tw",
                    //UserID = "1068723410757435393"
                }
            };


            // SÓ USAR EM PRODUÇÃO, POIS ELE PEGA O ENDEREÇO LOCALHOST/BEGIN E DEPOIS COMPLETE (ACTIONS) DESTE CONTROLLER
            //string twitterCallbackUrl = Request.Url.ToString().Replace("Begin", "Complete");
            //return await auth.BeginAuthorizationAsync(new Uri(twitterCallbackUrl));

            // RODAR ESTA LINHA EM LOCALHOST E AS DUAS DECIMA REMOTAMENTE!
            return await auth.BeginAuthorizationAsync(new Uri(ConfigurationManager.AppSettings["urlCallback"].ToString()));

        }

        [ActionName("Complete")]
        public async Task<ActionResult> CompleteAsync()
        {
            //if(Credenciais.CredencitialsToken == null) {
                var auth = new MvcAuthorizer
                {
                    CredentialStore = new SessionStateCredentialStore()
                };
                await auth.CompleteAuthorizeAsync(Request.Url);

                //var credentials = auth.CredentialStore;
                //string oauthToken = credentials.OAuthToken;
                //string oauthTokenSecret = credentials.OAuthTokenSecret;
                //string screenName = credentials.ScreenName;
                //ulong userID = credentials.UserID;
            //}


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

            var credentials = auth.CredentialStore;
            string oauthToken = credentials.OAuthToken;
            string oauthTokenSecret = credentials.OAuthTokenSecret;
            string screenName = credentials.ScreenName;
            ulong userID = credentials.UserID;
            //================================================================================

            return RedirectToAction("Index", "StatusDemos");
        }
    }
}