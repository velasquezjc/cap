using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace ControlAcceso
{
    public static class Seguridad
    {
        public static string user_name_login { get; set; }
        public static string user_apellido { get; set; }
        public static string user_nombre { get; set; }
        public static string user_pass { get; set; }
        public static bool es_user_admin { get; set; }


        public static Edificio edificio { get; set; }

        private static string QueryVerificarExistenciaUsuario = "SELECT COUNT(Id) as login FROM usr WHERE name = '@name' AND pass = '@pass';";
        private static string QueryInsertarUsuario = "INSERT INTO usr ( name, pass ) VALUES ( '@name', '@pass' );";
        private static string QueryActualizarUsuario = "UPDATE usr SET pass = '@pass' WHERE name = '@name';";
        private static string QueryEliminarUsuario = "DELETE * FROM usr WHERE name = '@name';";


        public static bool Actualizar_Usuario_Validado(string user, string pass)
        {
            DataBase db = new DataBase();
            string sConexion = db.GenerarConexionString(DataBase.getDefaultPathConfig());
            string ConsultaSQL = QueryVerificarExistenciaUsuario;
            CCryptorEngine cryp = new CCryptorEngine();
            ConsultaSQL = ConsultaSQL.Replace("@name", cryp.Encriptar(user));
            ConsultaSQL = ConsultaSQL.Replace("@pass", cryp.EncodeMD5(pass));
            DataTable dt = db.ExecQuery(ConsultaSQL, sConexion);
            //Existe el usuario?
            if ((int)(dt.Rows[0]["login"]) < 1)
                // Agrego al usuario Logueado por Web
                ConsultaSQL = QueryInsertarUsuario;
            else
                // Actualizo la pass del usuario
                ConsultaSQL = QueryActualizarUsuario;
            ConsultaSQL = ConsultaSQL.Replace("@name", cryp.Encriptar(user));
            ConsultaSQL = ConsultaSQL.Replace("@pass", cryp.EncodeMD5(pass));
            return db.ExecNonQuery(ConsultaSQL, sConexion);
        }


        public static void Verificar_Permisos_Web()
        {
            var sl = new ServiceLayer();
            // Si hay error de autenticacion lanza el excepcion ServiceLayerExceptionLogin
            sl.Login_Web(user_name_login, user_pass);
        }

        public static void Eliminar_Usuario_Local()
        {
            DataBase db = new DataBase();
            string sConexion = db.GenerarConexionString(DataBase.getDefaultPathConfig());
            string ConsultaSQL = QueryEliminarUsuario;
            CCryptorEngine cryp = new CCryptorEngine();
            ConsultaSQL = ConsultaSQL.Replace("@name", cryp.Encriptar(user_name_login));
            db.ExecNonQuery(ConsultaSQL, sConexion);
        }




    }
}
