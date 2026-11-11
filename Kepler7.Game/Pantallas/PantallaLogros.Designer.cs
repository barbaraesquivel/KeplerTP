namespace Kepler7.Game.Pantallas
{
    partial class PantallaLogros
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
            lblContador = new Label();
            pnlLogros = new Panel();
            lblPatron = new Label();
            cmbPatron = new ComboBox();
            btnDesbloquear = new Button();
            btnReiniciar = new Button();
            btnVolver = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.Location = new Point(30, 18);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(360, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Logros de Patrones de Diseño";
            // 
            // lblContador
            // 
            lblContador.AutoSize = true;
            lblContador.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblContador.ForeColor = Color.FromArgb(90, 220, 140);
            lblContador.Location = new Point(30, 56);
            lblContador.Name = "lblContador";
            lblContador.Size = new Size(235, 20);
            lblContador.TabIndex = 1;
            lblContador.Text = "Logros desbloqueados: 0 / 12";
            // 
            // pnlLogros
            // 
            pnlLogros.AutoScroll = true;
            pnlLogros.BackColor = Color.White;
            pnlLogros.BorderStyle = BorderStyle.FixedSingle;
            pnlLogros.Location = new Point(30, 84);
            pnlLogros.Name = "pnlLogros";
            pnlLogros.Size = new Size(740, 375);
            pnlLogros.TabIndex = 2;
            // 
            // lblPatron
            // 
            lblPatron.AutoSize = true;
            lblPatron.Location = new Point(30, 475);
            lblPatron.Name = "lblPatron";
            lblPatron.Size = new Size(92, 15);
            lblPatron.TabIndex = 3;
            lblPatron.Text = "Simular patrón:";
            // 
            // cmbPatron
            // 
            cmbPatron.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPatron.FormattingEnabled = true;
            cmbPatron.Location = new Point(128, 471);
            cmbPatron.Name = "cmbPatron";
            cmbPatron.Size = new Size(200, 23);
            cmbPatron.TabIndex = 4;
            // 
            // btnDesbloquear
            // 
            btnDesbloquear.Location = new Point(338, 469);
            btnDesbloquear.Name = "btnDesbloquear";
            btnDesbloquear.Size = new Size(180, 28);
            btnDesbloquear.TabIndex = 5;
            btnDesbloquear.Text = "Registrar uso de patrón";
            btnDesbloquear.UseVisualStyleBackColor = true;
            btnDesbloquear.Click += btnDesbloquear_Click;
            // 
            // btnReiniciar
            // 
            btnReiniciar.Location = new Point(528, 469);
            btnReiniciar.Name = "btnReiniciar";
            btnReiniciar.Size = new Size(140, 28);
            btnReiniciar.TabIndex = 6;
            btnReiniciar.Text = "Reiniciar logros";
            btnReiniciar.UseVisualStyleBackColor = true;
            btnReiniciar.Click += btnReiniciar_Click;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(30, 512);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(160, 35);
            btnVolver.TabIndex = 7;
            btnVolver.Text = "Volver al hub";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // PantallaLogros
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblTitulo);
            Controls.Add(lblContador);
            Controls.Add(pnlLogros);
            Controls.Add(lblPatron);
            Controls.Add(cmbPatron);
            Controls.Add(btnDesbloquear);
            Controls.Add(btnReiniciar);
            Controls.Add(btnVolver);
            Name = "PantallaLogros";
            Size = new Size(800, 565);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblContador;
        private Panel pnlLogros;
        private Label lblPatron;
        private ComboBox cmbPatron;
        private Button btnDesbloquear;
        private Button btnReiniciar;
        private Button btnVolver;
    }
}
