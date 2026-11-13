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
            lblObjetivos = new Label();
            lblK7 = new Label();
            btnHackear = new Button();
            lblModificadores = new Label();
            SuspendLayout();
            // 
            // panelEscenario
            // 
            panelEscenario.BackColor = Color.FromArgb(20, 20, 40);
            panelEscenario.Location = new Point(15, 12);
            panelEscenario.Name = "panelEscenario";
            panelEscenario.Size = new Size(401, 241);
            panelEscenario.TabIndex = 0;
            panelEscenario.Paint += panelEscenario_Paint;
            // 
            // btnAtacar
            // 
            btnAtacar.Location = new Point(15, 259);
            btnAtacar.Name = "btnAtacar";
            btnAtacar.Size = new Size(75, 32);
            btnAtacar.TabIndex = 1;
            btnAtacar.Text = "Atacar";
            btnAtacar.UseVisualStyleBackColor = true;
            btnAtacar.Click += btnAtacar_Click;
            // 
            // btnIzquierda
            // 
            btnIzquierda.Location = new Point(94, 259);
            btnIzquierda.Name = "btnIzquierda";
            btnIzquierda.Size = new Size(34, 32);
            btnIzquierda.TabIndex = 2;
            btnIzquierda.Text = "←";
            btnIzquierda.UseVisualStyleBackColor = true;
            btnIzquierda.Click += btnIzquierda_Click;
            // 
            // btnArriba
            // 
            btnArriba.Location = new Point(132, 259);
            btnArriba.Name = "btnArriba";
            btnArriba.Size = new Size(34, 32);
            btnArriba.TabIndex = 3;
            btnArriba.Text = "↑";
            btnArriba.UseVisualStyleBackColor = true;
            btnArriba.Click += btnArriba_Click;
            // 
            // btnAbajo
            // 
            btnAbajo.Location = new Point(170, 259);
            btnAbajo.Name = "btnAbajo";
            btnAbajo.Size = new Size(34, 32);
            btnAbajo.TabIndex = 4;
            btnAbajo.Text = "↓";
            btnAbajo.UseVisualStyleBackColor = true;
            btnAbajo.Click += btnAbajo_Click;
            // 
            // btnDerecha
            // 
            btnDerecha.Location = new Point(208, 259);
            btnDerecha.Name = "btnDerecha";
            btnDerecha.Size = new Size(34, 32);
            btnDerecha.TabIndex = 5;
            btnDerecha.Text = "→";
            btnDerecha.UseVisualStyleBackColor = true;
            btnDerecha.Click += btnDerecha_Click;
            // 
            // btnTurnoEnemigo
            // 
            btnTurnoEnemigo.Location = new Point(248, 259);
            btnTurnoEnemigo.Name = "btnTurnoEnemigo";
            btnTurnoEnemigo.Size = new Size(168, 32);
            btnTurnoEnemigo.TabIndex = 6;
            btnTurnoEnemigo.Text = "Turno enemigo";
            btnTurnoEnemigo.UseVisualStyleBackColor = true;
            btnTurnoEnemigo.Click += btnTurnoEnemigo_Click;
            // 
            // btnCurar
            // 
            btnCurar.Location = new Point(15, 296);
            btnCurar.Name = "btnCurar";
            btnCurar.Size = new Size(75, 30);
            btnCurar.TabIndex = 9;
            btnCurar.Text = "Curar";
            btnCurar.UseVisualStyleBackColor = true;
            btnCurar.Click += btnCurar_Click;
            // 
            // btnConstruir
            // 
            btnConstruir.Location = new Point(94, 296);
            btnConstruir.Name = "btnConstruir";
            btnConstruir.Size = new Size(110, 30);
            btnConstruir.TabIndex = 10;
            btnConstruir.Text = "Construir torreta";
            btnConstruir.UseVisualStyleBackColor = true;
            btnConstruir.Click += btnConstruir_Click;
            // 
            // btnDeshacer
            // 
            btnDeshacer.Location = new Point(208, 296);
            btnDeshacer.Name = "btnDeshacer";
            btnDeshacer.Size = new Size(100, 30);
            btnDeshacer.TabIndex = 11;
            btnDeshacer.Text = "Deshacer";
            btnDeshacer.UseVisualStyleBackColor = true;
            btnDeshacer.Click += btnDeshacer_Click;
            // 
            // btnRehacer
            // 
            btnRehacer.Location = new Point(312, 296);
            btnRehacer.Name = "btnRehacer";
            btnRehacer.Size = new Size(104, 30);
            btnRehacer.TabIndex = 12;
            btnRehacer.Text = "Rehacer";
            btnRehacer.UseVisualStyleBackColor = true;
            btnRehacer.Click += btnRehacer_Click;
            // 
            // lblMensaje
            // 
            lblMensaje.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMensaje.Location = new Point(15, 332);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(401, 22);
            lblMensaje.TabIndex = 7;
            lblMensaje.Text = "¡Comienza el combate!";
            // 
            // lblK7
            // 
            lblK7.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblK7.ForeColor = Color.FromArgb(230, 80, 80);
            lblK7.Location = new Point(15, 522);
            lblK7.Name = "lblK7";
            lblK7.Size = new Size(401, 44);
            lblK7.TabIndex = 21;
            lblK7.Text = "K-7 usa: IAAgresiva";
            lblK7.Visible = false;
            // 
            // btnHackear
            // 
            btnHackear.Location = new Point(185, 482);
            btnHackear.Name = "btnHackear";
            btnHackear.Size = new Size(180, 34);
            btnHackear.TabIndex = 22;
            btnHackear.Text = "Hackear IA";
            btnHackear.UseVisualStyleBackColor = true;
            btnHackear.Visible = false;
            btnHackear.Click += btnHackear_Click;
            // 
            // lblModificadores
            // 
            lblModificadores.BorderStyle = BorderStyle.FixedSingle;
            lblModificadores.Font = new Font("Segoe UI", 9F);
            lblModificadores.ForeColor = Color.FromArgb(90, 220, 140);
            lblModificadores.Location = new Point(425, 432);
            lblModificadores.Name = "lblModificadores";
            lblModificadores.Padding = new Padding(4);
            lblModificadores.Size = new Size(370, 190);
            lblModificadores.TabIndex = 23;
            lblModificadores.Text = "Modificadores";
            lblModificadores.Visible = false;
            // 
            // lblObjetivos
            // 
            lblObjetivos.BorderStyle = BorderStyle.FixedSingle;
            lblObjetivos.Font = new Font("Segoe UI", 9F);
            lblObjetivos.ForeColor = Color.FromArgb(255, 220, 130);
            lblObjetivos.Location = new Point(425, 432);
            lblObjetivos.Name = "lblObjetivos";
            lblObjetivos.Padding = new Padding(4);
            lblObjetivos.Size = new Size(370, 92);
            lblObjetivos.TabIndex = 20;
            lblObjetivos.Text = "Objetivos";
            // 
            // lblBase
            // 
            lblBase.Location = new Point(15, 356);
            lblBase.Name = "lblBase";
            lblBase.Size = new Size(401, 20);
            lblBase.TabIndex = 13;
            lblBase.Text = "Recursos: 0";
            // 
            // lstHistorial
            // 
            lstHistorial.FormattingEnabled = true;
            lstHistorial.ItemHeight = 15;
            lstHistorial.Location = new Point(15, 380);
            lstHistorial.Name = "lstHistorial";
            lstHistorial.Size = new Size(401, 94);
            lstHistorial.TabIndex = 14;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(15, 482);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(160, 34);
            btnVolver.TabIndex = 8;
            btnVolver.Text = "Abandonar";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
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
            Controls.Add(btnCurar);
            Controls.Add(btnConstruir);
            Controls.Add(btnDeshacer);
            Controls.Add(btnRehacer);
            Controls.Add(lblMensaje);
            Controls.Add(lblBase);
            Controls.Add(lstHistorial);
            Controls.Add(btnVolver);
            Controls.Add(lblObjetivos);
            Controls.Add(lblK7);
            Controls.Add(btnHackear);
            Controls.Add(lblModificadores);
            Name = "PantallaCombate";
            Size = new Size(810, 630);
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
        private Button btnCurar;
        private Button btnConstruir;
        private Button btnDeshacer;
        private Button btnRehacer;
        private Label lblMensaje;
        private Label lblBase;
        private ListBox lstHistorial;
        private Button btnVolver;
        private Label lblObjetivos;
        private Label lblK7;
        private Button btnHackear;
        private Label lblModificadores;
    }
}
