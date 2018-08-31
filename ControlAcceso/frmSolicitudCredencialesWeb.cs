using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlAcceso
{
    public partial class frmSolicitudCredencialesWeb : Form
    {
        private static bool bolAcceder = false;

        public frmSolicitudCredencialesWeb()
        {
            InitializeComponent();
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnValidarUsuario_Click(null, null);
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnValidarUsuario_Click(null, null);
        }

        private void btnValidarUsuario_Click(object sender, EventArgs e)
        {
            var result_login = false;
            try
            {
                var sl = new ServiceLayer();
                result_login = sl.Login_Web(txtUser.Text, txtPass.Text);
            }
            catch {}
            if (result_login)
            {
                if (!Seguridad.Actualizar_Usuario_Validado(txtUser.Text, txtPass.Text))
                {
                    MessageBox.Show("No fue posible actualizar las credenciales de acceso. Vuelva a Intentar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUser.SelectAll();
                    txtPass.SelectAll();
                }
                else
                {
                    MessageBox.Show("Las credenciales de acceso fueron actualizadas correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bolAcceder = true;
                    this.Close();
                }
            }
            else
                MessageBox.Show("Las credenciales no pudieron ser comprobadas por la web de RRHH. Compruebe la conxión a internet. Vuelva a intentar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static bool Show_Credenciales_Web( ref string user, ref string pass )
        {
            var frm = new frmSolicitudCredencialesWeb();
            frm.ShowDialog();
            if (bolAcceder)
            { 
                user = frm.txtUser.Text;
                pass = frm.txtPass.Text;
            }
            return bolAcceder;
        }

    }
}
