using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ControlAcceso
{
    public partial class frmConfirmacion : Form
    {
        private Persona perPopUp;
        private bool bolSeRegistroAcceso = false;
        private bool bolRegistroPorDocumento;

        public frmConfirmacion()
        {
            InitializeComponent();
            if (RegistroControlAcceso.bteValorDefTipoAcceso == 0)
                rbtnIngreso.Checked = true;
            else
                rbtnEgreso.Checked = true;
        }


        public bool CargarDatos(bool existe, Persona per, bool reg_x_documento )
        {
            bolRegistroPorDocumento = reg_x_documento;
            lblPersona.Text = "";
            lblDocumento.Text = "";
            lblMensaje.Text = "";

            if (existe)
            {
                perPopUp = per;
                lblPersona.Text = per.Get_Full_Name();
                lblDocumento.Text = per.doc.ToString();
                lblMensaje.ForeColor = Color.Green;
                this.ImgMensaje.Image = global::ControlAcceso.Properties.Resources.Symbol_Check;
                this.ImgMensaje.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            }
            else
            {
                label1.Visible = false; label2.Visible = false;
                rbtnIngreso.Visible = false; rbtnEgreso.Visible = false;
                lblMensaje.ForeColor = Color.Red;
                this.ImgMensaje.Image = global::ControlAcceso.Properties.Resources.Symbol_Exclamation;
                this.ImgMensaje.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                lblMensaje.Text = "ATENCION !! El Documento o el Nro. de Tarjeta no fue encontrado.";
                btnAceptar.Visible = false;
                btnCancelar.Left = (this.Width / 2) - (btnCancelar.Width / 2);
                btnCancelar.Focus();
            }
            this.ShowDialog();
            return bolSeRegistroAcceso;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                var contAcc = new RegistroControlAcceso();
                DateTime ult_fecha_grabada = new DateTime();
                if (!contAcc.Fecha_Actual_Es_Mayor_Ult_Fecha_Grabacion(ref ult_fecha_grabada))
                {
                    MessageBox.Show(
                        "La fecha actual del equipo es: " + DateTime.Now.ToString() + "\n" +
                        "La última fecha grabada en el sistema es: " + ult_fecha_grabada.ToString() + "\n" +
                        "Para continuar con la carga debe configurar en el equipo una fecha posterior a la última grabada.", "Atención:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                contAcc.Insert(perPopUp, rbtnIngreso.Checked, this.bolRegistroPorDocumento);
                bolSeRegistroAcceso = true;
                this.Close();
            }
            catch (Exception )
            {                
                throw ;
            }
        }


        private void rbtnIngreso_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnIngreso.Checked) RegistroControlAcceso.bteValorDefTipoAcceso = 0;
        }


        private void rbtnEgreso_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnEgreso.Checked) RegistroControlAcceso.bteValorDefTipoAcceso = 1;
        }


        private void PopUp_Confirmacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
        }

    }
}
