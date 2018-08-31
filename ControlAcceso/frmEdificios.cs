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
    public partial class frmEdificios : Form
    {
        public bool bolSeleccionObligatoria = false;
        private Edificio edi = new Edificio();


        public frmEdificios()
        {
            InitializeComponent();
            Cargar_Datos_Formulario();
        }

        private void Cargar_Datos_Formulario()
        {
            var dt = edi.Get_Edificios();
            dgvEdificios.DataSource = dt;
            dgvEdificios.Columns["Id"].Visible = false;

            foreach (DataGridViewRow row in dgvEdificios.Rows)
                if (Convert.ToBoolean(row.Cells["sel"].Value))
                    dgvEdificios.CurrentCell = row.Cells[1];

            foreach( DataRow row in dt.Rows)
            {
                if ( Convert.ToBoolean(row["sel"]) == true)
                {
                    edi.id = Convert.ToInt32(row["id"]);
                    edi.nom = txtNombre.Text = row["nom"].ToString();
                    edi.dir = txtDireccion.Text = row["dir"].ToString();
                    edi.loc = txtLocalidad.Text = row["loc"].ToString();
                    edi.prv = txtProvincia.Text = row["prv"].ToString();
                    Seguridad.edificio = edi;
                    break;
                }
            }
        }


        private void dgvEdificios_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("¿Confirma seleccionar el edificio \"" + dgvEdificios.SelectedRows[0].Cells[1].Value.ToString() + " - " + dgvEdificios.SelectedRows[0].Cells[3].Value.ToString() + "\"?", "Pregunta:", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                var row = dgvEdificios.SelectedRows[0];
                var edi_sel = new Edificio();
                edi_sel.id = Convert.ToInt32(row.Cells["id"].Value);
                edi_sel.Actualizar_Edificio_Sel();
                Cargar_Datos_Formulario();
                MessageBox.Show( "Se modificó el edificio donde se efectúa el control.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEdificios_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Seguridad.edificio == null)
                if (MessageBox.Show("Para usar el sistema es necesario seleccionar un edificio, de lo contrario la aplicación se cerrará. ¿Confirma salir de la aplicación?", "Pregunta:", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.OK)
                    e.Cancel = true;
        }


    }
}
