using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Net;
using System.Windows.Forms;
using System.Collections.Specialized;
using Microsoft.VisualBasic;
using Newtonsoft.Json;


namespace ControlAcceso
{
    public partial class frmMenu : Form
    {
        private Config cnf = new Config(DataBase.getDefaultPathConfig());
        private const string URL_SiGIRH_Def = "https://rrhh.desarrollosocial.gob.ar/";

        public frmMenu()
        {
            InitializeComponent();
            Verificar_URL_SiGIRH();
        }

        private void ConfigurarSegunPerfil()
        {
            if (Seguridad.es_user_admin)
            {
                btnEdificios.Enabled = true;
                btnInformarNovedades.Enabled = false;
                btnRegistrarAcceso.Enabled = false;
                btnSincronizar.Enabled = false;
                uRLWebRRHHToolStripMenuItem.Enabled = true;
                reestablecerValoresPorDefectoToolStripMenuItem.Enabled = true;
                configurarProxyToolStripMenuItem.Enabled = false;
            }
        }


        private void btnInformar_Click(object sender, EventArgs e)
        {
            frmActualizarDotacion sincro = new frmActualizarDotacion();
            sincro.ShowDialog();
        }

        private void btnCargarAsistencia_Click(object sender, EventArgs e)
        {
            var regAcceso = new frmRegistrarAcceso();
            regAcceso.ShowDialog();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            if (!frmLogin.AccederAlSistema())
            {
                this.Close();
                return;
            }
            if (!VerificarEdificioControlAcceseso())
            {
                this.Close();
                return;
            }
            ConfigurarSegunPerfil();
        }


        private void directorioDeExportaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start(InformeAsistencia.getPathDirectorioInforme());
        }

        private void btnInformarNovedades_Click(object sender, EventArgs e)
        {
            var InfNov = new frmInformarNovedades();
            InfNov.ShowDialog();
        }

        private void btnEdificios_Click(object sender, EventArgs e)
        {
            var Edif = new frmEdificios();
            Edif.ShowDialog();
            SetEdificioPantalla();
        }


        private bool VerificarEdificioControlAcceseso()
        {
            var edi = new Edificio();
            var dt = edi.Get_Edificios();
            var encontrado = false;
            foreach (DataRow row in dt.Rows)
            {
                if (Convert.ToBoolean(row["sel"]) == true)
                {
                    edi.id = Convert.ToInt32(row["id"]);
                    edi.nom = row["nom"].ToString();
                    edi.dir = row["dir"].ToString();
                    edi.loc = row["loc"].ToString();
                    edi.prv = row["prv"].ToString();
                    Seguridad.edificio = edi;
                    encontrado = true;
                    break;
                }
            }
            if (!encontrado)
            {
                MessageBox.Show("Es necesario configurar un edificio donde se efectúa el control de acceso.", "Atención:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                var frmEdif = new frmEdificios();
                frmEdif.ShowDialog();
            }
            if (Seguridad.edificio == null)
                return false;
            SetEdificioPantalla();
            return true;
        }

        private void SetEdificioPantalla()
        {
            //Seguridad.edificio.id = Convert.ToInt32(row["id"]);            
            txtNombre.Text = Seguridad.edificio.nom;
            txtDireccion.Text = Seguridad.edificio.dir;
            txtLocalidad.Text = Seguridad.edificio.loc;
            txtProvincia.Text = Seguridad.edificio.prv;
        }

        private void uRLWebRRHHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var url_old = cnf.Read(Config.eKeys.URL_SIGIRH.ToString());
            if (url_old == "") 
            {
                reestablecerValoresPorDefectoToolStripMenuItem_Click(this, EventArgs.Empty);
                return;
            }
            var url_new = Interaction.InputBox("Ingrese la url del sitio web Si.G.I.R.H. para sincronizar la información:", "Configurar URL del sitio web Si.G.I.R.H.", url_old );
            if (url_new != "" && url_old != url_new)
                if (MessageBox.Show("Este es un dato que debe estar correctamente configurado para sincronizar la información con la web de RRHH.\n¿Confirma modificar la URL del sitio Si.G.I.R.H.?\n ", "Pregunta:", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                    cnf.Save(Config.eKeys.URL_SIGIRH.ToString(), url_new);
        }

        private void reestablecerValoresPorDefectoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Confirma establecer los valores por defecto de la aplicación?", "Pregunta:", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                cnf.Save(Config.eKeys.URL_SIGIRH.ToString(), URL_SiGIRH_Def);
            }
        }

        private void Verificar_URL_SiGIRH()
        {
            var url_old = cnf.Read(Config.eKeys.URL_SIGIRH.ToString());
            if (url_old == "") cnf.Save(Config.eKeys.URL_SIGIRH.ToString(), URL_SiGIRH_Def);
        }

        private void configurarProxyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sl = new ServiceLayer();

            if (!ServiceLayer.Check_Conexion_Internet())
            {
                MessageBox.Show("Verifique las conexiones de su equipo, no fue posible acceder a internet.", "Atención:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!sl.Login_Web(Seguridad.user_name_login, Seguridad.user_pass))
                MessageBox.Show("No fue posible estrablecer conexión con la web RRHH. Verifique las credenciales de autenticación web (usuario/contraseña) y los permisos asignados.", "Atención:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                MessageBox.Show("Se estableció con éxito la conexión con el sitio web de RRHH.", "Información:", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSincBack_Click(object sender, EventArgs e)
        {
            if (SincronizarInfo.Proceso_Actual != SincronizarInfo.eProcesos.p0_Sin_Proceso) return;
            if (MessageBox.Show("¿Confirma iniciar el proceso para actualizar la dotación en segundo plano?", "Pregunta:", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                SincronizarInfo.Iniciar();
                timerBackground.Interval = 100;
                timerBackground.Start();
            }
        }

        private void timerBackground_Tick(object sender, EventArgs e)
        {
            SincronizarInfo.Procesar();
            this.lblStatus.Text = SincronizarInfo.InfoEstado;
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {
            if (SincronizarInfo.Proceso_Actual != SincronizarInfo.eProcesos.p0_Sin_Proceso)
            {
                var frm = frmLogSincro.Create();
                if (!frm.Visible) frm.Show(this);
            }

        }

    }
}
