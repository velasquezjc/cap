using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Info_Molinetes
{
    public partial class frmPpal : Form
    {
        public frmPpal()
        {
            InitializeComponent();
        }

        private void importarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmImportar();
            frm.MdiParent = this;
            frm.Show();
        }

        private void exportarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmExportar();
            frm.MdiParent = this;
            frm.Show();
        }

        private void configuracionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmEncriptacion();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
