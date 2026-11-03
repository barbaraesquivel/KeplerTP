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
            lblEstado = new Label();
            lblEnergia = new Label();
            barEnergia = new ProgressBar();
            lstSecuencia = new ListBox();
            btnVolver = new Button();
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
            btnIniciarTurno.Location = new Point(30, 80);
            btnIniciarTurno.Name = "btnIniciarTurno";
            btnIniciarTurno.Size = new Size(160, 35);
            btnIniciarTurno.Text = "Iniciar turno";
            btnIniciarTurno.UseVisualStyleBackColor = true;
            btnIniciarTurno.Click += btnIniciarTurno_Click;
            //
            // btnEmergencia
            //
            btnEmergencia.Location = new Point(200, 80);
            btnEmergencia.Name = "btnEmergencia";
            btnEmergencia.Size = new Size(160, 35);
            btnEmergencia.Text = "Emergencia";
            btnEmergencia.UseVisualStyleBackColor = true;
            btnEmergencia.Click += btnEmergencia_Click;
            //
            // btnApagar
            //
            btnApagar.Location = new Point(370, 80);
            btnApagar.Name = "btnApagar";
            btnApagar.Size = new Size(160, 35);
            btnApagar.Text = "Apagar estación";
            btnApagar.UseVisualStyleBackColor = true;
            btnApagar.Click += btnApagar_Click;
            //
            // lblEstado
            //
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblEstado.Location = new Point(30, 135);
            lblEstado.Name = "lblEstado";
            lblEstado.Text = "Estado: Apagada";
            //
            // barEnergia
            //
            barEnergia.Location = new Point(30, 175);
            barEnergia.Maximum = 100;
            barEnergia.Minimum = 0;
            barEnergia.Name = "barEnergia";
            barEnergia.Size = new Size(400, 25);
            //
            // lblEnergia
            //
            lblEnergia.AutoSize = true;
            lblEnergia.Location = new Point(440, 180);
            lblEnergia.Name = "lblEnergia";
            lblEnergia.Text = "Energía: 0";
            //
            // lstSecuencia
            //
            lstSecuencia.FormattingEnabled = true;
            lstSecuencia.ItemHeight = 15;
            lstSecuencia.Location = new Point(30, 215);
            lstSecuencia.Name = "lstSecuencia";
            lstSecuencia.Size = new Size(500, 154);
            //
            // btnVolver
            //
            btnVolver.Location = new Point(30, 385);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(160, 35);
            btnVolver.Text = "Volver al hub";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            //
            // PantallaControlCentral
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblTitulo);
            Controls.Add(btnIniciarTurno);
            Controls.Add(btnEmergencia);
            Controls.Add(btnApagar);
            Controls.Add(lblEstado);
            Controls.Add(barEnergia);
            Controls.Add(lblEnergia);
            Controls.Add(lstSecuencia);
            Controls.Add(btnVolver);
            Name = "PantallaControlCentral";
            Size = new Size(800, 450);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Button btnIniciarTurno;
        private Button btnEmergencia;
        private Button btnApagar;
        private Label lblEstado;
        private Label lblEnergia;
        private ProgressBar barEnergia;
        private ListBox lstSecuencia;
        private Button btnVolver;
    }
}
