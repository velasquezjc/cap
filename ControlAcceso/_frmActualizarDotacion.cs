using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Collections.Specialized;

namespace ControlAcceso
{
    public partial class frmActualizarDotacion : Form
    {
        private int index = 0;
        private int DotTotal = 0;
        private bool semActualizar = true;
        private bool ver_bitacora = true;
        private DateTime inicio_proceso;
        private Persona[] aPerActualizacion;
        private Dotacion dotacion_local = new Dotacion();

        private DataBase db_masivo = new DataBase();


        public frmActualizarDotacion()
        {
            InitializeComponent();
            this.btnDetalle_Click(this, EventArgs.Empty);
        }


        private void btnActualizarBase_Click(object sender, EventArgs e)
        {
            btnActualizarBase.Enabled = false;
            btnDetalle.Enabled = true;
            Proceso_Actualizar_Base_Local();
        }


        private void Proceso_Actualizar_Base_Local()
        {
            // Obtener Dotacion desde la Web
            var bdw = new ServiceLayer(); Dotacion dotacion_remota;
            try
            {
                txtDetalle.Text += "Conectando con el servidor remoto..." + System.Environment.NewLine;
                this.Refresh();
                dotacion_remota = bdw.Get_Dotacion();
                txtDetalle.Text += "Preparando la base de datos para la actualización..." + System.Environment.NewLine;
                this.Refresh();
                var ret = dotacion_remota.Grabar_Dotacion_JS();
                if (ret && dotacion_remota.personas.Count > 0 )
                    txtDetalle.Text += "Se actualizo correctamente la dotación..." + System.Environment.NewLine;
                else
                    txtDetalle.Text += "No fue posible actualizar la dotacion! Vuelva a intentar." + System.Environment.NewLine;
                this.Refresh();
            }
            catch (Exception e)
            {
                txtDetalle.Text += "Se produjo un error: " + e.Message + System.Environment.NewLine;
                this.Refresh();
                MessageBox.Show("No fue posible establecer la comunicación con el servidor remoto.\nVerifique su conexión de internet.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }        
        
        }

        //private void Proceso_Actualizar_Base_Local() 
        //{ 
        //    // Obtener Dotacion desde la Web
        //    var bdw = new ServiceLayer(); Dotacion dotacion_remota;
        //    try
        //    {
        //        txtDetalle.Text += "Recuperando dotacion local..." + System.Environment.NewLine;
        //        this.Refresh();
        //        dotacion_local.Recuperar_Dotacion_DB();
        //        txtDetalle.Text += "Conectando con el servidor remoto..." + System.Environment.NewLine;
        //        this.Refresh();
        //        dotacion_remota = bdw.Get_Dotacion();
        //        txtDetalle.Text += "Preparando la base de datos para la actualización..." + System.Environment.NewLine;
        //        this.Refresh();
        //        db_masivo.OpenMasivo(db_masivo.GenerarConexionString(DataBase.getDefaultPathDB()));
        //    }
        //    catch ( Exception e )
        //    {
        //        txtDetalle.Text += "Se produjo un error: " + e.Message + System.Environment.NewLine;
        //        this.Refresh();
        //        MessageBox.Show("No fue posible establecer la comunicación con el servidor remoto.\nVerifique su conexión de internet.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        return;
        //    }
        //    DotTotal = dotacion_remota.personas.Count;
        //    txtDetalle.Text += "Se estableció la conexion con el servidor y se obtuvo la dotación." + System.Environment.NewLine;
        //    txtDetalle.Text += "Cantidad de personas para actualizar: " + DotTotal.ToString() + "." + System.Environment.NewLine;
        //    txtDetalle.Text += "Comienzo del proceso de actualizacion..." + System.Environment.NewLine;
        //    lblTitulo.Text = "Actualizando " + DotTotal.ToString() + " registros de dotación.";
        //    this.Refresh();
        //    // Actualizar Base local
        //    aPerActualizacion = dotacion_remota.personas.ToArray();
        //    index = 0;
        //    pgbActualizar.Minimum = 0;
        //    pgbActualizar.Maximum = DotTotal;
        //    pgbActualizar.Value = 0;
        //    lblPorcentaje.Text = String.Format("{0}% completado", (100 * index) / aPerActualizacion.Length);
        //    lblTiempoEst.Text = "Tiempo estimado: Calculando....";
        //    inicio_proceso = DateTime.Now;
        //    timerSincronizar.Enabled = true;
        //}

        private void timerSincronizar_Tick(object sender, EventArgs e)
        {
            if (!this.semActualizar) return;
            this.semActualizar = false;
            if (aPerActualizacion.Length <= index)
            {
                timerSincronizar.Enabled = false;
                pgbActualizar.Enabled = false;
                txtDetalle.Text += "Fin del proceso de actualización de la base de datos local." + System.Environment.NewLine;
                this.Refresh();
                txtDetalle.Text += "Cerrando la base de datos local." + System.Environment.NewLine;
                this.Refresh();
                db_masivo.CloseMasivo();
                var lblPorcentajeFin = String.Format("{0}% completado", (100 * index) / aPerActualizacion.Length);
                this.lblPorcentaje.Text = lblPorcentajeFin;
                this.Text = "Actualizar Dotación.";
                return;
            }

            var perDot = aPerActualizacion[index];
            //if (!perDot.Existe_Base_Local())
            if(!this.dotacion_local.personas.Exists(p => p.id==perDot.id))
            {
                if (perDot.Insert_Base_Local_Masivo(db_masivo))
                    txtDetalle.Text += "El registro #" + (++index).ToString().Trim() + "  fue insertado en la BD."+ System.Environment.NewLine;
                else
                    txtDetalle.Text += "Error al intentar insertar la información del registro #" + (++index).ToString() + System.Environment.NewLine;
            }
            else
            {
                if (perDot.Update_Base_Local_Masivo(db_masivo))
                    txtDetalle.Text += "El registro #" + (++index).ToString() + " actualizó información en la BD." + System.Environment.NewLine;
                else
                    txtDetalle.Text += "Error intentar actualizar la BD con la información del registro #" + (++index).ToString() + System.Environment.NewLine;
            }
            this.Refresh();
            var lblPorcentaje = String.Format("{0}% completado", (100 * index) / aPerActualizacion.Length );
            this.lblPorcentaje.Text = lblPorcentaje;
            this.Text = lblPorcentaje;
            this.lblDetReg.Text = "Procesando el registro #" + index.ToString();
            this.lblTiempoEst.Text = "Tiempo estimado: " + this.Get_Tiempo_Estimado();
            this.lblRestantes.Text = "Registros restantes a procesar: " + (DotTotal - index).ToString();
            pgbActualizar.Value = index;
            this.semActualizar = true;
        }


        private string Get_Tiempo_Estimado(){
            var tiempo_transcurrido = (DateTime.Now - inicio_proceso).TotalMilliseconds;
            var tiempo_restante = Convert.ToDouble(DotTotal-index) * tiempo_transcurrido / Convert.ToDouble(index);
            var minutos_rest = tiempo_restante /  60000.0;
            var min_display = Convert.ToInt32(minutos_rest);
            if (minutos_rest >= 1)
                return "Aproximadamente " + min_display + " minuto" + (min_display > 1? "s" : "") + ".";
            else
                return "Aproximadamente " + Convert.ToInt32(minutos_rest*60) + " segundos.";
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            ver_bitacora = !ver_bitacora;
            if (ver_bitacora)
            {
                this.Height = 565;
                btnDetalle.Text = "Ocultar Detalles";
            }
            else
            {
                this.Height = 150;
                btnDetalle.Text = "Ver Detalles >>";
            }
        }

        private void txtDetalle_TextChanged(object sender, EventArgs e)
        {
            txtDetalle.SelectionStart = txtDetalle.Text.Length;
            txtDetalle.ScrollToCaret();
        }

        private void frmSincronizarBD_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (timerSincronizar.Enabled)
                if (MessageBox.Show("El proceso aún no finalizó ¿Confirma cerrar la ventana?", "Actualizar Dotación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    timerSincronizar.Enabled = false;
                    try { db_masivo.CloseMasivo(); }
                    catch { }
                    e.Cancel = false;
                }
                else
                    e.Cancel = true;
        }


    }
}
