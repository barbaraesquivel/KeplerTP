namespace Kepler7.Game.Pantallas
{
    partial class PantallaHangar
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
            lblReceta = new Label();
            cmbReceta = new ComboBox();
            btnCompleta = new Button();
            btnBasica = new Button();
            txtDescripcion = new TextBox();
            panelAtributos = new Panel();
            btnUsar = new Button();
            lblAviso = new Label();
            btnVolver = new Button();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.Location = new Point(30, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Text = "Hangar";
            //
            // lblReceta
            //
            lblReceta.AutoSize = true;
            lblReceta.Location = new Point(30, 83);
            lblReceta.Name = "lblReceta";
            lblReceta.Text = "Receta:";
            //
            // cmbReceta
            //
            cmbReceta.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbReceta.Items.AddRange(new object[] { "Exploradora", "Combate", "Carga" });
            cmbReceta.Location = new Point(90, 80);
            cmbReceta.Name = "cmbReceta";
            cmbReceta.Size = new Size(180, 23);
            //
            // btnCompleta
            //
            btnCompleta.Location = new Point(30, 115);
            btnCompleta.Name = "btnCompleta";
            btnCompleta.Size = new Size(200, 35);
            btnCompleta.Text = "Construir nave completa";
            btnCompleta.UseVisualStyleBackColor = true;
            btnCompleta.Click += btnCompleta_Click;
            //
            // btnBasica
            //
            btnBasica.Location = new Point(240, 115);
            btnBasica.Name = "btnBasica";
            btnBasica.Size = new Size(200, 35);
            btnBasica.Text = "Construir nave básica";
            btnBasica.UseVisualStyleBackColor = true;
            btnBasica.Click += btnBasica_Click;
            //
            // txtDescripcion
            //
            txtDescripcion.Location = new Point(30, 165);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.ReadOnly = true;
            txtDescripcion.ScrollBars = ScrollBars.Vertical;
            txtDescripcion.Size = new Size(410, 200);
            //
            // panelAtributos
            //
            panelAtributos.BorderStyle = BorderStyle.FixedSingle;
            panelAtributos.Location = new Point(460, 165);
            panelAtributos.Name = "panelAtributos";
            panelAtributos.Size = new Size(310, 200);
            panelAtributos.Paint += panelAtributos_Paint;
            //
            // btnUsar
            //
            btnUsar.Location = new Point(30, 380);
            btnUsar.Name = "btnUsar";
            btnUsar.Size = new Size(200, 35);
            btnUsar.Text = "Usar esta nave";
            btnUsar.UseVisualStyleBackColor = true;
            btnUsar.Click += btnUsar_Click;
            //
            // lblAviso
            //
            lblAviso.AutoSize = true;
            lblAviso.Location = new Point(240, 390);
            lblAviso.Name = "lblAviso";
            lblAviso.Text = "";
            //
            // btnVolver
            //
            btnVolver.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnVolver.Location = new Point(20, 505);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(160, 35);
            btnVolver.Text = "Volver al hub";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            //
            // PantallaHangar
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblTitulo);
            Controls.Add(lblReceta);
            Controls.Add(cmbReceta);
            Controls.Add(btnCompleta);
            Controls.Add(btnBasica);
            Controls.Add(txtDescripcion);
            Controls.Add(panelAtributos);
            Controls.Add(btnUsar);
            Controls.Add(lblAviso);
            Controls.Add(btnVolver);
            Name = "PantallaHangar";
            Size = new Size(800, 560);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblReceta;
        private ComboBox cmbReceta;
        private Button btnCompleta;
        private Button btnBasica;
        private TextBox txtDescripcion;
        private Panel panelAtributos;
        private Button btnUsar;
        private Label lblAviso;
        private Button btnVolver;
    }
}
