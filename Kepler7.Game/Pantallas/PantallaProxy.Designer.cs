namespace Kepler7.Game.Pantallas
{
    partial class PantallaProxy
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitulo = new Label();
            label2 = new Label();
            txtUsuario = new TextBox();
            label1 = new Label();
            cmbRol = new ComboBox();
            lblArchivo = new Label();
            cmbArchivo = new ComboBox();
            btnLeer = new Button();
            btnEscribir = new Button();
            lblContenido = new Label();
            txtResultado = new TextBox();
            lblRutaLog = new Label();
            lstLogs = new ListBox();
            btnRecargarLogs = new Button();
            btnLimpiarLogs = new Button();
            btnVolver = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitulo.Location = new Point(25, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(460, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Bóveda de Datos de la Estación - Patrón Proxy";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 52);
            label2.Name = "label2";
            label2.Size = new Size(62, 20);
            label2.TabIndex = 1;
            label2.Text = "Usuario:";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(90, 48);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(160, 27);
            txtUsuario.TabIndex = 2;
            txtUsuario.Text = "Elena Vega";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(270, 52);
            label1.Name = "label1";
            label1.Size = new Size(34, 20);
            label1.TabIndex = 3;
            label1.Text = "Rol:";
            // 
            // cmbRol
            // 
            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRol.FormattingEnabled = true;
            cmbRol.Items.AddRange(new object[] { "Capitán", "Oficial de Seguridad", "Ingeniero", "Tripulante", "Cocinero" });
            cmbRol.Location = new Point(310, 48);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(170, 28);
            cmbRol.TabIndex = 4;
            // 
            // lblArchivo
            // 
            lblArchivo.AutoSize = true;
            lblArchivo.Location = new Point(25, 90);
            lblArchivo.Name = "lblArchivo";
            lblArchivo.Size = new Size(62, 20);
            lblArchivo.TabIndex = 5;
            lblArchivo.Text = "Archivo:";
            // 
            // cmbArchivo
            // 
            cmbArchivo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbArchivo.FormattingEnabled = true;
            cmbArchivo.Items.AddRange(new object[] { "coordenadas_salto.dat", "codigos_autodestruccion.enc", "manifiesto_carga.log" });
            cmbArchivo.Location = new Point(90, 86);
            cmbArchivo.Name = "cmbArchivo";
            cmbArchivo.Size = new Size(220, 28);
            cmbArchivo.TabIndex = 6;
            // 
            // btnLeer
            // 
            btnLeer.BackColor = Color.LightSteelBlue;
            btnLeer.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLeer.Location = new Point(320, 85);
            btnLeer.Name = "btnLeer";
            btnLeer.Size = new Size(130, 30);
            btnLeer.TabIndex = 7;
            btnLeer.Text = "Leer Archivo";
            btnLeer.UseVisualStyleBackColor = false;
            btnLeer.Click += btnLeer_Click;
            // 
            // btnEscribir
            // 
            btnEscribir.Location = new Point(458, 85);
            btnEscribir.Name = "btnEscribir";
            btnEscribir.Size = new Size(130, 30);
            btnEscribir.TabIndex = 8;
            btnEscribir.Text = "Escribir Archivo";
            btnEscribir.UseVisualStyleBackColor = true;
            btnEscribir.Click += btnEscribir_Click;
            // 
            // lblContenido
            // 
            lblContenido.AutoSize = true;
            lblContenido.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblContenido.Location = new Point(25, 126);
            lblContenido.Name = "lblContenido";
            lblContenido.Size = new Size(224, 20);
            lblContenido.TabIndex = 9;
            lblContenido.Text = "Contenido / Estado de Bóveda:";
            // 
            // txtResultado
            // 
            txtResultado.BackColor = Color.White;
            txtResultado.Font = new Font("Consolas", 9F);
            txtResultado.Location = new Point(25, 149);
            txtResultado.Multiline = true;
            txtResultado.Name = "txtResultado";
            txtResultado.ScrollBars = ScrollBars.Vertical;
            txtResultado.Size = new Size(720, 75);
            txtResultado.TabIndex = 10;
            // 
            // lblRutaLog
            // 
            lblRutaLog.AutoSize = true;
            lblRutaLog.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblRutaLog.ForeColor = Color.DarkSlateGray;
            lblRutaLog.Location = new Point(25, 233);
            lblRutaLog.Name = "lblRutaLog";
            lblRutaLog.Size = new Size(420, 19);
            lblRutaLog.TabIndex = 11;
            lblRutaLog.Text = "Registro persistente cargado desde %AppData%\\Kepler7\\registro_boveda.log";
            // 
            // lstLogs
            // 
            lstLogs.Font = new Font("Consolas", 8.5F);
            lstLogs.FormattingEnabled = true;
            lstLogs.ItemHeight = 17;
            lstLogs.Location = new Point(25, 256);
            lstLogs.Name = "lstLogs";
            lstLogs.Size = new Size(720, 174);
            lstLogs.TabIndex = 12;
            // 
            // btnRecargarLogs
            // 
            btnRecargarLogs.Location = new Point(220, 442);
            btnRecargarLogs.Name = "btnRecargarLogs";
            btnRecargarLogs.Size = new Size(130, 36);
            btnRecargarLogs.TabIndex = 13;
            btnRecargarLogs.Text = "Recargar Logs";
            btnRecargarLogs.UseVisualStyleBackColor = true;
            btnRecargarLogs.Click += btnRecargarLogs_Click;
            // 
            // btnLimpiarLogs
            // 
            btnLimpiarLogs.Location = new Point(360, 442);
            btnLimpiarLogs.Name = "btnLimpiarLogs";
            btnLimpiarLogs.Size = new Size(130, 36);
            btnLimpiarLogs.TabIndex = 14;
            btnLimpiarLogs.Text = "Borrar Registro";
            btnLimpiarLogs.UseVisualStyleBackColor = true;
            btnLimpiarLogs.Click += btnLimpiarLogs_Click;
            // 
            // btnVolver
            // 
            btnVolver.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnVolver.Location = new Point(25, 442);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(180, 36);
            btnVolver.TabIndex = 15;
            btnVolver.Text = "Volver al hub";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // PantallaProxy
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnLimpiarLogs);
            Controls.Add(btnRecargarLogs);
            Controls.Add(btnVolver);
            Controls.Add(lstLogs);
            Controls.Add(lblRutaLog);
            Controls.Add(txtResultado);
            Controls.Add(lblContenido);
            Controls.Add(btnEscribir);
            Controls.Add(btnLeer);
            Controls.Add(cmbArchivo);
            Controls.Add(lblArchivo);
            Controls.Add(cmbRol);
            Controls.Add(label1);
            Controls.Add(txtUsuario);
            Controls.Add(label2);
            Controls.Add(lblTitulo);
            Name = "PantallaProxy";
            Size = new Size(770, 495);
            Load += PantallaProxy_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label label2;
        private TextBox txtUsuario;
        private Label label1;
        private ComboBox cmbRol;
        private Label lblArchivo;
        private ComboBox cmbArchivo;
        private Button btnLeer;
        private Button btnEscribir;
        private Label lblContenido;
        private TextBox txtResultado;
        private Label lblRutaLog;
        private ListBox lstLogs;
        private Button btnRecargarLogs;
        private Button btnLimpiarLogs;
        private Button btnVolver;
    }
}
