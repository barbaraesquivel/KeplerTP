namespace Kepler7.Game.Pantallas
{
    partial class PantallaHub
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            btnHangar = new Button();
            btnLaboratorio = new Button();
            btnControlCentral = new Button();
            btnCenso = new Button();
            btnBoveda = new Button();
            btnInventario = new Button();
            btnMision = new Button();
            btnSalir = new Button();
            btnComunicaciones = new Button();
            btnEstrategiaIA = new Button();
            btnTurnos = new Button();
            btnLogros = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.Location = new Point(30, 30);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(254, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Hub de la estación";
            // 
            // btnHangar
            // 
            btnHangar.Location = new Point(30, 90);
            btnHangar.Name = "btnHangar";
            btnHangar.Size = new Size(300, 35);
            btnHangar.TabIndex = 1;
            btnHangar.Text = "Hangar: construir tu nave";
            btnHangar.UseVisualStyleBackColor = true;
            btnHangar.Click += btnHangar_Click;
            // 
            // btnLaboratorio
            // 
            btnLaboratorio.Location = new Point(30, 135);
            btnLaboratorio.Name = "btnLaboratorio";
            btnLaboratorio.Size = new Size(300, 35);
            btnLaboratorio.TabIndex = 2;
            btnLaboratorio.Text = "Laboratorio: clonar tripulantes";
            btnLaboratorio.UseVisualStyleBackColor = true;
            btnLaboratorio.Click += btnLaboratorio_Click;
            // 
            // btnControlCentral
            // 
            btnControlCentral.Location = new Point(30, 180);
            btnControlCentral.Name = "btnControlCentral";
            btnControlCentral.Size = new Size(300, 35);
            btnControlCentral.TabIndex = 3;
            btnControlCentral.Text = "Control Central: manejar la estación";
            btnControlCentral.UseVisualStyleBackColor = true;
            btnControlCentral.Click += btnControlCentral_Click;
            // 
            // btnCenso
            // 
            btnCenso.Location = new Point(30, 225);
            btnCenso.Name = "btnCenso";
            btnCenso.Size = new Size(300, 35);
            btnCenso.TabIndex = 4;
            btnCenso.Text = "Censo: especies de la tripulación";
            btnCenso.UseVisualStyleBackColor = true;
            btnCenso.Click += btnCenso_Click;
            // 
            // btnBoveda
            // 
            btnBoveda.Location = new Point(30, 270);
            btnBoveda.Name = "btnBoveda";
            btnBoveda.Size = new Size(300, 35);
            btnBoveda.TabIndex = 5;
            btnBoveda.Text = "Bóveda: datos con acceso restringido";
            btnBoveda.UseVisualStyleBackColor = true;
            btnBoveda.Click += btnBoveda_Click;
            // 
            // btnInventario
            // 
            btnInventario.Location = new Point(30, 315);
            btnInventario.Name = "btnInventario";
            btnInventario.Size = new Size(300, 35);
            btnInventario.TabIndex = 6;
            btnInventario.Text = "Inventario: valor y reporte de ítems";
            btnInventario.UseVisualStyleBackColor = true;
            btnInventario.Click += btnInventario_Click;
            // 
            // btnMision
            // 
            btnMision.Location = new Point(30, 360);
            btnMision.Name = "btnMision";
            btnMision.Size = new Size(300, 35);
            btnMision.TabIndex = 7;
            btnMision.Text = "Misión: combate contra los aliens";
            btnMision.UseVisualStyleBackColor = true;
            btnMision.Click += btnMision_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(30, 553);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(300, 35);
            btnSalir.TabIndex = 8;
            btnSalir.Text = "Salir al inicio";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnComunicaciones
            // 
            btnComunicaciones.Location = new Point(30, 405);
            btnComunicaciones.Name = "btnComunicaciones";
            btnComunicaciones.Size = new Size(300, 35);
            btnComunicaciones.TabIndex = 9;
            btnComunicaciones.Text = "Comunicaciones";
            btnComunicaciones.UseVisualStyleBackColor = true;
            btnComunicaciones.Click += btnComunicaciones_Click;
            // 
            // btnEstrategiaIA
            // 
            btnEstrategiaIA.Location = new Point(30, 450);
            btnEstrategiaIA.Name = "btnEstrategiaIA";
            btnEstrategiaIA.Size = new Size(300, 35);
            btnEstrategiaIA.TabIndex = 9;
            btnEstrategiaIA.Text = "EstrategiaIA";
            btnEstrategiaIA.UseVisualStyleBackColor = true;
            btnEstrategiaIA.Click += btnEstrategiaIA_Click;
            // 
            // btnTurnos
            // 
            btnTurnos.Location = new Point(30, 495);
            btnTurnos.Name = "btnTurnos";
            btnTurnos.Size = new Size(300, 35);
            btnTurnos.TabIndex = 9;
            btnTurnos.Text = "Turnos";
            btnTurnos.UseVisualStyleBackColor = true;
            btnTurnos.Click += btnTurnos_Click;
            // 
            // btnLogros
            // 
            btnLogros.Location = new Point(360, 90);
            btnLogros.Name = "btnLogros";
            btnLogros.Size = new Size(300, 35);
            btnLogros.TabIndex = 10;
            btnLogros.Text = "Logros: patrones desbloqueados";
            btnLogros.UseVisualStyleBackColor = true;
            btnLogros.Click += btnLogros_Click;
            // 
            // PantallaHub
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnLogros);
            Controls.Add(btnTurnos);
            Controls.Add(btnEstrategiaIA);
            Controls.Add(btnComunicaciones);
            Controls.Add(lblTitulo);
            Controls.Add(btnHangar);
            Controls.Add(btnLaboratorio);
            Controls.Add(btnControlCentral);
            Controls.Add(btnCenso);
            Controls.Add(btnBoveda);
            Controls.Add(btnInventario);
            Controls.Add(btnMision);
            Controls.Add(btnSalir);
            Name = "PantallaHub";
            Size = new Size(800, 617);
            Load += PantallaHub_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Button btnHangar;
        private Button btnLaboratorio;
        private Button btnControlCentral;
        private Button btnCenso;
        private Button btnBoveda;
        private Button btnInventario;
        private Button btnMision;
        private Button btnSalir;
        private Button btnComunicaciones;
        private Button btnEstrategiaIA;
        private Button btnTurnos;
        private Button btnLogros;
    }
}
