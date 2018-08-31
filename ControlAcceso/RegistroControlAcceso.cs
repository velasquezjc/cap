using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlAcceso
{
    public class RegistroControlAcceso
    {
        public static byte bteValorDefTipoAcceso = 0; 
        public int id;
        public int per_id;
        public DateTime fecha;
        public Boolean es_ingreso; // INGRESO = TRUE | EGRESO = FALSO
        public string usu;
        public int edif;
        public Boolean reg_x_doc;

        // private static string QueryExiste = "SELECT TOP 1 1 Existe FROM Cac WHERE pid = @Pid AND fec = '@Fec' AND ing = @Ing;";
        private static string QueryInsert = "INSERT INTO Cac (pid, fec, ing, inf, usr, edi, rdc) VALUES ( '@Pid', '@Fec', @Ing, FALSE, '@Usr', '@Edi', '@Rdc' );";
        private static string QueryUpdate = "UPDATE Cac SET inf = 1 WHERE Id = @Id;";
        private static string QueryUltFecha = "SELECT TOP 1 * FROM Cac ORDER BY id DESC;";
        // private static string QuerySelect = "SELECT TOP 1 * FROM Dot WHERE Doc = @Doc OR Tar = '@Tar';";
        // private static string QueryListAll = "SELECT * FROM Dot;";


        public bool Fecha_Actual_Es_Mayor_Ult_Fecha_Grabacion(ref DateTime ult_fecha_grabada ) 
        {
            try
            {
                var db = new DataBase();
                var cryp = new CCryptorEngine();
                var sConexion = db.GenerarConexionString(DataBase.getDefaultPathDB());
                var dt = db.ExecQuery(QueryUltFecha, sConexion);
                if (dt.Rows.Count < 1) return true; // No hay registros ingresados
                ult_fecha_grabada = DateTime.ParseExact(cryp.Desencriptar((string)dt.Rows[0]["fec"]),"yyyyMMdd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                return (ult_fecha_grabada.CompareTo(DateTime.Now) < 0);
            }
            catch
            {
                return false;
            }
        }


        public bool Insert(Persona per, bool es_ingreso, bool reg_x_doc)
        {
            try
            {
                var db = new DataBase();
                var cryp = new CCryptorEngine();
                var sConexion = db.GenerarConexionString(DataBase.getDefaultPathDB());
                var query = QueryInsert
                                .Replace("@Pid", cryp.Encriptar(per.id.ToString()))
                                .Replace("@Fec", cryp.Encriptar(DateTime.Now.ToString("yyyyMMdd HH:mm:ss")))
                                .Replace("@Ing", es_ingreso.ToString().ToUpper())
                                .Replace("@Usr", cryp.Encriptar(Seguridad.user_name_login))
                                .Replace("@Edi", cryp.Encriptar(Seguridad.edificio.id.ToString()))
                                .Replace("@Rdc", cryp.Encriptar(reg_x_doc.ToString()));
                db.ExecNonQuery(query, sConexion);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Marcar_Como_Informado()
        {
            try
            {
                var db = new DataBase();
                var sConexion = db.GenerarConexionString(DataBase.getDefaultPathDB());
                var query = QueryUpdate.Replace("@Id", this.id.ToString());
                db.ExecNonQuery(query, sConexion);
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
