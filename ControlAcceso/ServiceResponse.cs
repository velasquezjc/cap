using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlAcceso
{
    public class ServiceResponse
    {
        private string JsonEncryp = string.Empty;
        public enum eStatus
        {
            eResponseOK = 0,
            eErrorUnknow = 1,
            eErrorParams = 2,
            eErrorAuthentication = 3,
            eErrorProcess = 4
        }

        public eStatus _Status = eStatus.eErrorUnknow;
        public string _StatusDesc = string.Empty;
        public string _Json 
        {
            get{
                var value = string.Empty;
                var cryp = new CCryptorEngine();
                try
                {
                    value = cryp.Desencriptar(JsonEncryp);
                    if (value.Length == 0) throw new Exception();
                }
                catch
                {
                    value = null;
                }
                return value;
            }
            set {
                JsonEncryp = value;
            }
        }

    }
}
