using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Specialized;

namespace ControlAcceso
{
    public class ServiceLayer
    {

        public enum eMethod
        {
            mUnknown,
            mDotacion,
            mInformarLote,
            mLoginWeb
        }

        private string _user = Seguridad.user_name_login;
        private string _pass = Seguridad.user_pass;
        private string _pagi = "ctrlacc/service.aspx";
        private Config cnf = new Config(DataBase.getDefaultPathConfig());



        public static bool Check_For_Internet_Connection()
        {
            //try
            //{
            //    using (var client = new System.Net.WebClient())
            //    using (client.OpenRead("https://www.google.com/"))
            //    {
            //        return true;
            //    }
            //}
            //catch
            //{
            //    return false;
            //}

            //try
            //{
            //    string site = "https://www.google.com/";
            //    System.Net.Sockets.TcpClient client = new System.Net.Sockets.TcpClient(site, 80);
            //    client.Close();
            //    return true;
            //}
            //catch (Exception)
            //{
            //    return false;
            //}

            return System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
        }


        public static bool Has_Connection()
        {
            try
            {
                System.Net.IPHostEntry i = System.Net.Dns.GetHostEntry("www.google.com");
                return true;
            }
            catch
            {
                return false;
            }
        }


        public static bool Check_Conexion_Internet_con_Proxy()
        {
            try
            {
                var ping = new System.Net.NetworkInformation.Ping();
                var result = ping.Send("www.google.com");
                if (result.Status != System.Net.NetworkInformation.IPStatus.Success) return false;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool Check_Conexion_Internet()
        {
            if (ServiceLayer.Check_For_Internet_Connection()) return true;
            if (ServiceLayer.Has_Connection()) return true;
            System.Uri objUrl = new System.Uri("http://www.google.com/");
            System.Net.WebRequest objWebReq;
            objWebReq = System.Net.WebRequest.Create(objUrl);
            System.Net.WebResponse objResp;
            try
            {
                objResp = objWebReq.GetResponse();
                objResp.Close();
                objWebReq = null;
                return true;
            }
            catch
            {
                if (ServiceLayer.Check_Conexion_Internet_con_Proxy())
                {
                    return true;
                }
                objWebReq = null;
                return false;
            }
        }



        public ServiceResponse Call(eMethod method, string json)
        {
            var url = cnf.Read(Config.eKeys.URL_SIGIRH.ToString()) + _pagi;
            var bte_resp = Http.Post(url, new NameValueCollection() { { "user", _user }, { "pass", _pass }, { "metodo", method.ToString() }, { "json", json } });
            if (bte_resp == null) return null;
            var str_json = System.Text.Encoding.UTF8.GetString(bte_resp);
            return JsonConvert.DeserializeObject<ServiceResponse>(str_json);
        }

        public Dotacion Get_Dotacion()
        {
            var sr = Call(eMethod.mDotacion, string.Empty);
            if (sr._Status != ServiceResponse.eStatus.eResponseOK) throw new ServiceLayerException(sr._StatusDesc);
            return JsonConvert.DeserializeObject<Dotacion>(sr._Json);
        }

        public LoteResponse Informar_Lote(LoteControlAcceso lote)
        {
            var json = JsonConvert.SerializeObject(lote);
            var sr = this.Call(eMethod.mInformarLote, json);
            if (sr._Status != ServiceResponse.eStatus.eResponseOK) throw new ServiceLayerException(sr._StatusDesc);
            return JsonConvert.DeserializeObject<LoteResponse>(sr._Json);
        }

        public bool Login_Web(string user, string pass)
        {
            _user = user;
            _pass = pass;
            var sr = Call(eMethod.mLoginWeb, string.Empty);
            if (sr == null) return false;
            if (sr._Status != ServiceResponse.eStatus.eResponseOK)
            {
                if ( sr._Json.Length > 0 )
                    throw new ServiceLayerExceptionLogin(sr._Json);
                else
                    throw new ServiceLayerException(sr._StatusDesc);
            }
            return JsonConvert.DeserializeObject<bool>(sr._Json.ToLower());
        }

    }
}
