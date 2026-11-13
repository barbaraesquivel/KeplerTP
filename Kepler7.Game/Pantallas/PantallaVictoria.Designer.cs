namespace Kepler7.Game.Pantallas
{
    partial class PantallaVictoria
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
            components = new System.ComponentModel.Container();
            lblTitulo = new Label();
            lblRecompensas = new Label();
            lblTotal = new Label();
            lblSubioNivel = new Label();
            btnContinuar = new Button();
            timerTitulo = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(90, 220, 140);
            lblTitulo.Location = new Point(30, 30);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Text = "¡Misión cumplida!";
            //
            // lblRecompensas
            //
            lblRecompensas.AutoSize = true;
            lblRecompensas.Font = new Font("Segoe UI", 12F);
            lblRecompensas.Location = new Point(30, 95);
            lblRecompensas.Name = "lblRecompensas";
            lblRecompensas.Text = "Recompensas:";
            //
            // lblTotal
            //
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 11F);
            lblTotal.Location = new Point(30, 125);
            lblTotal.Name = "lblTotal";
            lblTotal.Text = "Nivel 1 - XP 0/100 - Monedas totales 0";
            //
            // lblSubioNivel
            //
            lblSubioNivel.AutoSize = true;
            lblSubioNivel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblSubioNivel.ForeColor = Color.DarkOrange;
            lblSubioNivel.Location = new Point(30, 155);
            lblSubioNivel.Name = "lblSubioNivel";
            lblSubioNivel.Text = "¡Subiste de nivel!";
            lblSubioNivel.Visible = false;
            //
            // btnContinuar
            //
            btnContinuar.Location = new Point(30, 195);
            btnContinuar.Name = "btnContinuar";
            btnContinuar.Size = new Size(160, 35);
            btnContinuar.Text = "Continuar";
            btnContinuar.UseVisualStyleBackColor = true;
            btnContinuar.Click += btnContinuar_Click;
            //
            // timerTitulo
            //
            timerTitulo.Interval = 400;
            timerTitulo.Tick += timerTitulo_Tick;
            //
            // PantallaVictoria
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblTitulo);
            Controls.Add(lblRecompensas);
            Controls.Add(lblTotal);
            Controls.Add(lblSubioNivel);
            Controls.Add(btnContinuar);
            Name = "PantallaVictoria";
            Size = new Size(800, 450);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblRecompensas;
        private Label lblTotal;
        private Label lblSubioNivel;
        private Button btnContinuar;
        private System.Windows.Forms.Timer timerTitulo;
    }
}
