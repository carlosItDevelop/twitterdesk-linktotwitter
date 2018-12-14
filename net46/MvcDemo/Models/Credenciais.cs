using LinqToTwitter;
using System;
using System.Web;

namespace MvcDemo.Models
{
    [Serializable]
    public class Credenciais
    {

        private const string CREDENCIAIS = "";

        public static ICredentialStore CredencitialsToken {
            get
            {
                return (ICredentialStore)HttpContext.Current.Session[CREDENCIAIS];
            }
            set
            {
                HttpContext.Current.Session[CREDENCIAIS] = value;
            }
        }

    }
}