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
            lblProgreso = new Label();
            lblCapitulo = new Label();
            lblHistoria = new Label();
            lblDecisiones = new Label();
            lstDecisiones = new ListBox();
            lblLogros = new Label();
            lblFaltan = new Label();
            btnIrCapitulo = new Button();
            btnLogros = new Button();
            btnSalir = new Button();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.Location = new Point(30, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(240, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Diario de misión";
            //
            // lblProgreso
            //
            lblProgreso.AutoSize = true;
            lblProgreso.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblProgreso.ForeColor = Color.FromArgb(90, 220, 140);
            lblProgreso.Location = new Point(430, 32);
            lblProgreso.Name = "lblProgreso";
            lblProgreso.Size = new Size(260, 20);
            lblProgreso.TabIndex = 1;
            lblProgreso.Text = "Nivel 1  |  XP 0/100  |  Monedas 0";
            //
            // lblCapitulo
            //
            lblCapitulo.AutoSize = true;
            lblCapitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblCapitulo.ForeColor = Color.FromArgb(0, 200, 255);
            lblCapitulo.Location = new Point(30, 72);
            lblCapitulo.Name = "lblCapitulo";
            lblCapitulo.Size = new Size(260, 25);
            lblCapitulo.TabIndex = 2;
            lblCapitulo.Text = "Capítulo 1 de 11: Hangar";
            //
            // lblHistoria
            //
            lblHistoria.BorderStyle = BorderStyle.FixedSingle;
            lblHistoria.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblHistoria.Location = new Point(30, 105);
            lblHistoria.Name = "lblHistoria";
            lblHistoria.Padding = new Padding(6);
            lblHistoria.Size = new Size(740, 85);
            lblHistoria.TabIndex = 3;
            lblHistoria.Text = "Historia del capítulo";
            //
            // lblDecisiones
            //
            lblDecisiones.AutoSize = true;
            lblDecisiones.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDecisiones.Location = new Point(30, 202);
            lblDecisiones.Name = "lblDecisiones";
            lblDecisiones.Size = new Size(260, 19);
            lblDecisiones.TabIndex = 4;
            lblDecisiones.Text = "Decisiones tomadas y su efecto en el final:";
            //
            // lstDecisiones
            //
            lstDecisiones.FormattingEnabled = true;
            lstDecisiones.HorizontalScrollbar = true;
            lstDecisiones.ItemHeight = 15;
            lstDecisiones.Location = new Point(30, 225);
            lstDecisiones.Name = "lstDecisiones";
            lstDecisiones.Size = new Size(740, 154);
            lstDecisiones.TabIndex = 5;
            //
            // lblLogros
            //
            lblLogros.AutoSize = true;
            lblLogros.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblLogros.Location = new Point(30, 465);
            lblLogros.Name = "lblLogros";
            lblLogros.Size = new Size(100, 19);
            lblLogros.TabIndex = 6;
            lblLogros.Text = "Logros: 0 / 12";
            // 
            // lblFaltan
            // 
            lblFaltan.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblFaltan.ForeColor = Color.FromArgb(230, 80, 80);
            lblFaltan.Location = new Point(30, 386);
            lblFaltan.Name = "lblFaltan";
            lblFaltan.Size = new Size(740, 74);
            lblFaltan.TabIndex = 10;
            lblFaltan.Text = "";
            //
            // btnIrCapitulo
            //
            btnIrCapitulo.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnIrCapitulo.Location = new Point(30, 495);
            btnIrCapitulo.Name = "btnIrCapitulo";
            btnIrCapitulo.Size = new Size(420, 55);
            btnIrCapitulo.TabIndex = 7;
            btnIrCapitulo.Text = "Ir a: Hangar";
            btnIrCapitulo.UseVisualStyleBackColor = true;
            btnIrCapitulo.Click += btnIrCapitulo_Click;
            //
            // btnLogros
            //
            btnLogros.Location = new Point(470, 505);
            btnLogros.Name = "btnLogros";
            btnLogros.Size = new Size(140, 35);
            btnLogros.TabIndex = 8;
            btnLogros.Text = "Ver logros";
            btnLogros.UseVisualStyleBackColor = true;
            btnLogros.Click += btnLogros_Click;
            //
            // btnSalir
            //
            btnSalir.Location = new Point(630, 505);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(140, 35);
            btnSalir.TabIndex = 9;
            btnSalir.Text = "Salir al inicio";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            //
            // PantallaHub
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblTitulo);
            Controls.Add(lblProgreso);
            Controls.Add(lblCapitulo);
            Controls.Add(lblHistoria);
            Controls.Add(lblDecisiones);
            Controls.Add(lstDecisiones);
            Controls.Add(lblLogros);
            Controls.Add(lblFaltan);
            Controls.Add(btnIrCapitulo);
            Controls.Add(btnLogros);
            Controls.Add(btnSalir);
            Name = "PantallaHub";
            Size = new Size(800, 570);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblProgreso;
        private Label lblCapitulo;
        private Label lblHistoria;
        private Label lblDecisiones;
        private ListBox lstDecisiones;
        private Label lblLogros;
        private Label lblFaltan;
        private Button btnIrCapitulo;
        private Button btnLogros;
        private Button btnSalir;
    }
}
