namespace Info_Molinetes
{
    partial class frmExportar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExportar));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBorrarLote = new System.Windows.Forms.Button();
            this.btnVerLote = new System.Windows.Forms.Button();
            this.cboLotesGenerados = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenLoteImp = new System.Windows.Forms.Button();
            this.btnInfoCnn = new System.Windows.Forms.Button();
            this.tmr_Grabar = new System.Windows.Forms.Timer(this.components);
            this.pbarGrabar = new System.Windows.Forms.ProgressBar();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(-2, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(397, 49);
            this.panel1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(62, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(303, 43);
            this.label3.TabIndex = 1;
            this.label3.Text = "El usuario actual debe petenecer al dominio SDS_DOMAIN_1 y tener permisos sobre l" +
    "a base de RRHH.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(14, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBorrarLote);
            this.groupBox1.Controls.Add(this.btnVerLote);
            this.groupBox1.Controls.Add(this.cboLotesGenerados);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 166);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccionar lote: ";
            // 
            // btnBorrarLote
            // 
            this.btnBorrarLote.Location = new System.Drawing.Point(188, 99);
            this.btnBorrarLote.Name = "btnBorrarLote";
            this.btnBorrarLote.Size = new System.Drawing.Size(155, 23);
            this.btnBorrarLote.TabIndex = 5;
            this.btnBorrarLote.Text = "Borrar Lote";
            this.btnBorrarLote.UseVisualStyleBackColor = true;
            this.btnBorrarLote.Click += new System.EventHandler(this.btnBorrarLote_Click);
            // 
            // btnVerLote
            // 
            this.btnVerLote.Location = new System.Drawing.Point(26, 99);
            this.btnVerLote.Name = "btnVerLote";
            this.btnVerLote.Size = new System.Drawing.Size(155, 23);
            this.btnVerLote.TabIndex = 4;
            this.btnVerLote.Text = "Ver Lote";
            this.btnVerLote.UseVisualStyleBackColor = true;
            this.btnVerLote.Click += new System.EventHandler(this.btnVerLote_Click);
            // 
            // cboLotesGenerados
            // 
            this.cboLotesGenerados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLotesGenerados.FormattingEnabled = true;
            this.cboLotesGenerados.Location = new System.Drawing.Point(26, 49);
            this.cboLotesGenerados.Name = "cboLotesGenerados";
            this.cboLotesGenerados.Size = new System.Drawing.Size(317, 21);
            this.cboLotesGenerados.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Lotes:";
            // 
            // btnGenLoteImp
            // 
            this.btnGenLoteImp.Location = new System.Drawing.Point(105, 290);
            this.btnGenLoteImp.Name = "btnGenLoteImp";
            this.btnGenLoteImp.Size = new System.Drawing.Size(170, 31);
            this.btnGenLoteImp.TabIndex = 5;
            this.btnGenLoteImp.Text = "Grabar accesos en DB RRHH";
            this.btnGenLoteImp.UseVisualStyleBackColor = true;
            this.btnGenLoteImp.Click += new System.EventHandler(this.btnGenLoteImp_Click);
            // 
            // btnInfoCnn
            // 
            this.btnInfoCnn.Location = new System.Drawing.Point(105, 253);
            this.btnInfoCnn.Name = "btnInfoCnn";
            this.btnInfoCnn.Size = new System.Drawing.Size(170, 31);
            this.btnInfoCnn.TabIndex = 6;
            this.btnInfoCnn.Text = "Ver Info Conexión";
            this.btnInfoCnn.UseVisualStyleBackColor = true;
            this.btnInfoCnn.Click += new System.EventHandler(this.btnInfoCnn_Click);
            // 
            // tmr_Grabar
            // 
            this.tmr_Grabar.Interval = 500;
            this.tmr_Grabar.Tick += new System.EventHandler(this.tmr_Grabar_Tick);
            // 
            // pbarGrabar
            // 
            this.pbarGrabar.Location = new System.Drawing.Point(13, 338);
            this.pbarGrabar.Name = "pbarGrabar";
            this.pbarGrabar.Size = new System.Drawing.Size(362, 23);
            this.pbarGrabar.TabIndex = 7;
            this.pbarGrabar.Visible = false;
            // 
            // frmExportar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 373);
            this.Controls.Add(this.pbarGrabar);
            this.Controls.Add(this.btnInfoCnn);
            this.Controls.Add(this.btnGenLoteImp);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmExportar";
            this.Text = "Grabar Lote de Accesos";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboLotesGenerados;
        private System.Windows.Forms.Button btnGenLoteImp;
        private System.Windows.Forms.Button btnInfoCnn;
        private System.Windows.Forms.Button btnBorrarLote;
        private System.Windows.Forms.Button btnVerLote;
        private System.Windows.Forms.Timer tmr_Grabar;
        private System.Windows.Forms.ProgressBar pbarGrabar;
    }
}