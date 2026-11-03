namespace Kepler7.Game.Pantallas
{
    partial class PantallaDerrota
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
            btnReintentar = new Button();
            btnHub = new Button();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.DarkRed;
            lblTitulo.Location = new Point(30, 30);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Text = "Misión fallida";
            //
            // btnReintentar
            //
            btnReintentar.Location = new Point(30, 100);
            btnReintentar.Name = "btnReintentar";
            btnReintentar.Size = new Size(160, 35);
            btnReintentar.Text = "Reintentar";
            btnReintentar.UseVisualStyleBackColor = true;
            btnReintentar.Click += btnReintentar_Click;
            //
            // btnHub
            //
            btnHub.Location = new Point(200, 100);
            btnHub.Name = "btnHub";
            btnHub.Size = new Size(160, 35);
            btnHub.Text = "Volver al hub";
            btnHub.UseVisualStyleBackColor = true;
            btnHub.Click += btnHub_Click;
            //
            // PantallaDerrota
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblTitulo);
            Controls.Add(btnReintentar);
            Controls.Add(btnHub);
            Name = "PantallaDerrota";
            Size = new Size(800, 450);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Button btnReintentar;
        private Button btnHub;
    }
}
