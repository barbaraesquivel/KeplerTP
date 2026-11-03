namespace Kepler7.Game.Pantallas
{
    partial class PantallaTutorial
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
            lblTexto = new Label();
            lblIndicador = new Label();
            btnAnterior = new Button();
            btnSiguiente = new Button();
            btnSaltar = new Button();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.Location = new Point(30, 30);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Text = "Tutorial";
            //
            // lblTexto
            //
            lblTexto.Font = new Font("Segoe UI", 11F);
            lblTexto.Location = new Point(30, 90);
            lblTexto.Name = "lblTexto";
            lblTexto.Size = new Size(600, 220);
            lblTexto.Text = "";
            //
            // lblIndicador
            //
            lblIndicador.AutoSize = true;
            lblIndicador.Location = new Point(30, 330);
            lblIndicador.Name = "lblIndicador";
            lblIndicador.Text = "1/3";
            //
            // btnAnterior
            //
            btnAnterior.Location = new Point(80, 322);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(120, 35);
            btnAnterior.Text = "Anterior";
            btnAnterior.UseVisualStyleBackColor = true;
            btnAnterior.Click += btnAnterior_Click;
            //
            // btnSiguiente
            //
            btnSiguiente.Location = new Point(210, 322);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(120, 35);
            btnSiguiente.Text = "Siguiente";
            btnSiguiente.UseVisualStyleBackColor = true;
            btnSiguiente.Click += btnSiguiente_Click;
            //
            // btnSaltar
            //
            btnSaltar.Location = new Point(340, 322);
            btnSaltar.Name = "btnSaltar";
            btnSaltar.Size = new Size(140, 35);
            btnSaltar.Text = "Saltar tutorial";
            btnSaltar.UseVisualStyleBackColor = true;
            btnSaltar.Click += btnSaltar_Click;
            //
            // PantallaTutorial
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblTitulo);
            Controls.Add(lblTexto);
            Controls.Add(lblIndicador);
            Controls.Add(btnAnterior);
            Controls.Add(btnSiguiente);
            Controls.Add(btnSaltar);
            Name = "PantallaTutorial";
            Size = new Size(800, 450);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblTexto;
        private Label lblIndicador;
        private Button btnAnterior;
        private Button btnSiguiente;
        private Button btnSaltar;
    }
}
