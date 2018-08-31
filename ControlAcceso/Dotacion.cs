using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ControlAcceso
{
    public class Dotacion
    {
        public List<Persona> personas;
        private static string QueryListAll = "SELECT * FROM Dot;";

        private string _error_desc = string.Empty;
        public string error_desc 
        {
            get { return _error_desc; }
        }


        public bool Recuperar_Dotacion_DB() {
            try {
                var db = new DataBase();
                var cryp = new CCryptorEngine();
                var sConexion = db.GenerarConexionString(DataBase.getDefaultPathDB());
                var dt = db.ExecQuery(QueryListAll, sConexion);
                if (dt.Rows.Count > 0)
                {
                    this.personas = new List<Persona>();
                    foreach (DataRow row in dt.Rows) {
                        var per = new Persona();
                        try {
                            per.id = Convert.ToInt32(cryp.Desencriptar(row["Id"].ToString()));
                            per.ape = cryp.Desencriptar(row["Ape"].ToString());
                            per.nom = cryp.Desencriptar(row["Nom"].ToString());
                            per.tar = cryp.Desencriptar(row["Tar"].ToString());
                            per.doc = Convert.ToInt32(cryp.Desencriptar(row["Doc"].ToString()));
                            this.personas.Add(per);
                        }
                        catch {
                            continue;
                        }
                    }
                    return true;
                }
                throw new Exception();
            }
            catch
            {
                return false;
            }
        }

        public bool Grabar_Dotacion_JS()
        {
            try
            {
                var cryp = new CCryptorEngine();
                var path_file = DataBase.getDefaultPathDotacionJsCryp();
                var dot_js_cryp = cryp.Encriptar(JsonConvert.SerializeObject(this.personas));
                System.IO.File.WriteAllText(path_file, dot_js_cryp);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Recuperar_Dotacion_JS()
        {
            try
            {                
                var cryp = new CCryptorEngine();
                var path_file = DataBase.getDefaultPathDotacionJsCryp();
                var dot_js = cryp.Desencriptar(System.IO.File.ReadAllText(path_file));
                this.personas = JsonConvert.DeserializeObject<List<Persona>>(dot_js);
                return true;
            }
            catch(Exception ex)
            {
                this._error_desc = ex.Message;
                return false;
            }
        }

    }
}
