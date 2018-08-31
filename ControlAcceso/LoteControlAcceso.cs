using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace ControlAcceso
{
    public class LoteControlAcceso
    {
        public string id = string.Empty;
        public string usu = string.Empty;
        public string macAddr = string.Empty;
        public string IP = string.Empty;
        public List<RegistroControlAcceso> registros;

        public static int CANT_REG_X_LOTE = 20;
        private static string QueryCrearNuevoLote = "UPDATE Cac SET [lot] = '@lot', [int] = '@int' WHERE Id IN (SELECT TOP 60 C0.ID FROM Cac AS C0 WHERE ([C0.lot] IS NULL OR [C0.lot] = '') ORDER BY c0.ID ASC );";
        private static string QueryRegLote = "SELECT * FROM Cac WHERE lot = '@lot';";
        private static string QueryLotesNoInf = "SELECT lot AS LOTE, COUNT(id) AS REG_SIN_INFORMAR FROM Cac WHERE inf = '0' GROUP BY lot;";
        private static string QueryLotesInf = "SELECT lot AS LOTE, COUNT(id) AS REG_INFORMADOS FROM Cac WHERE inf <> '0' GROUP BY lot;";
        private static string QueryExistenRegistrosParaInformar = "SELECT COUNT(id) AS REG_PARA_INF FROM Cac WHERE [lot] IS NULL OR [lot] = '';";

        public LoteControlAcceso()
        { 
            this.id = DateTime.Now.ToString("yyyyMMddTHHmmssffffff");
            this.usu = Seguridad.user_name_login;
            this.macAddr = this.get_MAC_Address();
            this.IP = get_Local_IP_Address();
        }

        public LoteControlAcceso( string _id )
        {
            this.id = _id;
        }


        private string get_MAC_Address()
        {
            try
            {
                var macAddr = (from nic in NetworkInterface.GetAllNetworkInterfaces()
                               where nic.OperationalStatus == OperationalStatus.Up
                               select nic.GetPhysicalAddress().ToString()).FirstOrDefault();
                return macAddr;
            }
            catch
            {
                return string.Empty;
            }
        }

        public static string get_Local_IP_Address()
        {
            try 
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        return ip.ToString();
                    }
                }            
            }
            catch { }
            return string.Empty;            
        }

        public static int Cantidad_De_Reg_Para_Informar()
        {         
            try
            {
                var db = new DataBase();
                var cryp = new CCryptorEngine();
                var sConexion = db.GenerarConexionString(DataBase.getDefaultPathDB());
                var query = QueryExistenRegistrosParaInformar;
                var dt = db.ExecQuery(query, sConexion);
                return Convert.ToInt32(dt.Rows[0]["REG_PARA_INF"]);
            }
            catch
            {
                return -1;
            }
        }


        public bool Marcar_Registros_No_Informados()
        {
            try
            {
                var db = new DataBase();
                var cryp = new CCryptorEngine();
                var sConexion = db.GenerarConexionString(DataBase.getDefaultPathDB());
                var query = QueryCrearNuevoLote;
                query = query.Replace("@lot", cryp.Encriptar(this.id));
                query = query.Replace("@int", cryp.Encriptar("1")); // Es el primer intento de informar
                return db.ExecNonQuery(query, sConexion);
            }
            catch
            {
                return false;
            }
        }

        public DataTable Get_Lotes_No_Informados()
        {
            try
            {
                var db = new DataBase();
                var cryp = new CCryptorEngine();
                var sConexion = db.GenerarConexionString(DataBase.getDefaultPathDB());
                var query = QueryLotesNoInf;
                return db.ExecQuery(query, sConexion);
            }
            catch
            {
                return null;
            }
        }

        public DataTable Get_Lotes_Informados()
        {
            try
            {
                var db = new DataBase();
                var cryp = new CCryptorEngine();
                var sConexion = db.GenerarConexionString(DataBase.getDefaultPathDB());
                var query = QueryLotesInf;
                return db.ExecQuery(query, sConexion);
            }
            catch
            {
                return null;
            }
        }

        public bool Cargar_Registros_Del_Lote()
        {
            var db = new DataBase();
            var cryp = new CCryptorEngine();
            var sConexion = db.GenerarConexionString(DataBase.getDefaultPathDB());
            var query = QueryRegLote;
            query = query.Replace("@lot", cryp.Encriptar(this.id));
            var dt = db.ExecQuery(query, sConexion);
            this.registros = new List<RegistroControlAcceso>();
            if (dt.Rows.Count > 0)
            {                
                foreach (DataRow row in dt.Rows)
                {
                    var rca = new RegistroControlAcceso();
                    try
                    {
                        rca.id = Convert.ToInt32(row["Id"]);
                        rca.per_id = Convert.ToInt32(cryp.Desencriptar(row["pid"].ToString()));
                        rca.fecha = DateTime.ParseExact(cryp.Desencriptar(row["fec"].ToString()), "yyyyMMdd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                        rca.es_ingreso = (Convert.ToInt32(row["ing"])!= 0? true : false);
                        rca.usu = cryp.Desencriptar(row["usr"].ToString());
                        rca.edif = Convert.ToInt32(cryp.Desencriptar(row["edi"].ToString()));
                        try { rca.reg_x_doc = (cryp.Desencriptar(row["rdc"].ToString()) == true.ToString() ? true : false); }
                        catch { rca.reg_x_doc = false; }
                        this.registros.Add(rca);
                    }
                    catch
                    {
                        continue;
                    }
                }
                return true;
            }
            return false;
        }

        public DataTable Get_Registos_DataTable(Dotacion Dot, List<Edificio> Edif)
        {
            var table = new DataTable();
            string[] columns = { "id_registro", "nombre_apellido", "fecha", "es_ingreso", "usuario", "edificio" };
            foreach (var col in columns)
                table.Columns.Add(col,typeof(string));
            foreach (var reg in this.registros)
            {
                var row = table.NewRow();
                var per = Dot.personas.Find(p => p.id == reg.per_id);
                var edi = Edif.Find(e => e.id == reg.edif);
                row[0] = reg.id.ToString();
                row[1] = per.nom + " " + per.ape;
                row[2] = reg.fecha.ToString("dd/MM/yyyy HH:mm:ss");
                row[3] = (reg.es_ingreso? "VERDADERO":"FALSO");
                row[4] = reg.usu;
                row[5] = edi.nom + ", " + edi.loc + ", " + edi.prv;
                table.Rows.Add(row);
            }
            return table;
        }
    }
}
