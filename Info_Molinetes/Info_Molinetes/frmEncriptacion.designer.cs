namespace Info_Molinetes
{
    partial class frmEncriptacion
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtOriginal = new System.Windows.Forms.TextBox();
            this.txtEncriptado = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDesencriptado = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtMD5 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Texto original:";
            // 
            // txtOriginal
            // 
            this.txtOriginal.Location = new System.Drawing.Point(18, 35);
            this.txtOriginal.Name = "txtOriginal";
            this.txtOriginal.Size = new System.Drawing.Size(256, 20);
            this.txtOriginal.TabIndex = 1;
            // 
            // txtEncriptado
            // 
            this.txtEncriptado.Location = new System.Drawing.Point(18, 87);
            this.txtEncriptado.Name = "txtEncriptado";
            this.txtEncriptado.ReadOnly = true;
            this.txtEncriptado.Size = new System.Drawing.Size(256, 20);
            this.txtEncriptado.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Texto encriptado";
            // 
            // txtDesencriptado
            // 
            this.txtDesencriptado.Location = new System.Drawing.Point(19, 139);
            this.txtDesencriptado.Name = "txtDesencriptado";
            this.txtDesencriptado.ReadOnly = true;
            this.txtDesencriptado.Size = new System.Drawing.Size(256, 20);
            this.txtDesencriptado.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Texto desencriptado";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(199, 245);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtMD5
            // 
            this.txtMD5.Location = new System.Drawing.Point(19, 196);
            this.txtMD5.Name = "txtMD5";
            this.txtMD5.ReadOnly = true;
            this.txtMD5.Size = new System.Drawing.Size(256, 20);
            this.txtMD5.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "MD5";
            // 
            // frmEncriptacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 291);
            this.Controls.Add(this.txtMD5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtDesencriptado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEncriptado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOriginal);
            this.Controls.Add(this.label1);
            this.Name = "frmEncriptacion";
            this.Text = "Encriptacion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOriginal;
        private System.Windows.Forms.TextBox txtEncriptado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDesencriptado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtMD5;
        private System.Windows.Forms.Label label4;
    }
}

