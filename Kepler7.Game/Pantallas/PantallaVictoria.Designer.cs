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
            btnHub = new Button();
            btnResumen = new Button();
            timerTitulo = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.Green;
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
            // btnHub
            //
            btnHub.Location = new Point(30, 150);
            btnHub.Name = "btnHub";
            btnHub.Size = new Size(160, 35);
            btnHub.Text = "Volver al hub";
            btnHub.UseVisualStyleBackColor = true;
            btnHub.Click += btnHub_Click;
            //
            // btnResumen
            //
            btnResumen.Location = new Point(200, 150);
            btnResumen.Name = "btnResumen";
            btnResumen.Size = new Size(160, 35);
            btnResumen.Text = "Ver resumen final";
            btnResumen.UseVisualStyleBackColor = true;
            btnResumen.Click += btnResumen_Click;
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
            Controls.Add(btnHub);
            Controls.Add(btnResumen);
            Name = "PantallaVictoria";
            Size = new Size(800, 450);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblRecompensas;
        private Button btnHub;
        private Button btnResumen;
        private System.Windows.Forms.Timer timerTitulo;
    }
}
