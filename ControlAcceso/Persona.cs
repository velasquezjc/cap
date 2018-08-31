using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace ControlAcceso
{
    public class Persona
    {
        public int id = 0;
        public string ape = string.Empty;
        public string nom = string.Empty;
        public int doc = 0;
        public string tar = string.Empty;

        private static string QueryExiste = "SELECT TOP 1 1 AS Existe FROM Dot WHERE Id = '@Id';";
        private static string QueryInsert = "INSERT INTO Dot VALUES ( '@Id', '@Ape', '@Nom', '@Doc', '@Tar' );";
        private static string QueryUpdate = "UPDATE Dot SET Ape = '@Ape', Nom = '@Nom', Doc = '@Doc', Tar = '@Tar' WHERE Id = '@Id';";



        public string Get_Full_Name() {
            if ( this.id > 0 )
                return this.ape.ToUpper() + ", " + this.nom;
            return string.Empty;
        }

        public bool Existe_Base_Local() 
        {
            try
            {
                var db = new DataBase();
                var cryp = new CCryptorEngine();
                var sConexion = db.GenerarConexionString(DataBase.getDefaultPathDB());
                var query = QueryExiste;
                query = query.Replace("@Id", cryp.Encriptar(this.id.ToString()));
                var dt = db.ExecQuery(query, sConexion);
                if (dt.Rows.Count > 0 && Convert.ToInt32(dt.Rows[0]["Existe"]) == 1)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }


        public bool Update_Base_Local_Masivo( DataBase db )
        {
            try
            {
                var cryp = new CCryptorEngine();
                var query = QueryUpdate;
                query = query.Replace("@Ape", cryp.Encriptar(this.ape));
                query = query.Replace("@Nom", cryp.Encriptar(this.nom));
                query = query.Replace("@Doc", cryp.Encriptar(this.doc.ToString()));
                query = query.Replace("@Tar", cryp.Encriptar(this.tar));
                query = query.Replace("@Id", cryp.Encriptar(this.id.ToString()));
                return db.ExecNonQueryMasivo(query);
            }
            catch
            {
                return false;
            }
        }

        public bool Insert_Base_Local_Masivo( DataBase db )
        {
            try
            {
                var cryp = new CCryptorEngine();
                var query = QueryInsert;
                query = query.Replace("@Ape", cryp.Encriptar(this.ape));
                query = query.Replace("@Nom", cryp.Encriptar(this.nom));
                query = query.Replace("@Doc", cryp.Encriptar(this.doc.ToString()));
                query = query.Replace("@Tar", cryp.Encriptar(this.tar));
                query = query.Replace("@Id", cryp.Encriptar(this.id.ToString()));
                return db.ExecNonQueryMasivo(query);
            }
            catch
            {
                return false;
            }
        }


    }
}
