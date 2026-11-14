namespace Kepler7.Game.Pantallas
{
    partial class PantallaControlCentral
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
            btnIniciarTurno = new Button();
            btnEmergencia = new Button();
            btnApagar = new Button();
            btnSalirEmergencia = new Button();
            lblEstado = new Label();
            lblEnergia = new Label();
            barEnergia = new ProgressBar();
            lstSecuencia = new ListBox();
            btnContinuar = new Button();
            lblHistoria = new Label();
            lblAyudaIniciar = new Label();
            lblAyudaEmergencia = new Label();
            lblAyudaApagar = new Label();
            lblAyudaSalir = new Label();
            lblTituloSecuencia = new Label();
            lblTituloEfecto = new Label();
            lblEfecto = new Label();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.Location = new Point(30, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Text = "Control Central";
            //
            // btnIniciarTurno
            //
            btnIniciarTurno.Location = new Point(30, 130);
            btnIniciarTurno.Name = "btnIniciarTurno";
            btnIniciarTurno.Size = new Size(160, 35);
            btnIniciarTurno.Text = "Iniciar turno";
            btnIniciarTurno.UseVisualStyleBackColor = true;
            btnIniciarTurno.Click += btnIniciarTurno_Click;
            //
            // btnEmergencia
            //
            btnEmergencia.Location = new Point(200, 130);
            btnEmergencia.Name = "btnEmergencia";
            btnEmergencia.Size = new Size(160, 35);
            btnEmergencia.Text = "Emergencia";
            btnEmergencia.UseVisualStyleBackColor = true;
            btnEmergencia.Click += btnEmergencia_Click;
            //
            // btnApagar
            //
            btnApagar.Location = new Point(370, 130);
            btnApagar.Name = "btnApagar";
            btnApagar.Size = new Size(160, 35);
            btnApagar.Text = "Apagar estación";
            btnApagar.UseVisualStyleBackColor = true;
            btnApagar.Click += btnApagar_Click;
            //
            // btnSalirEmergencia
            //
            btnSalirEmergencia.Location = new Point(540, 130);
            btnSalirEmergencia.Name = "btnSalirEmergencia";
            btnSalirEmergencia.Size = new Size(180, 35);
            btnSalirEmergencia.Text = "Salir de emergencia";
            btnSalirEmergencia.UseVisualStyleBackColor = true;
            btnSalirEmergencia.Click += btnSalirEmergencia_Click;
            //
            // lblEstado
            //
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblEstado.Location = new Point(30, 205);
            lblEstado.Name = "lblEstado";
            lblEstado.Text = "Estado: Apagada";
            //
            // barEnergia
            //
            barEnergia.Location = new Point(30, 240);
            barEnergia.Maximum = 100;
            barEnergia.Minimum = 0;
            barEnergia.Name = "barEnergia";
            barEnergia.Size = new Size(400, 25);
            //
            // lblEnergia
            //
            lblEnergia.AutoSize = true;
            lblEnergia.Location = new Point(440, 245);
            lblEnergia.Name = "lblEnergia";
            lblEnergia.Text = "Energía: 0";
            //
            // lstSecuencia
            //
            lstSecuencia.FormattingEnabled = true;
            lstSecuencia.ItemHeight = 15;
            lstSecuencia.Location = new Point(30, 300);
            lstSecuencia.Name = "lstSecuencia";
            lstSecuencia.Size = new Size(470, 154);
            //
            // btnContinuar
            //
            btnContinuar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnContinuar.Location = new Point(20, 555);
            btnContinuar.Name = "btnContinuar";
            btnContinuar.Size = new Size(160, 35);
            btnContinuar.Text = "Continuar";
            btnContinuar.Enabled = false;
            btnContinuar.UseVisualStyleBackColor = true;
            btnContinuar.Click += btnContinuar_Click;
            // 
            // lblHistoria
            // 
            lblHistoria.BorderStyle = BorderStyle.FixedSingle;
            lblHistoria.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic);
            lblHistoria.ForeColor = Color.FromArgb(255, 220, 130);
            lblHistoria.Location = new Point(30, 62);
            lblHistoria.Name = "lblHistoria";
            lblHistoria.Padding = new Padding(4);
            lblHistoria.Size = new Size(740, 56);
            lblHistoria.TabIndex = 50;
            lblHistoria.Text = "Historia del capítulo";
            //
            // lblAyudaIniciar
            //
            lblAyudaIniciar.Font = new Font("Segoe UI", 8F);
            lblAyudaIniciar.Location = new Point(30, 168);
            lblAyudaIniciar.Name = "lblAyudaIniciar";
            lblAyudaIniciar.Size = new Size(160, 32);
            lblAyudaIniciar.Text = "Enciende los 6 subsistemas (−10 energía)";
            //
            // lblAyudaEmergencia
            //
            lblAyudaEmergencia.Font = new Font("Segoe UI", 8F);
            lblAyudaEmergencia.Location = new Point(200, 168);
            lblAyudaEmergencia.Name = "lblAyudaEmergencia";
            lblAyudaEmergencia.Size = new Size(160, 32);
            lblAyudaEmergencia.Text = "Activa alarma y defensas (−25 energía)";
            //
            // lblAyudaApagar
            //
            lblAyudaApagar.Font = new Font("Segoe UI", 8F);
            lblAyudaApagar.Location = new Point(370, 168);
            lblAyudaApagar.Name = "lblAyudaApagar";
            lblAyudaApagar.Size = new Size(160, 32);
            lblAyudaApagar.Text = "Apaga todo, sin costo. K-7 ataca +2";
            //
            // lblAyudaSalir
            //
            lblAyudaSalir.Font = new Font("Segoe UI", 8F);
            lblAyudaSalir.Location = new Point(540, 168);
            lblAyudaSalir.Name = "lblAyudaSalir";
            lblAyudaSalir.Size = new Size(180, 32);
            lblAyudaSalir.Text = "Desactiva defensas y vuelve a Normal (sin costo)";
            //
            // lblTituloSecuencia
            //
            lblTituloSecuencia.AutoSize = true;
            lblTituloSecuencia.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTituloSecuencia.Location = new Point(30, 278);
            lblTituloSecuencia.Name = "lblTituloSecuencia";
            lblTituloSecuencia.Text = "Lo que hizo la fachada (un botón, varios subsistemas):";
            //
            // lblTituloEfecto
            //
            lblTituloEfecto.AutoSize = true;
            lblTituloEfecto.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTituloEfecto.Location = new Point(515, 278);
            lblTituloEfecto.Name = "lblTituloEfecto";
            lblTituloEfecto.Text = "Efecto en el combate final";
            //
            // lblEfecto
            //
            lblEfecto.BorderStyle = BorderStyle.FixedSingle;
            lblEfecto.Location = new Point(515, 300);
            lblEfecto.Name = "lblEfecto";
            lblEfecto.Padding = new Padding(4);
            lblEfecto.Size = new Size(255, 154);
            lblEfecto.Text = "";
            //
            // PantallaControlCentral
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblHistoria);
            Controls.Add(lblTitulo);
            Controls.Add(btnIniciarTurno);
            Controls.Add(btnEmergencia);
            Controls.Add(btnApagar);
            Controls.Add(btnSalirEmergencia);
            Controls.Add(lblEstado);
            Controls.Add(barEnergia);
            Controls.Add(lblEnergia);
            Controls.Add(lstSecuencia);
            Controls.Add(btnContinuar);
            Controls.Add(lblAyudaIniciar);
            Controls.Add(lblAyudaEmergencia);
            Controls.Add(lblAyudaApagar);
            Controls.Add(lblAyudaSalir);
            Controls.Add(lblTituloSecuencia);
            Controls.Add(lblTituloEfecto);
            Controls.Add(lblEfecto);
            Name = "PantallaControlCentral";
            Size = new Size(800, 610);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Button btnIniciarTurno;
        private Button btnEmergencia;
        private Button btnApagar;
        private Button btnSalirEmergencia;
        private Label lblEstado;
        private Label lblEnergia;
        private ProgressBar barEnergia;
        private ListBox lstSecuencia;
        private Button btnContinuar;
        private Label lblHistoria;
        private Label lblAyudaIniciar;
        private Label lblAyudaEmergencia;
        private Label lblAyudaApagar;
        private Label lblAyudaSalir;
        private Label lblTituloSecuencia;
        private Label lblTituloEfecto;
        private Label lblEfecto;
    }
}
