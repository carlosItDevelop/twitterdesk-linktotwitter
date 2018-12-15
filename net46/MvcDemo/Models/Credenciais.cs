
using System.Runtime.Serialization;

using LinqToTwitter;
using System;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace MvcDemo.Models
{
    //[Serializable]
    //public class Credenciais
    //{

    //    private const string CREDENCIAIS = "CRDENCIAIS";

    //    public static ICredentialStore CredencitialsToken {
    //        get
    //        {
    //            return (ICredentialStore)HttpContext.Current.Session[CREDENCIAIS];
    //        }
    //        set
    //        {
    //            HttpContext.Current.Session[CREDENCIAIS] = value;
    //        }
    //    }

    //}


    [Serializable]
    public class Credenciais : ICredentialStore
    {
        public string ConsumerKey { get; set; } = null;
        public string ConsumerSecret { get; set; } = null;
        public string OAuthToken { get; set; } = null;
        public string OAuthTokenSecret { get; set; } = null;
        public string ScreenName { get; set; } = null;
        public ulong UserID { get; set; } = 0;

        public Task ClearAsync()
        {
            throw new NotImplementedException();
        }

        public bool HasAllCredentials()
        {
            bool ok = true;
            if (ConsumerKey == null || ConsumerSecret == null || OAuthToken == null || OAuthTokenSecret == null || ScreenName == null || UserID == 0)
            {
                ok = false;
            }
            return ok;
        }

        public Task LoadAsync()
        {
            throw new NotImplementedException();
        }

        public Task StoreAsync()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            var jsonstring = JsonConvert.SerializeObject(this);
            return jsonstring;
        }

    }

    public class CredenciaisAuth
    {
        public static string ConsumerKey { get; set; } = null;
        public static string ConsumerSecret { get; set; } = null;
        public static string OAuthToken { get; set; } = null;
        public static string OAuthTokenSecret { get; set; } = null;
        public static string ScreenName { get; set; } = null;
        public static ulong UserID { get; set; } = 0;
    }

}