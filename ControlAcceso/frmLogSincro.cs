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
    public partial class frmLogSincro : Form
    {
        private static frmLogSincro frmUnico = null;

        public static frmLogSincro Create()
        {
            if (frmUnico == null) frmUnico = new frmLogSincro();
            return frmUnico;
        }

        private frmLogSincro()
        {
            InitializeComponent();
        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timerRefreshBitacora_Tick(object sender, EventArgs e)
        {
            txtDetalle.Text = SincronizarInfo.Bitacora;
        }

        private void frmLogSincro_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmLogSincro.frmUnico = null;
        }

        private void txtDetalle_TextChanged(object sender, EventArgs e)
        {
            txtDetalle.SelectionStart = txtDetalle.Text.Length;
            txtDetalle.ScrollToCaret();
        }
    }
}
