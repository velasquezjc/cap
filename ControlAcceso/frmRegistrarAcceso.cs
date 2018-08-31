using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ControlAcceso
{
    public partial class frmRegistrarAcceso : Form
    {
        private Dotacion Dot;

        public frmRegistrarAcceso()
        {
            InitializeComponent();
        }

        private void RegistrarAcceso_Load(object sender, EventArgs e)
        {
            this.Dot = new Dotacion();
            if (!this.Dot.Recuperar_Dotacion_JS())
            {
                MessageBox.Show(this, "Se produjo un error al intentar obtener la dotación.\n\nDescripción del error:\n" + this.Dot.error_desc + "\n\nIntente actualizar nuevamente la dotación.", "Atención:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            var existe = false; var reg_x_doc = false; var nro_tar = 0;
            if (!Int32.TryParse(txtDocumento.Text , out nro_tar)) nro_tar = -1;
            var per = this.Dot.personas.Find(p => Convert.ToString(p.doc) == txtDocumento.Text || p.tar == nro_tar.ToString());
            if (per != null)
            {
                if(per.doc.ToString() == txtDocumento.Text) reg_x_doc = true;
                existe = true;
            }
            else
                per = new Persona();
            frmConfirmacion popup = new frmConfirmacion();
            if (popup.CargarDatos(existe, per, reg_x_doc))
                txtDocumento.Text = string.Empty;
        }


        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnRegistrar_Click(this, EventArgs.Empty);
            }
            if (e.KeyChar == Convert.ToChar(Keys.Back))
            {
                e.Handled = false;
                return;
            }
        }

        private void RegistrarAcceso_KeyDown(object sender, KeyEventArgs e)
        {
            if ( e.KeyCode == Keys.Escape) this.Close();
        }
    }
}
