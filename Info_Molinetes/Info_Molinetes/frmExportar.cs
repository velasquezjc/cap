using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Threading;

namespace Info_Molinetes
{
    public partial class frmExportar : Form
    {
        Thread threadGrabar;

        public frmExportar()
        {
            InitializeComponent();
            cargar_combo_scripts();
        }

        private void btnInfoCnn_Click(object sender, EventArgs e)
        {
            var cryp = new CCryptorEngine();
            var cnn_str = cryp.Desencriptar(Properties.Settings.Default[Config.Key_Cnn_DB_DB_RRHH].ToString());
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
                catch (Exception ex)
                {
                    MessageBox.Show("Se produjo un error en la configuración:\n" + ex.Message + "\nVuelva a intentar.", "Atención:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Properties.Settings.Default[Config.Key_Cnn_DB_DB_RRHH] = cryp.Encriptar(result);
                Properties.Settings.Default.Save();
                MessageBox.Show("La conexión con la base de datos fue modificada.", "Atención:", MessageBoxButtons.OK, MessageBoxIcon.Information);               
                cnn.Dispose();
                cnn = null;
            }
        }

        private void btnGenLoteImp_Click(object sender, EventArgs e)
        {
            if (cboLotesGenerados.Items.Count == 0) return;
            this.Habilitar_Controles(false);
            this.threadGrabar = new Thread(frmExportar.DoWork);
            var query = this.get_query();
            if (query == string.Empty) return;
            threadGrabar.Start(query);
            this.pbarGrabar.MarqueeAnimationSpeed = 70;
            this.pbarGrabar.Style = ProgressBarStyle.Marquee;
            this.pbarGrabar.Visible = true;
            tmr_Grabar.Enabled = true;
        }

        private void btnVerLote_Click(object sender, EventArgs e)
        {
            if (cboLotesGenerados.Items.Count == 0) return;
            var path_file = Config.get_path_script(cboLotesGenerados.SelectedItem.ToString());
            System.Diagnostics.Process.Start(path_file);
        }

        private void btnBorrarLote_Click(object sender, EventArgs e)
        {
            if (cboLotesGenerados.Items.Count == 0) return;
            if (MessageBox.Show("¿Confirma borrar el lote " + cboLotesGenerados.SelectedItem.ToString() + "?", "Pregunta:", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.OK)
                return;
            var file = Config.get_path_script(cboLotesGenerados.SelectedItem.ToString());
            File.Delete(file);
            cargar_combo_scripts();
        }

        private void cargar_combo_scripts()
        {
            var array_files = Config.get_files_names("*.sql");
            Array.Reverse(array_files);
            cboLotesGenerados.Items.Clear();
            foreach( string f in array_files)
                cboLotesGenerados.Items.Add(f);
            if (cboLotesGenerados.Items.Count > 0)
                cboLotesGenerados.SelectedIndex = 0;
        }

        public string get_query()
        {
            string str_script_sql = string.Empty;
            try
            {
                var path_script = Config.get_path_script(cboLotesGenerados.SelectedItem.ToString());
                using (StreamReader sr = new StreamReader(path_script))
                {
                    str_script_sql = sr.ReadToEnd();
                    sr.Close(); sr.Dispose();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Se produjo un error al intentar obtener el script sql:\n" + e.Message, "Atención:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return str_script_sql;
        }

        public static void DoWork(object obj_query)
        {
            try
            {
                var query = (string)obj_query;
                if (query == string.Empty) throw new Exception("No fue posible recuperar el script de sql.");
                var cryp = new CCryptorEngine();
                var cnn_str = cryp.Desencriptar(Properties.Settings.Default[Config.Key_Cnn_DB_DB_RRHH].ToString());
                SqlConnection conn = new SqlConnection(cnn_str);
                Server server = new Server(new ServerConnection(conn));
                server.ConnectionContext.ExecuteNonQuery(query);
                MessageBox.Show("El script sql fue ejecutado correctamente.", "Información:", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void Habilitar_Controles( bool enebled )
        {
            cboLotesGenerados.Enabled = enebled;
            btnVerLote.Enabled = enebled;
            btnBorrarLote.Enabled = enebled;
            btnInfoCnn.Enabled = enebled;
            btnGenLoteImp.Enabled = enebled;
        }

        private void tmr_Grabar_Tick(object sender, EventArgs e)
        {
            if (threadGrabar.ThreadState == ThreadState.Stopped)
            {
                this.Habilitar_Controles(true);
                this.pbarGrabar.Style = ProgressBarStyle.Continuous;
                this.pbarGrabar.MarqueeAnimationSpeed = 0;
                this.pbarGrabar.Visible = false;
            }
        }

    }
}
