using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Info_Molinetes
{
    public partial class frmEncriptacion : Form
    {
        public frmEncriptacion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtOriginal.Text.CompareTo(string.Empty) == 0)
            {
                txtEncriptado.Text = string.Empty;
                txtDesencriptado.Text = string.Empty;
                txtMD5.Text = string.Empty;
                return;
            }
            CCryptorEngine c = new CCryptorEngine();
            try { txtEncriptado.Text = c.Encriptar(txtOriginal.Text); }
            catch { txtEncriptado.Text = string.Empty; }
            try { txtDesencriptado.Text = c.Desencriptar(txtOriginal.Text); }
            catch { txtDesencriptado.Text = string.Empty; }
            try { txtMD5.Text = c.EncodeMD5(txtOriginal.Text); }
            catch { txtMD5.Text = string.Empty; }
        }


    }
}
