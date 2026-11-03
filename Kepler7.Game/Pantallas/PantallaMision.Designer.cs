namespace Kepler7.Game.Pantallas
{
    partial class PantallaMision
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
            lblObjetivo = new Label();
            lblNave = new Label();
            btnComenzar = new Button();
            btnVolver = new Button();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.Location = new Point(30, 30);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Text = "Misión";
            //
            // lblObjetivo
            //
            lblObjetivo.AutoSize = true;
            lblObjetivo.Location = new Point(30, 90);
            lblObjetivo.Name = "lblObjetivo";
            lblObjetivo.Text = "Objetivo:";
            //
            // lblNave
            //
            lblNave.AutoSize = true;
            lblNave.Location = new Point(30, 120);
            lblNave.Name = "lblNave";
            lblNave.Text = "Nave:";
            //
            // btnComenzar
            //
            btnComenzar.Location = new Point(30, 165);
            btnComenzar.Name = "btnComenzar";
            btnComenzar.Size = new Size(160, 35);
            btnComenzar.Text = "Comenzar combate";
            btnComenzar.UseVisualStyleBackColor = true;
            btnComenzar.Click += btnComenzar_Click;
            //
            // btnVolver
            //
            btnVolver.Location = new Point(30, 215);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(160, 35);
            btnVolver.Text = "Volver al hub";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            //
            // PantallaMision
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblTitulo);
            Controls.Add(lblObjetivo);
            Controls.Add(lblNave);
            Controls.Add(btnComenzar);
            Controls.Add(btnVolver);
            Name = "PantallaMision";
            Size = new Size(800, 450);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblObjetivo;
        private Label lblNave;
        private Button btnComenzar;
        private Button btnVolver;
    }
}
