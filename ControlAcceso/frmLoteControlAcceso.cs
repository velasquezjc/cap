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
    public partial class frmLoteControlAcceso : Form
    {
        public string Lote_Id = string.Empty;
        public Dotacion Dot;
        public List<Edificio> Edif;

        private frmLoteControlAcceso()
        {
            InitializeComponent();
        }

        public static void ShowDetalle( string Lote_Id_Param, Dotacion Dot_Param, List<Edificio> Edif_Param )
        {
            var frm = new frmLoteControlAcceso();
            frm.Lote_Id = Lote_Id_Param;
            frm.Dot = Dot_Param;
            frm.Edif = Edif_Param;
            frm.txtNroLote.Text = frm.Lote_Id;
            frm.Cargar_Registros_Lote();
            frm.Show();
        }

        private void Cargar_Registros_Lote()
        {
            var lote = new LoteControlAcceso(Lote_Id);
            if (lote.Cargar_Registros_Del_Lote())
                dgvLote.DataSource = lote.Get_Registos_DataTable(this.Dot, this.Edif);
        }

    }
}
