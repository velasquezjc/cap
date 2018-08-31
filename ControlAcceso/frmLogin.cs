using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ControlAcceso
{
    public partial class frmLogin : Form
    {
        private bool bolAcceder;
        private const string user_adm = "admin";
        private const string pass_adm = "rrhh9j1925";

        public frmLogin()
        {
            bolAcceder = false;
        }

        public bool AccederAlSistema( )
        {
            InitializeComponent();
            this.ShowDialog();
            return bolAcceder;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == user_adm && txtPass.Text == pass_adm)
            {
                LoguearUsuario(true);
                return;
            }
            DataBase db = new DataBase();
            string sConexion = db.GenerarConexionString( DataBase.getDefaultPathConfig() );
            string ConsultaSQL = "SELECT COUNT(Id) as login FROM usr WHERE name = '@name' AND pass = '@pass';";
            CCryptorEngine cryp = new CCryptorEngine();
            ConsultaSQL = ConsultaSQL.Replace("@name", cryp.Encriptar(txtUser.Text));
            ConsultaSQL = ConsultaSQL.Replace("@pass", cryp.EncodeMD5(txtPass.Text));
            DataTable dt = db.ExecQuery(ConsultaSQL, sConexion);
            if ((int)(dt.Rows[0]["login"]) != 1)
            {
                MessageBox.Show("El nombre de usuario o la contraseña introducidos no son correctos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUser.SelectAll();
                txtPass.SelectAll();
                return;
            }
            LoguearUsuario(false);
        }

        private void LoguearUsuario( bool es_user_admin  )
        {
            Seguridad.user_name_login = txtUser.Text;
            Seguridad.user_pass = txtPass.Text;
            Seguridad.es_user_admin = es_user_admin;
            bolAcceder = true;
            this.Close();
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnLogin_Click(this, EventArgs.Empty);
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnLogin_Click(this, EventArgs.Empty);
        }

        private void lblPrimerIngreso_Click(object sender, EventArgs e)
        {
            var user = string.Empty;
            var pass = string.Empty;
            if (frmSolicitudCredencialesWeb.Show_Credenciales_Web(ref user, ref pass))
            {
                txtUser.Text = user;
                txtPass.Text = pass;
                btnLogin_Click(this, EventArgs.Empty);
            }
        }

        public void Login_Externo( string user, string pass )
        {
            txtUser.Text = user;
            txtPass.Text = pass;
            btnLogin_Click(this, EventArgs.Empty);
        }



    }
}

