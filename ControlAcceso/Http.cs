using System;
using System.Collections.Specialized;
using System.Net;

namespace ControlAcceso
{
    public static class Http
    {
        public static byte[] Post(string uri, NameValueCollection pairs)
        {
            byte[] response;
            using (WebClient client = new WebClient())
            {
                try
                {
                    ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                    client.UseDefaultCredentials = true;
                    client.Proxy = WebRequest.GetSystemWebProxy();
                    client.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
                    response = client.UploadValues(uri, pairs);
                }
                catch
                {
                    response = null;
                }                
            }
            return response;
        }


        public static byte[] PostWithAthentication(string uri, NameValueCollection pairs, IWebProxy proxy)
        {
            byte[] response;
            using (WebClient client = new WebClient())
            {
                try
                {
                    ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                    client.UseDefaultCredentials = false;
                    client.Proxy = proxy;
                    response = client.UploadValues(uri, pairs);
                }
                catch
                {
                    response = null;
                }
            }
            return response;
        }


    }


}
