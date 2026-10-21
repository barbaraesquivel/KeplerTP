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
            btnMision = new Button();
            btnSalir = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.Location = new Point(30, 30);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Text = "Hub de la estación";
            // 
            // btnMision
            // 
            btnMision.Location = new Point(30, 100);
            btnMision.Name = "btnMision";
            btnMision.Size = new Size(160, 35);
            btnMision.Text = "Ir a la misión";
            btnMision.UseVisualStyleBackColor = true;
            btnMision.Click += btnMision_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(30, 150);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(160, 35);
            btnSalir.Text = "Salir al inicio";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // PantallaHub
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblTitulo);
            Controls.Add(btnMision);
            Controls.Add(btnSalir);
            Name = "PantallaHub";
            Size = new Size(800, 450);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Button btnMision;
        private Button btnSalir;
    }
}
