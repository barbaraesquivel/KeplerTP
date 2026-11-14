namespace Kepler7.Game.Pantallas
{
    partial class PanelLaboratorio
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
            lblRecursos = new Label();
            btnClonar = new Button();
            btnModificarClon = new Button();
            cmbClones = new ComboBox();
            lblOriginal = new Label();
            lstOriginal = new ListBox();
            lblClon = new Label();
            lstClon = new ListBox();
            lblComparacion = new Label();
            btnContinuar = new Button();
            lblHistoria = new Label();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(10, 10);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Laboratorio de clonación";
            //
            // lblRecursos
            //
            lblRecursos.AutoSize = true;
            lblRecursos.Location = new Point(10, 108);
            lblRecursos.Name = "lblRecursos";
            lblRecursos.TabIndex = 1;
            lblRecursos.Text = "Recursos: 0";
            //
            // btnClonar
            //
            btnClonar.Location = new Point(10, 130);
            btnClonar.Name = "btnClonar";
            btnClonar.Size = new Size(150, 30);
            btnClonar.TabIndex = 2;
            btnClonar.Text = "Clonar";
            btnClonar.UseVisualStyleBackColor = true;
            btnClonar.Click += btnClonar_Click;
            //
            // btnModificarClon
            //
            btnModificarClon.Location = new Point(170, 130);
            btnModificarClon.Name = "btnModificarClon";
            btnModificarClon.Size = new Size(150, 30);
            btnModificarClon.TabIndex = 3;
            btnModificarClon.Text = "Modificar clon";
            btnModificarClon.UseVisualStyleBackColor = true;
            btnModificarClon.Click += btnModificarClon_Click;
            //
            // cmbClones
            //
            cmbClones.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClones.Location = new Point(330, 134);
            cmbClones.Name = "cmbClones";
            cmbClones.Size = new Size(200, 23);
            cmbClones.TabIndex = 10;
            cmbClones.SelectedIndexChanged += cmbClones_SelectedIndexChanged;
            //
            // lblOriginal
            //
            lblOriginal.AutoSize = true;
            lblOriginal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblOriginal.Location = new Point(10, 170);
            lblOriginal.Name = "lblOriginal";
            lblOriginal.TabIndex = 4;
            lblOriginal.Text = "Original";
            //
            // lstOriginal
            //
            lstOriginal.ItemHeight = 15;
            lstOriginal.Location = new Point(10, 190);
            lstOriginal.Name = "lstOriginal";
            lstOriginal.Size = new Size(375, 199);
            lstOriginal.TabIndex = 5;
            //
            // lblClon
            //
            lblClon.AutoSize = true;
            lblClon.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblClon.Location = new Point(400, 170);
            lblClon.Name = "lblClon";
            lblClon.TabIndex = 6;
            lblClon.Text = "Clon";
            //
            // lstClon
            //
            lstClon.ItemHeight = 15;
            lstClon.Location = new Point(400, 190);
            lstClon.Name = "lstClon";
            lstClon.Size = new Size(375, 199);
            lstClon.TabIndex = 7;
            //
            // lblComparacion
            //
            lblComparacion.Location = new Point(10, 400);
            lblComparacion.Name = "lblComparacion";
            lblComparacion.Size = new Size(765, 60);
            lblComparacion.TabIndex = 8;
            lblComparacion.Text = "";
            //
            // btnContinuar
            //
            btnContinuar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnContinuar.Location = new Point(20, 565);
            btnContinuar.Name = "btnContinuar";
            btnContinuar.Size = new Size(160, 35);
            btnContinuar.TabIndex = 9;
            btnContinuar.Text = "Continuar";
            btnContinuar.Enabled = false;
            btnContinuar.UseVisualStyleBackColor = true;
            btnContinuar.Click += btnContinuar_Click;
            // 
            // lblHistoria
            // 
            lblHistoria.BorderStyle = BorderStyle.FixedSingle;
            lblHistoria.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic);
            lblHistoria.ForeColor = Color.FromArgb(255, 220, 130);
            lblHistoria.Location = new Point(10, 45);
            lblHistoria.Name = "lblHistoria";
            lblHistoria.Padding = new Padding(4);
            lblHistoria.Size = new Size(765, 56);
            lblHistoria.TabIndex = 50;
            lblHistoria.Text = "Historia del capítulo";
            //
            // PanelLaboratorio
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblHistoria);
            Controls.Add(lblTitulo);
            Controls.Add(lblRecursos);
            Controls.Add(btnClonar);
            Controls.Add(btnModificarClon);
            Controls.Add(cmbClones);
            Controls.Add(lblOriginal);
            Controls.Add(lstOriginal);
            Controls.Add(lblClon);
            Controls.Add(lstClon);
            Controls.Add(lblComparacion);
            Controls.Add(btnContinuar);
            Name = "PanelLaboratorio";
            Size = new Size(800, 620);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblRecursos;
        private Button btnClonar;
        private Button btnModificarClon;
        private ComboBox cmbClones;
        private Label lblOriginal;
        private ListBox lstOriginal;
        private Label lblClon;
        private ListBox lstClon;
        private Label lblComparacion;
        private Button btnContinuar;
        private Label lblHistoria;
    }
}
