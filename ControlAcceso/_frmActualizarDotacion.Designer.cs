namespace ControlAcceso
{
    partial class frmActualizarDotacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmActualizarDotacion));
            this.timerSincronizar = new System.Windows.Forms.Timer(this.components);
            this.btnActualizarBase = new System.Windows.Forms.Button();
            this.txtDetalle = new System.Windows.Forms.TextBox();
            this.pgbActualizar = new System.Windows.Forms.ProgressBar();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblPorcentaje = new System.Windows.Forms.Label();
            this.btnDetalle = new System.Windows.Forms.Button();
            this.lblTiempoEst = new System.Windows.Forms.Label();
            this.lblDetReg = new System.Windows.Forms.Label();
            this.lblRestantes = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timerSincronizar
            // 
            this.timerSincronizar.Interval = 50;
            this.timerSincronizar.Tick += new System.EventHandler(this.timerSincronizar_Tick);
            // 
            // btnActualizarBase
            // 
            this.btnActualizarBase.BackColor = System.Drawing.Color.White;
            this.btnActualizarBase.Location = new System.Drawing.Point(364, 80);
            this.btnActualizarBase.Name = "btnActualizarBase";
            this.btnActualizarBase.Size = new System.Drawing.Size(160, 33);
            this.btnActualizarBase.TabIndex = 0;
            this.btnActualizarBase.Text = "Actualizar Base de Datos";
            this.btnActualizarBase.UseVisualStyleBackColor = false;
            this.btnActualizarBase.Click += new System.EventHandler(this.btnActualizarBase_Click);
            // 
            // txtDetalle
            // 
            this.txtDetalle.Location = new System.Drawing.Point(12, 195);
            this.txtDetalle.Multiline = true;
            this.txtDetalle.Name = "txtDetalle";
            this.txtDetalle.ReadOnly = true;
            this.txtDetalle.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDetalle.Size = new System.Drawing.Size(515, 334);
            this.txtDetalle.TabIndex = 1;
            this.txtDetalle.TextChanged += new System.EventHandler(this.txtDetalle_TextChanged);
            // 
            // pgbActualizar
            // 
            this.pgbActualizar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pgbActualizar.ForeColor = System.Drawing.Color.LightGreen;
            this.pgbActualizar.Location = new System.Drawing.Point(12, 47);
            this.pgbActualizar.Name = "pgbActualizar";
            this.pgbActualizar.Size = new System.Drawing.Size(512, 27);
            this.pgbActualizar.TabIndex = 2;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(9, 8);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(515, 13);
            this.lblTitulo.TabIndex = 3;
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPorcentaje
            // 
            this.lblPorcentaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPorcentaje.Location = new System.Drawing.Point(9, 21);
            this.lblPorcentaje.Name = "lblPorcentaje";
            this.lblPorcentaje.Size = new System.Drawing.Size(515, 23);
            this.lblPorcentaje.TabIndex = 4;
            this.lblPorcentaje.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnDetalle
            // 
            this.btnDetalle.BackColor = System.Drawing.Color.White;
            this.btnDetalle.Enabled = false;
            this.btnDetalle.Location = new System.Drawing.Point(198, 80);
            this.btnDetalle.Name = "btnDetalle";
            this.btnDetalle.Size = new System.Drawing.Size(160, 33);
            this.btnDetalle.TabIndex = 5;
            this.btnDetalle.Text = "Ver Detalles >>";
            this.btnDetalle.UseVisualStyleBackColor = false;
            this.btnDetalle.Click += new System.EventHandler(this.btnDetalle_Click);
            // 
            // lblTiempoEst
            // 
            this.lblTiempoEst.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiempoEst.Location = new System.Drawing.Point(14, 145);
            this.lblTiempoEst.Name = "lblTiempoEst";
            this.lblTiempoEst.Size = new System.Drawing.Size(515, 13);
            this.lblTiempoEst.TabIndex = 6;
            this.lblTiempoEst.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDetReg
            // 
            this.lblDetReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetReg.Location = new System.Drawing.Point(14, 126);
            this.lblDetReg.Name = "lblDetReg";
            this.lblDetReg.Size = new System.Drawing.Size(515, 13);
            this.lblDetReg.TabIndex = 7;
            this.lblDetReg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRestantes
            // 
            this.lblRestantes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRestantes.Location = new System.Drawing.Point(14, 164);
            this.lblRestantes.Name = "lblRestantes";
            this.lblRestantes.Size = new System.Drawing.Size(515, 13);
            this.lblRestantes.TabIndex = 8;
            this.lblRestantes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(515, 13);
            this.label1.TabIndex = 8;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmSincronizarBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(536, 534);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblRestantes);
            this.Controls.Add(this.lblDetReg);
            this.Controls.Add(this.lblTiempoEst);
            this.Controls.Add(this.btnDetalle);
            this.Controls.Add(this.lblPorcentaje);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pgbActualizar);
            this.Controls.Add(this.txtDetalle);
            this.Controls.Add(this.btnActualizarBase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSincronizarBD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Actualizar Dotación";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSincronizarBD_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerSincronizar;
        private System.Windows.Forms.Button btnActualizarBase;
        private System.Windows.Forms.TextBox txtDetalle;
        private System.Windows.Forms.ProgressBar pgbActualizar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblPorcentaje;
        private System.Windows.Forms.Button btnDetalle;
        private System.Windows.Forms.Label lblTiempoEst;
        private System.Windows.Forms.Label lblDetReg;
        private System.Windows.Forms.Label lblRestantes;
        private System.Windows.Forms.Label label1;
    }
}