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
    public partial class frmInformarNovedades : Form
    {

        private Dotacion _Dot;

        public Dotacion dot
        {
            get 
            {
                if (this._Dot == null)
                {
                    this._Dot = new Dotacion();
                    if (!this._Dot.Recuperar_Dotacion_JS())
                    {
                        MessageBox.Show(this, "Se produjo un error al intentar obtener la dotación.\n\nDescripción del error:\n" + this._Dot.error_desc + "\n\nIntente actualizar nuevamente la dotación.", "Atención:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
               return _Dot; 
            }
        }

        private List<Edificio> _edificios;

        public List<Edificio> edificios
        {
            get 
            {
                if (_edificios == null)
                { 
                    var edi = new Edificio();
                    _edificios = edi.Get_Edificios_List();
                }
                return _edificios; 
            }
            set { _edificios = value; }
        }



        public frmInformarNovedades()
        {
            InitializeComponent();
            Cargar_Grilla_Lotes_Sin_Informar();
        }


        #region Eventos

        private void btnInformar_Click(object sender, EventArgs e)
        {

            if (ServiceLayer.Check_Conexion_Internet())
            {
                try
                {
                    Seguridad.Verificar_Permisos_Web();
                }
                catch (ServiceLayerExceptionLogin ex)
                {
                    MessageBox.Show(ex.Message + "\nActualmente no cuenta con permisos necesarios para el uso del sistema. La aplicación se cerrará.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Seguridad.Eliminar_Usuario_Local();
                    Application.Exit();
                }
                catch (ServiceLayerException ex)
                {
                    MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            try
            {
                txtBitcora.Text = string.Empty;
                btnInformar.Enabled = false;
                var lst_lotes = Cargar_Lotes_No_Informados();
                foreach (LoteControlAcceso lote in lst_lotes)
                {
                    try
                    {
                        var serv = new ServiceLayer();
                        var lote_resp = serv.Informar_Lote(lote);
                        Procesar_Respuesta_Lote(lote, lote_resp);
                        if ( Marcar_Registros_Informados(lote, lote_resp) )
                        {
                            txtBitcora.Text += "Todos los registros del lote " + lote.id + " fueron marcados como informados." + System.Environment.NewLine;
                            this.Refresh();
                        }
                    }
                    catch
                    {
                        txtBitcora.Text += "Se produjo un error al intentar informar el lote " + lote.id + " (Error 5)." + System.Environment.NewLine;
                        this.Refresh();
                    }

                }
            }
            finally
            {
                btnInformar.Enabled = true;
                Cargar_Grilla_Lotes_Sin_Informar();
            }
        }


        private void radLotesSinInformar_CheckedChanged(object sender, EventArgs e)
        {
            if (radLotesSinInformar.Checked)
            {
                btnInformar.Enabled = true;
                Cargar_Grilla_Lotes_Sin_Informar();
            }

        }

        private void radLotesInformados_CheckedChanged(object sender, EventArgs e)
        {
            if (radLotesInformados.Checked)
            {
                btnInformar.Enabled = false;
                Cargar_Grilla_Lotes_Informados();
            }
        }

        private void Cargar_Grilla_Lotes_Sin_Informar()
        {
            var cryp = new CCryptorEngine();
            var lca = new LoteControlAcceso();
            var dt = lca.Get_Lotes_No_Informados();
            foreach (DataRow row in dt.Rows)
            {
                if (row["LOTE"].ToString() == string.Empty)
                    row["LOTE"] = "< Registros sin Lote >";
                else
                    row["LOTE"] = cryp.Desencriptar(row["LOTE"].ToString());
            }
            dgvLotes.DataSource = dt;
            foreach (DataGridViewColumn col in dgvLotes.Columns)
            {
                col.Width = ((dgvLotes.Width - 45) / dgvLotes.Columns.Count);
            }
        }


        private void dgvLotes_DoubleClick(object sender, EventArgs e)
        {
            if (!Seguridad.es_user_admin) return;
            if (dgvLotes.SelectedRows.Count < 1 ) return;
            var lote_id = string.Empty;
            if (radLotesInformados.Checked)
            {
                var index = dgvLotes.SelectedRows[0].Index;
                lote_id = ((string)dgvLotes.Rows[index].Cells[0].Value);
                frmLoteControlAcceso.ShowDetalle(lote_id, this.dot, this.edificios);
            }
        }

        #endregion


        #region Procedimientos y Funciones

        private void Cargar_Grilla_Lotes_Informados()
        {
            var cryp = new CCryptorEngine();
            var lca = new LoteControlAcceso();
            var dt = lca.Get_Lotes_Informados();
            foreach (DataRow row in dt.Rows)
            {
                if (row["LOTE"].ToString() == string.Empty)
                    row["LOTE"] = "< Registros sin Lote >";
                else
                    row["LOTE"] = cryp.Desencriptar(row["LOTE"].ToString());
            }
            dgvLotes.DataSource = dt;
            foreach (DataGridViewColumn col in dgvLotes.Columns)
            {
                col.Width = ((dgvLotes.Width - 45) / dgvLotes.Columns.Count);
            }
        }

        private List<LoteControlAcceso> Cargar_Lotes_No_Informados()
        {
            var lst_lotes = new List<LoteControlAcceso>();
            foreach (DataGridViewRow row in dgvLotes.Rows)
            {
                if (!row.Cells[0].Value.ToString().Contains("<"))
                {
                    try
                    {
                        var lote = new LoteControlAcceso();
                        lote.id = row.Cells[0].Value.ToString();
                        if (lote.Cargar_Registros_Del_Lote())
                        {
                            lst_lotes.Add(lote);
                            txtBitcora.Text += "Se cargaron los registros del lote " + lote.id + "." + System.Environment.NewLine;
                        }
                        else
                            txtBitcora.Text += "No fue posible cargar los registros del lote " + lote.id + " (Error 1)." + System.Environment.NewLine;
                    }
                    catch
                    {
                        txtBitcora.Text += "No fue posible cargar los registros del lote " + row.Cells[0].Value.ToString() + " (Error 2)." + System.Environment.NewLine;
                    }
                    this.Refresh();
                }
                else
                {
                    do
                    {
                        var nuevo_lote = Crear_Nuevo_Lote();
                        if (nuevo_lote != null)
                        {
                            lst_lotes.Add(nuevo_lote);
                            txtBitcora.Text += "El nuevo lote generado es el " + nuevo_lote.id + System.Environment.NewLine;
                        }
                        else
                        {
                            txtBitcora.Text += "No fue posible crear un nuevo lote (Error 4)." + System.Environment.NewLine;
                        }
                        this.Refresh();
                    } while (LoteControlAcceso.Cantidad_De_Reg_Para_Informar() > 0);
                }
            }
            return lst_lotes;
        }


        private LoteControlAcceso Crear_Nuevo_Lote()
        {
            LoteControlAcceso lote;
            try
            {
                txtBitcora.Text = string.Empty;
                btnInformar.Enabled = false;
                lote = new LoteControlAcceso();
                if (!lote.Marcar_Registros_No_Informados())
                {
                    txtBitcora.Text += "No fue posible marcar los registros para generar el lote a informar (Error 3.1)." + System.Environment.NewLine;
                    this.Refresh();
                    return null;
                }
                txtBitcora.Text += "Se marcaron registros para generar un nuevo lote." + System.Environment.NewLine;
                if (!lote.Cargar_Registros_Del_Lote())
                {
                    if (lote.registros != null)
                    {
                        if (lote.registros.Count == 0)
                        {
                            txtBitcora.Text += "No se encontraron nuevos registros para informar (Error 3.2)." + System.Environment.NewLine;
                        }
                        else
                        {
                            txtBitcora.Text += "No fue posible recuperar la totalidad de los regisros para informar (Error 3.3)." + System.Environment.NewLine;
                        }
                    }
                    else
                        txtBitcora.Text += "No fue posible cargar nuevos registros a informar (Error 3.4)." + System.Environment.NewLine;
                    this.Refresh();
                    return null;
                }
                txtBitcora.Text += "Se cargaron los registros del nuevo lote." + System.Environment.NewLine;
                this.Refresh();
                return lote;

            }
            catch
            {
                this.Refresh();
                return null;
            }
        }

        private void Procesar_Respuesta_Lote( LoteControlAcceso lote,  LoteResponse lote_resp)
        {
            txtBitcora.Text += "Resultado lote " + lote.id + ": ";

            if (lote_resp.resultado.ToUpper() == "OK")
                txtBitcora.Text += "Todos los registros del lote fueron informados correctamente." + System.Environment.NewLine;
            else
                txtBitcora.Text += "Se produjo un error en el procesamiento remoto (" + lote_resp.resultado + ")." + System.Environment.NewLine;

            this.Refresh();
            return;
        }


        private bool Marcar_Registros_Informados(LoteControlAcceso lote, LoteResponse lote_resp)
        {
            var error = false;
            foreach (var reg in lote.registros)
            {
                try
                {
                    if (!reg.Marcar_Como_Informado())
                        throw new Exception();
                }
                catch
                {
                    error = true;
                    txtBitcora.Text += "* Error al grabar el registro " + reg.id.ToString() + " del lote " + lote.id + " no pudo ser marcado como informado." + System.Environment.NewLine;
                    this.Refresh();
                }
            }
            return error;
        }

        #endregion







    }
}



