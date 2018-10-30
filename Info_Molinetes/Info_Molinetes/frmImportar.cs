using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Info_Molinetes
{
    public partial class frmImportar : Form
    {
        private const string query_get_accesos = "dbo.CTL_ACC_Exportar_T_Eventos";
        Thread threadGenerar;

        public frmImportar()
        {
            InitializeComponent();
            dtpDesde.Value = DateTime.Now;
            dtpHasta.Value = DateTime.Now;
        }

        private void btnInfoCnn_Click(object sender, EventArgs e)
        {
            var cryp = new CCryptorEngine();
            var cnn_str = cryp.Desencriptar(Properties.Settings.Default[Config.Key_Cnn_DB_Molinetes].ToString());
            var array_items = cnn_str.Split(";".ToCharArray());
            for (int i = 0; i < array_items.Length; i++)
                if (array_items[i].ToLower().Contains("password"))
                    array_items[i] = "Password=*****";
            if (MessageBox.Show("La cadena de conexión es:\n\n" + string.Join(";", array_items) + "\n\n¿Desea modificarla?", "Pregunta:", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                var result = Microsoft.VisualBasic.Interaction.InputBox("Ingrese la nueva cadena de conexión:", "");
                var cnn = new System.Data.SqlClient.SqlConnection();
                try
                {
                    cnn.ConnectionString = result;
                    cnn.Open();
                    if (cnn.State != ConnectionState.Open) throw new Exception("No fue posible abrir la conexión de la base de datos.");
                }
                catch( Exception ex)
                {
                    MessageBox.Show("Se produjo un error en la configuración:\n" + ex.Message + "\nVuelva a intentar.", "Atención:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Properties.Settings.Default[Config.Key_Cnn_DB_Molinetes] = cryp.Encriptar(result);
                Properties.Settings.Default.Save(); 
                MessageBox.Show("La conexión con la base de datos fue modificada.", "Atención:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cnn.Dispose();
                cnn = null;
            }
        }

        private void btnGenLoteImp_Click(object sender, EventArgs e)
        {
            if (dtpDesde.Value > dtpHasta.Value)
            {
                MessageBox.Show("La fecha desde no debe ser mayor a la fecha hasta.", "Atención:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.Habilitar_Controles(false);
            this.threadGenerar = new Thread(frmImportar.DoWork);
            var str_desde_hasta = dtpDesde.Value.ToString("yyyyMMdd") + "|" + dtpHasta.Value.ToString("yyyyMMdd");
            threadGenerar.Start(str_desde_hasta);
            this.pbrGenerar.MarqueeAnimationSpeed = 70;
            this.pbrGenerar.Style = ProgressBarStyle.Marquee;
            this.pbrGenerar.Visible = true;
            tmrGenerar.Enabled = true;

            //try
            //{
            //    var cryp = new CCryptorEngine();
            //    var cnn_str = cryp.Desencriptar(Properties.Settings.Default[Config.Key_Cnn_DB_Molinetes].ToString());
            //    var sqlCnn = new SqlConnection(cnn_str); sqlCnn.Open();
            //    var sqlCmd = new SqlCommand(query_get_accesos, sqlCnn);
            //    sqlCmd.CommandType = CommandType.StoredProcedure;
            //    sqlCmd.Parameters.AddWithValue("@Fecha_Desde", dtpDesde.Value);
            //    sqlCmd.Parameters.AddWithValue("@Fecha_Hasta", dtpHasta.Value);
            //    var dr = sqlCmd.ExecuteReader();
            //    if (dr == null) throw new Exception("Se produjo un error (1).");
            //    var sb = new StringBuilder();
            //    while (dr.Read()) sb.Append(dr[0].ToString() + System.Environment.NewLine);
            //    dr.Dispose(); dr.Close();
            //    sqlCmd.Dispose();
            //    sqlCnn.Dispose(); sqlCnn.Close();
            //    var file_name = dtpDesde.Value.ToString("yyyyMMdd") + "-" + dtpHasta.Value.ToString("yyyyMMdd") + ".sql";
            //    System.IO.StreamWriter file = new System.IO.StreamWriter( Config.get_path_script(file_name) );
            //    file.WriteLine(sb.ToString());
            //    file.Flush();
            //    file.Close();
            //    MessageBox.Show("Fue generado el archivo " + file_name + "." , "Información:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Atención:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }

        private void tmr_Generar_Tick(object sender, EventArgs e)
        {
            if (threadGenerar.ThreadState == ThreadState.Stopped)
            {
                this.Habilitar_Controles(true);
                this.pbrGenerar.Style = ProgressBarStyle.Continuous;
                this.pbrGenerar.MarqueeAnimationSpeed = 0;
                this.pbrGenerar.Visible = false;
            }
        }

        public void Habilitar_Controles(bool enebled)
        {
            dtpDesde.Enabled = enebled;
            dtpHasta.Enabled = enebled;
            btnInfoCnn.Enabled = enebled;
            btnGenLoteImp.Enabled = enebled;
        }

        public static void DoWork(object str_desde_hasta)
        {
            try
            {
                var array_str = ((string)str_desde_hasta).Split("|".ToCharArray());
                var desde = DateTime.ParseExact(array_str[0], "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                var hasta = DateTime.ParseExact(array_str[1], "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                var cryp = new CCryptorEngine();
                var cnn_str = cryp.Desencriptar(Properties.Settings.Default[Config.Key_Cnn_DB_Molinetes].ToString());
                var sqlCnn = new SqlConnection(cnn_str); sqlCnn.Open();
                var sqlCmd = new SqlCommand(query_get_accesos, sqlCnn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Fecha_Desde", desde);
                sqlCmd.Parameters.AddWithValue("@Fecha_Hasta", hasta);
                var dr = sqlCmd.ExecuteReader();
                if (dr == null) throw new Exception("Se produjo un error en la generación del script.");
                var sb = new StringBuilder();
                while (dr.Read()) sb.Append(dr[0].ToString() + System.Environment.NewLine);
                dr.Dispose(); dr.Close();
                sqlCmd.Dispose();
                sqlCnn.Dispose(); sqlCnn.Close();
                var file_name = (desde).ToString("yyyyMMdd") + "-" + (hasta).ToString("yyyyMMdd") + ".sql";
                System.IO.StreamWriter file = new System.IO.StreamWriter(Config.get_path_script(file_name));
                file.WriteLine(sb.ToString());
                file.Flush();
                file.Close();
                MessageBox.Show("Fue generado el archivo " + file_name + ".", "Información:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
