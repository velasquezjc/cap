using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ControlAcceso
{
    public class Edificio
    {
        public int id = 0;
        public string nom = string.Empty;
        public string dir = string.Empty; 
        public string loc = string.Empty; 
        public string prv = string.Empty;
        public bool sel = false; 

        private static string QueryTodos = "SELECT id, nom, dir, loc, prv, sel FROM edi;";
        private static string QueryDeselEdif = "UPDATE edi SET sel = false WHERE sel = true;";
        private static string QueryActualizarEdiSel = "UPDATE edi SET sel = true WHERE id = @Id;";


        public DataTable Get_Edificios()
        {
            try
            {
                var db = new DataBase();
                var cryp = new CCryptorEngine();
                var sConexion = db.GenerarConexionString(DataBase.getDefaultPathConfig());
                var query = QueryTodos;
                return db.ExecQuery(query, sConexion);                
            }
            catch
            {
                return null;
            }
        }

        public List<Edificio> Get_Edificios_List()
        {
            var list = new List<Edificio>();
            var table = this.Get_Edificios();
            foreach (DataRow row in table.Rows)
            {
                var edi = new Edificio();
                edi.id = (int)row["id"];
                edi.dir = (string)row["dir"];
                edi.nom = (string)row["nom"];
                edi.loc = (string)row["loc"];
                edi.prv = (string)row["prv"];
                edi.sel = (bool)row["sel"];
                list.Add(edi);
            }
            return list;
        }


        public Boolean Actualizar_Edificio_Sel()
        {
            try
            {
                var db = new DataBase();
                var cryp = new CCryptorEngine();
                var sConexion = db.GenerarConexionString(DataBase.getDefaultPathConfig());
                db.ExecNonQuery(QueryDeselEdif, sConexion);
                var query = QueryActualizarEdiSel.Replace("@Id", this.id.ToString());
                return db.ExecNonQuery(query, sConexion);
            }
            catch
            {
                return false;
            }
        }


    }
}
