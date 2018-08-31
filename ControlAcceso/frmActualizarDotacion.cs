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
    public partial class frmActualizarDotacion : Form
    {
        public frmActualizarDotacion()
        {
            InitializeComponent();
        }

        private void btnActualizarBase_Click(object sender, EventArgs e)
        {
            if (ServiceLayer.Check_Conexion_Internet())
            {
                try
                {
                    Seguridad.Verificar_Permisos_Web();
                    Proceso_Actualizar_Base_Local();
                }
                catch (ServiceLayerExceptionLogin ex)
                {
                    MessageBox.Show( ex.Message + "\nActualmente no cuenta con permisos necesarios para el uso del sistema. La aplicación se cerrará.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Seguridad.Eliminar_Usuario_Local();
                    Application.Exit();
                }
                catch (ServiceLayerException ex)
                {
                    MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
                MessageBox.Show("No fue posible actualizar la Dotación. Verifique su conexión de internet.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            
        }

        private void Proceso_Actualizar_Base_Local()
        {
            btnActualizarBase.Enabled = false;
            var bdw = new ServiceLayer(); Dotacion dotacion_remota;
            try
            {
                txtDetalle.Text += "Conectando con el servidor remoto..." + System.Environment.NewLine;
                this.Refresh();
                dotacion_remota = bdw.Get_Dotacion();
                txtDetalle.Text += "La web respondió correctamente a la solicitud." + System.Environment.NewLine;
                this.Refresh();
                if (dotacion_remota == null)
                    throw new Exception("No fue posible generar la dotacion guardarla.");
                if (dotacion_remota.personas.Count < 1)
                    throw new Exception("La dotación devuelta esta vacía.");
                txtDetalle.Text += "Se procede a guardar la nueva dotación obtenida desde la web..." + System.Environment.NewLine;
                this.Refresh();
                if (!dotacion_remota.Grabar_Dotacion_JS())
                    throw new Exception("No fue posible guardar la dotación localmente.");
                txtDetalle.Text += "SE ACTUALIZÓ CORRECTAMENTE LA DOTACIÓN!!!" + System.Environment.NewLine;
                this.Refresh();
                MessageBox.Show("Actualización completa.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                txtDetalle.Text += "Se produjo un error: " + e.Message + System.Environment.NewLine;
                this.Refresh();
                MessageBox.Show("No fue posible actualizar la dotación!!! Verifique su conexión de internet.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            btnActualizarBase.Enabled = true;
            
        }


    }

}
