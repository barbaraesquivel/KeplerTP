namespace Kepler7.Game.Pantallas
{
    partial class PantallaCombate
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
            panelEscenario = new PanelEscenario();
            btnAtacar = new Button();
            btnIzquierda = new Button();
            btnArriba = new Button();
            btnAbajo = new Button();
            btnDerecha = new Button();
            btnTurnoEnemigo = new Button();
            btnVolver = new Button();
            lblMensaje = new Label();
            btnCurar = new Button();
            btnConstruir = new Button();
            btnDeshacer = new Button();
            btnRehacer = new Button();
            lblBase = new Label();
            lstHistorial = new ListBox();
            SuspendLayout();
            //
            // panelEscenario
            //
            panelEscenario.BackColor = Color.FromArgb(20, 20, 40);
            panelEscenario.Location = new Point(10, 10);
            panelEscenario.Name = "panelEscenario";
            panelEscenario.Size = new Size(401, 241);
            panelEscenario.TabIndex = 0;
            panelEscenario.Paint += panelEscenario_Paint;
            //
            // btnAtacar
            //
            btnAtacar.Location = new Point(10, 260);
            btnAtacar.Name = "btnAtacar";
            btnAtacar.Size = new Size(80, 30);
            btnAtacar.TabIndex = 1;
            btnAtacar.Text = "Atacar";
            btnAtacar.UseVisualStyleBackColor = true;
            btnAtacar.Click += btnAtacar_Click;
            //
            // btnIzquierda
            //
            btnIzquierda.Location = new Point(100, 260);
            btnIzquierda.Name = "btnIzquierda";
            btnIzquierda.Size = new Size(35, 30);
            btnIzquierda.TabIndex = 2;
            btnIzquierda.Text = "←";
            btnIzquierda.UseVisualStyleBackColor = true;
            btnIzquierda.Click += btnIzquierda_Click;
            //
            // btnArriba
            //
            btnArriba.Location = new Point(140, 260);
            btnArriba.Name = "btnArriba";
            btnArriba.Size = new Size(35, 30);
            btnArriba.TabIndex = 3;
            btnArriba.Text = "↑";
            btnArriba.UseVisualStyleBackColor = true;
            btnArriba.Click += btnArriba_Click;
            //
            // btnAbajo
            //
            btnAbajo.Location = new Point(180, 260);
            btnAbajo.Name = "btnAbajo";
            btnAbajo.Size = new Size(35, 30);
            btnAbajo.TabIndex = 4;
            btnAbajo.Text = "↓";
            btnAbajo.UseVisualStyleBackColor = true;
            btnAbajo.Click += btnAbajo_Click;
            //
            // btnDerecha
            //
            btnDerecha.Location = new Point(220, 260);
            btnDerecha.Name = "btnDerecha";
            btnDerecha.Size = new Size(35, 30);
            btnDerecha.TabIndex = 5;
            btnDerecha.Text = "→";
            btnDerecha.UseVisualStyleBackColor = true;
            btnDerecha.Click += btnDerecha_Click;
            //
            // btnTurnoEnemigo
            //
            btnTurnoEnemigo.Location = new Point(265, 260);
            btnTurnoEnemigo.Name = "btnTurnoEnemigo";
            btnTurnoEnemigo.Size = new Size(146, 30);
            btnTurnoEnemigo.TabIndex = 6;
            btnTurnoEnemigo.Text = "Turno enemigo";
            btnTurnoEnemigo.UseVisualStyleBackColor = true;
            btnTurnoEnemigo.Click += btnTurnoEnemigo_Click;
            //
            // lblMensaje
            //
            lblMensaje.Location = new Point(10, 335);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(401, 45);
            lblMensaje.TabIndex = 7;
            lblMensaje.Text = "¡Comienza el combate!";
            //
            // btnVolver
            //
            btnVolver.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnVolver.Location = new Point(20, 505);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(160, 35);
            btnVolver.TabIndex = 8;
            btnVolver.Text = "Volver al hub";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            //
            // btnCurar
            //
            btnCurar.Location = new Point(10, 297);
            btnCurar.Name = "btnCurar";
            btnCurar.Size = new Size(80, 30);
            btnCurar.TabIndex = 9;
            btnCurar.Text = "Curar";
            btnCurar.UseVisualStyleBackColor = true;
            btnCurar.Click += btnCurar_Click;
            //
            // btnConstruir
            //
            btnConstruir.Location = new Point(100, 297);
            btnConstruir.Name = "btnConstruir";
            btnConstruir.Size = new Size(110, 30);
            btnConstruir.TabIndex = 10;
            btnConstruir.Text = "Construir torreta";
            btnConstruir.UseVisualStyleBackColor = true;
            btnConstruir.Click += btnConstruir_Click;
            //
            // btnDeshacer
            //
            btnDeshacer.Location = new Point(220, 297);
            btnDeshacer.Name = "btnDeshacer";
            btnDeshacer.Size = new Size(90, 30);
            btnDeshacer.TabIndex = 11;
            btnDeshacer.Text = "Deshacer";
            btnDeshacer.UseVisualStyleBackColor = true;
            btnDeshacer.Click += btnDeshacer_Click;
            //
            // btnRehacer
            //
            btnRehacer.Location = new Point(320, 297);
            btnRehacer.Name = "btnRehacer";
            btnRehacer.Size = new Size(91, 30);
            btnRehacer.TabIndex = 12;
            btnRehacer.Text = "Rehacer";
            btnRehacer.UseVisualStyleBackColor = true;
            btnRehacer.Click += btnRehacer_Click;
            //
            // lblBase
            //
            lblBase.Location = new Point(10, 385);
            lblBase.Name = "lblBase";
            lblBase.Size = new Size(401, 20);
            lblBase.TabIndex = 13;
            lblBase.Text = "Recursos: 0";
            //
            // lstHistorial
            //
            lstHistorial.FormattingEnabled = true;
            lstHistorial.ItemHeight = 15;
            lstHistorial.Location = new Point(190, 450);
            lstHistorial.Name = "lstHistorial";
            lstHistorial.Size = new Size(600, 100);
            lstHistorial.TabIndex = 14;
            //
            // PantallaCombate
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelEscenario);
            Controls.Add(btnAtacar);
            Controls.Add(btnIzquierda);
            Controls.Add(btnArriba);
            Controls.Add(btnAbajo);
            Controls.Add(btnDerecha);
            Controls.Add(btnTurnoEnemigo);
            Controls.Add(lblMensaje);
            Controls.Add(btnVolver);
            Controls.Add(btnCurar);
            Controls.Add(btnConstruir);
            Controls.Add(btnDeshacer);
            Controls.Add(btnRehacer);
            Controls.Add(lblBase);
            Controls.Add(lstHistorial);
            Name = "PantallaCombate";
            Size = new Size(800, 560);
            ResumeLayout(false);
        }

        #endregion

        private PanelEscenario panelEscenario;
        private Button btnAtacar;
        private Button btnIzquierda;
        private Button btnArriba;
        private Button btnAbajo;
        private Button btnDerecha;
        private Button btnTurnoEnemigo;
        private Button btnVolver;
        private Label lblMensaje;
        private Button btnCurar;
        private Button btnConstruir;
        private Button btnDeshacer;
        private Button btnRehacer;
        private Label lblBase;
        private ListBox lstHistorial;
    }
}
