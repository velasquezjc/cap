namespace ControlAcceso
{
    partial class frmInformarNovedades
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInformarNovedades));
            this.gbFondo = new System.Windows.Forms.GroupBox();
            this.btnInformar = new System.Windows.Forms.Button();
            this.radLotesInformados = new System.Windows.Forms.RadioButton();
            this.radLotesSinInformar = new System.Windows.Forms.RadioButton();
            this.dgvLotes = new System.Windows.Forms.DataGridView();
            this.txtBitcora = new System.Windows.Forms.TextBox();
            this.gbFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLotes)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFondo
            // 
            this.gbFondo.BackgroundImage = global::ControlAcceso.Properties.Resources.ToolbarDegradeMdi_H;
            this.gbFondo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gbFondo.Controls.Add(this.radLotesInformados);
            this.gbFondo.Controls.Add(this.radLotesSinInformar);
            this.gbFondo.Controls.Add(this.dgvLotes);
            this.gbFondo.Controls.Add(this.txtBitcora);
            this.gbFondo.Controls.Add(this.btnInformar);
            this.gbFondo.Location = new System.Drawing.Point(-2, -9);
            this.gbFondo.Name = "gbFondo";
            this.gbFondo.Size = new System.Drawing.Size(573, 492);
            this.gbFondo.TabIndex = 7;
            this.gbFondo.TabStop = false;
            // 
            // btnInformar
            // 
            this.btnInformar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnInformar.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInformar.ForeColor = System.Drawing.Color.White;
            this.btnInformar.Location = new System.Drawing.Point(189, 425);
            this.btnInformar.Name = "btnInformar";
            this.btnInformar.Size = new System.Drawing.Size(214, 35);
            this.btnInformar.TabIndex = 9;
            this.btnInformar.Text = "Informar Registros";
            this.btnInformar.UseVisualStyleBackColor = false;
            this.btnInformar.Click += new System.EventHandler(this.btnInformar_Click);
            // 
            // radLotesInformados
            // 
            this.radLotesInformados.AutoSize = true;
            this.radLotesInformados.BackColor = System.Drawing.Color.Transparent;
            this.radLotesInformados.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLotesInformados.Location = new System.Drawing.Point(301, 25);
            this.radLotesInformados.Name = "radLotesInformados";
            this.radLotesInformados.Size = new System.Drawing.Size(135, 21);
            this.radLotesInformados.TabIndex = 14;
            this.radLotesInformados.Text = "Lotes informados";
            this.radLotesInformados.UseVisualStyleBackColor = false;
            this.radLotesInformados.CheckedChanged += new System.EventHandler(this.radLotesInformados_CheckedChanged);
            // 
            // radLotesSinInformar
            // 
            this.radLotesSinInformar.AutoSize = true;
            this.radLotesSinInformar.BackColor = System.Drawing.Color.Transparent;
            this.radLotesSinInformar.Checked = true;
            this.radLotesSinInformar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLotesSinInformar.Location = new System.Drawing.Point(137, 25);
            this.radLotesSinInformar.Name = "radLotesSinInformar";
            this.radLotesSinInformar.Size = new System.Drawing.Size(139, 21);
            this.radLotesSinInformar.TabIndex = 13;
            this.radLotesSinInformar.TabStop = true;
            this.radLotesSinInformar.Text = "Lotes sin informar";
            this.radLotesSinInformar.UseVisualStyleBackColor = false;
            this.radLotesSinInformar.CheckedChanged += new System.EventHandler(this.radLotesSinInformar_CheckedChanged);
            // 
            // dgvLotes
            // 
            this.dgvLotes.AllowUserToAddRows = false;
            this.dgvLotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLotes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvLotes.Location = new System.Drawing.Point(20, 52);
            this.dgvLotes.Name = "dgvLotes";
            this.dgvLotes.ReadOnly = true;
            this.dgvLotes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLotes.Size = new System.Drawing.Size(517, 199);
            this.dgvLotes.TabIndex = 12;
            this.dgvLotes.DoubleClick += new System.EventHandler(this.dgvLotes_DoubleClick);
            // 
            // txtBitcora
            // 
            this.txtBitcora.Location = new System.Drawing.Point(20, 257);
            this.txtBitcora.Multiline = true;
            this.txtBitcora.Name = "txtBitcora";
            this.txtBitcora.ReadOnly = true;
            this.txtBitcora.Size = new System.Drawing.Size(517, 153);
            this.txtBitcora.TabIndex = 11;
            // 
            // frmInformarNovedades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 479);
            this.Controls.Add(this.gbFondo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmInformarNovedades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informar Novedades";
            this.gbFondo.ResumeLayout(false);
            this.gbFondo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLotes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFondo;
        private System.Windows.Forms.RadioButton radLotesInformados;
        private System.Windows.Forms.RadioButton radLotesSinInformar;
        private System.Windows.Forms.DataGridView dgvLotes;
        private System.Windows.Forms.TextBox txtBitcora;
        private System.Windows.Forms.Button btnInformar;

    }
}