using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using System.IO;

namespace ControlAcceso
{
    public class DataBase
    {
        private OleDbConnection cnnMasivo;

        private const string cnstPassDB = "CONTROL_ACC_MDS_RRHH";

        private const string cnstLocPadron = @"\DB\dotacion.mdb";

        private const string cnstLocTemplate = @"\Templates\templateAsistencia.mdb";

        private const string cnstLocDotacionJSCryp = @"\DB\dotacion.dat";

        private const string cnstLocConfig = @"\config.mdb";

        private const string cnstStrCnn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=#Ruta;Jet OLEDB:Database Password=" + cnstPassDB + ";";

        public static string getDefaultPathDB()
        {
            return Directory.GetCurrentDirectory() + cnstLocPadron;
        }

        public static string getDefaultPathConfig()
        {
            return Directory.GetCurrentDirectory() + cnstLocConfig;
        }

        public static string getDefaultPathTemplate()
        {
            return Directory.GetCurrentDirectory() + cnstLocTemplate;
        }

        public static string getDefaultPathDotacionJsCryp()
        {
            return Directory.GetCurrentDirectory() + cnstLocDotacionJSCryp;
        }

        public string GenerarConexionString( string Ruta )
        {
            return cnstStrCnn.Replace("#Ruta", Ruta);
        }

        public DataTable ExecQuery( string strQuery, string strCnn )
        {
            try
            {
                OleDbConnection conexion = new OleDbConnection(strCnn);
                conexion.Open();
                OleDbDataAdapter adap = new OleDbDataAdapter(strQuery, conexion);
                DataTable dtDatos = new DataTable();
                adap.Fill(dtDatos);
                adap.Dispose();
                conexion.Close();
                conexion.Dispose();
                return dtDatos;
            }
            catch
            {
                return null;
            }
        }

        public bool ExecNonQuery(string strQuery, string strCnn)
        {
            try
            {
                OleDbConnection conexion = new OleDbConnection(strCnn);
                conexion.Open();
                OleDbCommand commnad = new OleDbCommand(strQuery, conexion);
                commnad.ExecuteNonQuery();
                commnad.Dispose();
                conexion.Close();
                conexion.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool OpenMasivo( string strCnn )
        {
            try {
                cnnMasivo = new OleDbConnection(strCnn);
                cnnMasivo.Open();
                return true;
            }
            catch
            {
                cnnMasivo = null;
                return false;
            }
            
        }

        public bool ExecNonQueryMasivo(string strQuery)
        {
            try
            {
                OleDbCommand commnad = new OleDbCommand(strQuery, cnnMasivo);
                commnad.ExecuteNonQuery();
                commnad.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CloseMasivo()
        {
            bool bolRet;
            try
            {
                cnnMasivo.Close();
                cnnMasivo.Dispose();
                bolRet = true;
            }
            catch
            {
                bolRet = false;
            }
            finally
            {
                cnnMasivo = null;
            }
            return bolRet;
        }

    }
}