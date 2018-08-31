using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace ControlAcceso
{
    public class Config 
    {

        public enum eTipoExp { Access = 1, TXT = 2 };
        public enum eKeys { URL_SIGIRH };

        private string RutaConfig = string.Empty;



        public Config( string Ruta )
        {
            RutaConfig = Ruta;
        }

        public bool Save(string Key, string Value)
        {
            bool bolRet;
            try
            {
                DataBase db = new DataBase();
                DataTable dt = db.ExecQuery("SELECT value FROM cnf WHERE key = '@key';".Replace("@key", Key), db.GenerarConexionString(RutaConfig));
                if( dt == null || dt.Rows.Count < 1 )
                    db.ExecNonQuery("INSERT INTO cnf ([key], [value]) VALUES ( '@key', '@value' );".Replace("@key", Key).Replace("@value", Value), db.GenerarConexionString(RutaConfig));
                else
                    db.ExecNonQuery("UPDATE cnf SET [value] = '@value' WHERE [key] = '@key';".Replace("@key", Key).Replace("@value", Value), db.GenerarConexionString(RutaConfig));
                bolRet = true;
            }
            catch
            {
                bolRet = false;
            }
            return bolRet;
        }

        public string Read(string Key)
        {
            string strValue;
            try
            {
                DataBase db = new DataBase();
                DataTable dt = db.ExecQuery("SELECT value FROM cnf WHERE key = '@key';".Replace("@key", Key), db.GenerarConexionString(RutaConfig));
                strValue = dt.Rows[0][0].ToString();
            }
            catch
            {
                strValue = string.Empty;
            }
            return strValue;
        }

    }

}
