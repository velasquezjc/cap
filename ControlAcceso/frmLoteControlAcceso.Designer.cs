namespace ControlAcceso
{
    partial class frmLoteControlAcceso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoteControlAcceso));
            this.dgvLote = new System.Windows.Forms.DataGridView();
            this.lblNroLote = new System.Windows.Forms.Label();
            this.txtNroLote = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLote)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLote
            // 
            this.dgvLote.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLote.Location = new System.Drawing.Point(12, 52);
            this.dgvLote.Name = "dgvLote";
            this.dgvLote.ReadOnly = true;
            this.dgvLote.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLote.Size = new System.Drawing.Size(707, 517);
            this.dgvLote.TabIndex = 2;
            // 
            // lblNroLote
            // 
            this.lblNroLote.AutoSize = true;
            this.lblNroLote.Location = new System.Drawing.Point(197, 22);
            this.lblNroLote.Name = "lblNroLote";
            this.lblNroLote.Size = new System.Drawing.Size(86, 13);
            this.lblNroLote.TabIndex = 3;
            this.lblNroLote.Text = "Número de Lote:";
            // 
            // txtNroLote
            // 
            this.txtNroLote.Location = new System.Drawing.Point(289, 19);
            this.txtNroLote.Name = "txtNroLote";
            this.txtNroLote.ReadOnly = true;
            this.txtNroLote.Size = new System.Drawing.Size(227, 20);
            this.txtNroLote.TabIndex = 4;
            // 
            // frmLoteControlAcceso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 591);
            this.Controls.Add(this.txtNroLote);
            this.Controls.Add(this.lblNroLote);
            this.Controls.Add(this.dgvLote);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmLoteControlAcceso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle Lote Control de Acceso";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLote)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLote;
        private System.Windows.Forms.Label lblNroLote;
        private System.Windows.Forms.TextBox txtNroLote;
    }
}