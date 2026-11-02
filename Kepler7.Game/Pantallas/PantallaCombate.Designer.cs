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
            panelEscenario = new Panel();
            btnAtacar = new Button();
            btnIzquierda = new Button();
            btnArriba = new Button();
            btnAbajo = new Button();
            btnDerecha = new Button();
            btnTurnoEnemigo = new Button();
            btnVolver = new Button();
            lblMensaje = new Label();
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
            lblMensaje.Location = new Point(10, 300);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(401, 100);
            lblMensaje.TabIndex = 7;
            lblMensaje.Text = "¡Comienza el combate!";
            //
            // btnVolver
            //
            btnVolver.Location = new Point(10, 410);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(100, 30);
            btnVolver.TabIndex = 8;
            btnVolver.Text = "Volver";
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
            Controls.Add(lblMensaje);
            Controls.Add(btnVolver);
            Name = "PantallaCombate";
            Size = new Size(800, 450);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelEscenario;
        private Button btnAtacar;
        private Button btnIzquierda;
        private Button btnArriba;
        private Button btnAbajo;
        private Button btnDerecha;
        private Button btnTurnoEnemigo;
        private Button btnVolver;
        private Label lblMensaje;
    }
}
