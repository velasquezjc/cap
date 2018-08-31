namespace ControlAcceso
{
    partial class frmMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            this.btnRegistrarAcceso = new System.Windows.Forms.Button();
            this.btnSincronizar = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.configuraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uRLWebRRHHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurarProxyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reestablecerValoresPorDefectoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnInformarNovedades = new System.Windows.Forms.Button();
            this.btnEdificios = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSincBack = new System.Windows.Forms.Button();
            this.timerBackground = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtProvincia = new System.Windows.Forms.TextBox();
            this.txtLocalidad = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRegistrarAcceso
            // 
            this.btnRegistrarAcceso.BackColor = System.Drawing.Color.SteelBlue;
            this.btnRegistrarAcceso.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarAcceso.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarAcceso.Location = new System.Drawing.Point(68, 227);
            this.btnRegistrarAcceso.Name = "btnRegistrarAcceso";
            this.btnRegistrarAcceso.Size = new System.Drawing.Size(175, 46);
            this.btnRegistrarAcceso.TabIndex = 0;
            this.btnRegistrarAcceso.Text = "Registrar Acceso";
            this.btnRegistrarAcceso.UseVisualStyleBackColor = false;
            this.btnRegistrarAcceso.Click += new System.EventHandler(this.btnCargarAsistencia_Click);
            // 
            // btnSincronizar
            // 
            this.btnSincronizar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSincronizar.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSincronizar.ForeColor = System.Drawing.Color.White;
            this.btnSincronizar.Location = new System.Drawing.Point(68, 279);
            this.btnSincronizar.Name = "btnSincronizar";
            this.btnSincronizar.Size = new System.Drawing.Size(175, 46);
            this.btnSincronizar.TabIndex = 1;
            this.btnSincronizar.Text = "Actualizar Dotación";
            this.btnSincronizar.UseVisualStyleBackColor = false;
            this.btnSincronizar.Click += new System.EventHandler(this.btnInformar_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuraciónToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(507, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // configuraciónToolStripMenuItem
            // 
            this.configuraciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uRLWebRRHHToolStripMenuItem,
            this.configurarProxyToolStripMenuItem,
            this.reestablecerValoresPorDefectoToolStripMenuItem});
            this.configuraciónToolStripMenuItem.Name = "configuraciónToolStripMenuItem";
            this.configuraciónToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.configuraciónToolStripMenuItem.Text = "Opciones";
            // 
            // uRLWebRRHHToolStripMenuItem
            // 
            this.uRLWebRRHHToolStripMenuItem.Enabled = false;
            this.uRLWebRRHHToolStripMenuItem.Name = "uRLWebRRHHToolStripMenuItem";
            this.uRLWebRRHHToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.uRLWebRRHHToolStripMenuItem.Text = "Configurar URL Si.G.I.R.H.";
            this.uRLWebRRHHToolStripMenuItem.Click += new System.EventHandler(this.uRLWebRRHHToolStripMenuItem_Click);
            // 
            // configurarProxyToolStripMenuItem
            // 
            this.configurarProxyToolStripMenuItem.Name = "configurarProxyToolStripMenuItem";
            this.configurarProxyToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.configurarProxyToolStripMenuItem.Text = "Verificar Conexión";
            this.configurarProxyToolStripMenuItem.Click += new System.EventHandler(this.configurarProxyToolStripMenuItem_Click);
            // 
            // reestablecerValoresPorDefectoToolStripMenuItem
            // 
            this.reestablecerValoresPorDefectoToolStripMenuItem.Enabled = false;
            this.reestablecerValoresPorDefectoToolStripMenuItem.Name = "reestablecerValoresPorDefectoToolStripMenuItem";
            this.reestablecerValoresPorDefectoToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.reestablecerValoresPorDefectoToolStripMenuItem.Text = "Restablecer valores por defecto";
            this.reestablecerValoresPorDefectoToolStripMenuItem.Click += new System.EventHandler(this.reestablecerValoresPorDefectoToolStripMenuItem_Click);
            // 
            // btnInformarNovedades
            // 
            this.btnInformarNovedades.BackColor = System.Drawing.Color.SteelBlue;
            this.btnInformarNovedades.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInformarNovedades.ForeColor = System.Drawing.Color.White;
            this.btnInformarNovedades.Location = new System.Drawing.Point(68, 331);
            this.btnInformarNovedades.Name = "btnInformarNovedades";
            this.btnInformarNovedades.Size = new System.Drawing.Size(175, 46);
            this.btnInformarNovedades.TabIndex = 3;
            this.btnInformarNovedades.Text = "Informar Novedades";
            this.btnInformarNovedades.UseVisualStyleBackColor = false;
            this.btnInformarNovedades.Click += new System.EventHandler(this.btnInformarNovedades_Click);
            // 
            // btnEdificios
            // 
            this.btnEdificios.BackColor = System.Drawing.Color.SteelBlue;
            this.btnEdificios.Enabled = false;
            this.btnEdificios.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdificios.ForeColor = System.Drawing.Color.White;
            this.btnEdificios.Location = new System.Drawing.Point(272, 227);
            this.btnEdificios.Name = "btnEdificios";
            this.btnEdificios.Size = new System.Drawing.Size(175, 46);
            this.btnEdificios.TabIndex = 4;
            this.btnEdificios.Text = "Config. Edificio";
            this.btnEdificios.UseVisualStyleBackColor = false;
            this.btnEdificios.Click += new System.EventHandler(this.btnEdificios_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 422);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(507, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(51, 17);
            this.lblStatus.Text = "Estado: -";
            this.lblStatus.Click += new System.EventHandler(this.lblStatus_Click);
            // 
            // btnSincBack
            // 
            this.btnSincBack.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSincBack.Enabled = false;
            this.btnSincBack.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSincBack.ForeColor = System.Drawing.Color.White;
            this.btnSincBack.Location = new System.Drawing.Point(272, 279);
            this.btnSincBack.Name = "btnSincBack";
            this.btnSincBack.Size = new System.Drawing.Size(175, 46);
            this.btnSincBack.TabIndex = 6;
            this.btnSincBack.Text = "Actualización Background";
            this.btnSincBack.UseVisualStyleBackColor = false;
            this.btnSincBack.Click += new System.EventHandler(this.btnSincBack_Click);
            // 
            // timerBackground
            // 
            this.timerBackground.Tick += new System.EventHandler(this.timerBackground_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.txtProvincia);
            this.groupBox2.Controls.Add(this.txtLocalidad);
            this.groupBox2.Controls.Add(this.txtDireccion);
            this.groupBox2.Controls.Add(this.txtNombre);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(479, 171);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Edificio: ";
            // 
            // txtProvincia
            // 
            this.txtProvincia.Location = new System.Drawing.Point(84, 114);
            this.txtProvincia.Name = "txtProvincia";
            this.txtProvincia.ReadOnly = true;
            this.txtProvincia.Size = new System.Drawing.Size(351, 20);
            this.txtProvincia.TabIndex = 15;
            // 
            // txtLocalidad
            // 
            this.txtLocalidad.Location = new System.Drawing.Point(84, 88);
            this.txtLocalidad.Name = "txtLocalidad";
            this.txtLocalidad.ReadOnly = true;
            this.txtLocalidad.Size = new System.Drawing.Size(351, 20);
            this.txtLocalidad.TabIndex = 14;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(83, 62);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.ReadOnly = true;
            this.txtDireccion.Size = new System.Drawing.Size(352, 20);
            this.txtDireccion.TabIndex = 13;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(83, 36);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(352, 20);
            this.txtNombre.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(25, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Provincia";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(25, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Localidad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(25, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Dirección";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(25, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Nombre";
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ControlAcceso.Properties.Resources.ToolbarDegradeMdi_H;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(507, 444);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnSincBack);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnEdificios);
            this.Controls.Add(this.btnInformarNovedades);
            this.Controls.Add(this.btnSincronizar);
            this.Controls.Add(this.btnRegistrarAcceso);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control de Acceso";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRegistrarAcceso;
        private System.Windows.Forms.Button btnSincronizar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem configuraciónToolStripMenuItem;
        private System.Windows.Forms.Button btnInformarNovedades;
        private System.Windows.Forms.Button btnEdificios;
        private System.Windows.Forms.ToolStripMenuItem uRLWebRRHHToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reestablecerValoresPorDefectoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurarProxyToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button btnSincBack;
        private System.Windows.Forms.Timer timerBackground;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtProvincia;
        private System.Windows.Forms.TextBox txtLocalidad;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}