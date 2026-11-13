namespace Kepler7.Game.Pantallas
{
    partial class PantallaFinal
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
            txtHistoria = new TextBox();
            lblTabla = new Label();
            lvDecisiones = new ListView();
            colDecision = new ColumnHeader();
            colEfecto = new ColumnHeader();
            lblDatos = new Label();
            btnNuevaCampana = new Button();
            btnSalir = new Button();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.Location = new Point(30, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(260, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Epílogo";
            //
            // txtHistoria
            //
            txtHistoria.Font = new Font("Segoe UI", 10F);
            txtHistoria.Location = new Point(30, 55);
            txtHistoria.Multiline = true;
            txtHistoria.Name = "txtHistoria";
            txtHistoria.ReadOnly = true;
            txtHistoria.ScrollBars = ScrollBars.Vertical;
            txtHistoria.Size = new Size(750, 175);
            txtHistoria.TabIndex = 1;
            txtHistoria.TabStop = false;
            //
            // lblTabla
            //
            lblTabla.AutoSize = true;
            lblTabla.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTabla.Location = new Point(30, 238);
            lblTabla.Name = "lblTabla";
            lblTabla.Size = new Size(260, 19);
            lblTabla.TabIndex = 2;
            lblTabla.Text = "Decisiones de la campaña y su efecto en el final:";
            //
            // lvDecisiones
            //
            lvDecisiones.Columns.AddRange(new ColumnHeader[] { colDecision, colEfecto });
            lvDecisiones.FullRowSelect = true;
            lvDecisiones.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvDecisiones.Location = new Point(30, 260);
            lvDecisiones.Name = "lvDecisiones";
            lvDecisiones.Size = new Size(750, 200);
            lvDecisiones.TabIndex = 3;
            lvDecisiones.UseCompatibleStateImageBehavior = false;
            lvDecisiones.View = View.Details;
            //
            // colDecision
            //
            colDecision.Text = "Decisión";
            colDecision.Width = 330;
            //
            // colEfecto
            //
            colEfecto.Text = "Efecto en el final";
            colEfecto.Width = 395;
            //
            // lblDatos
            //
            lblDatos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDatos.ForeColor = Color.FromArgb(90, 220, 140);
            lblDatos.Location = new Point(30, 468);
            lblDatos.Name = "lblDatos";
            lblDatos.Size = new Size(750, 42);
            lblDatos.TabIndex = 4;
            lblDatos.Text = "Datos de la partida";
            //
            // btnNuevaCampana
            //
            btnNuevaCampana.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnNuevaCampana.Location = new Point(30, 518);
            btnNuevaCampana.Name = "btnNuevaCampana";
            btnNuevaCampana.Size = new Size(200, 42);
            btnNuevaCampana.TabIndex = 5;
            btnNuevaCampana.Text = "Nueva campaña";
            btnNuevaCampana.UseVisualStyleBackColor = true;
            btnNuevaCampana.Click += btnNuevaCampana_Click;
            //
            // btnSalir
            //
            btnSalir.Location = new Point(245, 518);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(150, 42);
            btnSalir.TabIndex = 6;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            //
            // PantallaFinal
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblTitulo);
            Controls.Add(txtHistoria);
            Controls.Add(lblTabla);
            Controls.Add(lvDecisiones);
            Controls.Add(lblDatos);
            Controls.Add(btnNuevaCampana);
            Controls.Add(btnSalir);
            Name = "PantallaFinal";
            Size = new Size(800, 575);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private TextBox txtHistoria;
        private Label lblTabla;
        private ListView lvDecisiones;
        private ColumnHeader colDecision;
        private ColumnHeader colEfecto;
        private Label lblDatos;
        private Button btnNuevaCampana;
        private Button btnSalir;
    }
}
