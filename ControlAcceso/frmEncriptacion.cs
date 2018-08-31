using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ControlAcceso
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
                return;
            CCryptorEngine c = new CCryptorEngine();

            txtMD5.Text = c.EncodeMD5(txtOriginal.Text);
            txtEncriptado.Text = c.Encriptar(txtOriginal.Text);            
            txtDesencriptado.Text = c.Desencriptar(txtEncriptado.Text);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //DataBase db = new DataBase();

            //System.Data.DataTable dt = db.ExecQuery("select * from psn");

            //for (int i = 0; i < dt.Rows.Count; i++)
            //    MessageBox.Show(dt.Rows[i][0].ToString() + " - " + dt.Rows[i][1].ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //DataBase db = new DataBase();
            //System.Data.DataTable dt = db.ExecQuery("select * from padron");
            //MessageBox.Show(dt.Rows[0][0].ToString() + " - " + dt.Rows[0][1].ToString());

            //CCryptorEngine cryp = new CCryptorEngine();


            //MessageBox.Show(cryp.EncodeMD5(dt.Rows[0][0].ToString()) + " - " + cryp.Encriptar(dt.Rows[0][1].ToString()));
        }
    }
}
