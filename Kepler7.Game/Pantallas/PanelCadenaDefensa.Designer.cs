namespace Kepler7.Game.Pantallas
{
    partial class PanelCadenaDefensa
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
            lstEslabones = new ListBox();
            btnSubir = new Button();
            btnBajar = new Button();
            btnQuitar = new Button();
            cmbTipo = new ComboBox();
            btnAgregar = new Button();
            lblRecorrido = new Label();
            lstRecorrido = new ListBox();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTitulo.Location = new Point(5, 5);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Cadena de defensa (en orden)";
            //
            // lstEslabones
            //
            lstEslabones.ItemHeight = 15;
            lstEslabones.Location = new Point(5, 25);
            lstEslabones.Name = "lstEslabones";
            lstEslabones.Size = new Size(170, 109);
            lstEslabones.TabIndex = 1;
            //
            // btnSubir
            //
            btnSubir.Location = new Point(180, 25);
            btnSubir.Name = "btnSubir";
            btnSubir.Size = new Size(85, 25);
            btnSubir.TabIndex = 2;
            btnSubir.Text = "Subir";
            btnSubir.UseVisualStyleBackColor = true;
            btnSubir.Click += btnSubir_Click;
            //
            // btnBajar
            //
            btnBajar.Location = new Point(180, 55);
            btnBajar.Name = "btnBajar";
            btnBajar.Size = new Size(85, 25);
            btnBajar.TabIndex = 3;
            btnBajar.Text = "Bajar";
            btnBajar.UseVisualStyleBackColor = true;
            btnBajar.Click += btnBajar_Click;
            //
            // btnQuitar
            //
            btnQuitar.Location = new Point(180, 85);
            btnQuitar.Name = "btnQuitar";
            btnQuitar.Size = new Size(85, 25);
            btnQuitar.TabIndex = 4;
            btnQuitar.Text = "Quitar";
            btnQuitar.UseVisualStyleBackColor = true;
            btnQuitar.Click += btnQuitar_Click;
            //
            // cmbTipo
            //
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.Location = new Point(5, 140);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(170, 23);
            cmbTipo.TabIndex = 5;
            //
            // btnAgregar
            //
            btnAgregar.Location = new Point(180, 139);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(85, 25);
            btnAgregar.TabIndex = 6;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            //
            // lblRecorrido
            //
            lblRecorrido.AutoSize = true;
            lblRecorrido.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRecorrido.Location = new Point(5, 170);
            lblRecorrido.Name = "lblRecorrido";
            lblRecorrido.TabIndex = 7;
            lblRecorrido.Text = "Recorrido del daño";
            //
            // lstRecorrido
            //
            lstRecorrido.HorizontalScrollbar = true;
            lstRecorrido.ItemHeight = 15;
            lstRecorrido.Location = new Point(5, 190);
            lstRecorrido.Name = "lstRecorrido";
            lstRecorrido.Size = new Size(360, 79);
            lstRecorrido.TabIndex = 8;
            //
            // PanelCadenaDefensa
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(lblTitulo);
            Controls.Add(lstEslabones);
            Controls.Add(btnSubir);
            Controls.Add(btnBajar);
            Controls.Add(btnQuitar);
            Controls.Add(cmbTipo);
            Controls.Add(btnAgregar);
            Controls.Add(lblRecorrido);
            Controls.Add(lstRecorrido);
            Name = "PanelCadenaDefensa";
            Size = new Size(370, 275);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private ListBox lstEslabones;
        private Button btnSubir;
        private Button btnBajar;
        private Button btnQuitar;
        private ComboBox cmbTipo;
        private Button btnAgregar;
        private Label lblRecorrido;
        private ListBox lstRecorrido;
    }
}
