namespace Kepler7.Game.Pantallas
{
    partial class PantallaInicio
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
            lblSubtitulo = new Label();
            lblEquipo = new Label();
            btnJugar = new Button();
            btnTutorial = new Button();
            btnSalir = new Button();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.Location = new Point(43, 50);
            lblTitulo.Margin = new Padding(4, 0, 4, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(182, 54);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Kepler-7";
            //
            // lblSubtitulo
            //
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 11F, FontStyle.Italic);
            lblSubtitulo.Location = new Point(47, 106);
            lblSubtitulo.Margin = new Padding(4, 0, 4, 0);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.TabIndex = 5;
            lblSubtitulo.Text = "Estación orbital en crisis · rol táctico por turnos";
            //
            // lblEquipo
            //
            lblEquipo.AutoSize = true;
            lblEquipo.Location = new Point(47, 145);
            lblEquipo.Margin = new Padding(4, 0, 4, 0);
            lblEquipo.Name = "lblEquipo";
            lblEquipo.TabIndex = 1;
            lblEquipo.Text = "Equipo: Barbara, Martin, Lautaro y Axel";
            //
            // btnJugar
            //
            btnJugar.Location = new Point(43, 200);
            btnJugar.Margin = new Padding(4, 5, 4, 5);
            btnJugar.Name = "btnJugar";
            btnJugar.Size = new Size(229, 58);
            btnJugar.TabIndex = 2;
            btnJugar.Text = "Jugar";
            btnJugar.UseVisualStyleBackColor = true;
            btnJugar.Click += btnJugar_Click;
            //
            // btnTutorial
            //
            btnTutorial.Location = new Point(43, 283);
            btnTutorial.Margin = new Padding(4, 5, 4, 5);
            btnTutorial.Name = "btnTutorial";
            btnTutorial.Size = new Size(229, 58);
            btnTutorial.TabIndex = 3;
            btnTutorial.Text = "Tutorial";
            btnTutorial.UseVisualStyleBackColor = true;
            btnTutorial.Click += btnTutorial_Click;
            //
            // btnSalir
            //
            btnSalir.Location = new Point(43, 366);
            btnSalir.Margin = new Padding(4, 5, 4, 5);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(229, 58);
            btnSalir.TabIndex = 4;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            //
            // PantallaInicio
            //
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblTitulo);
            Controls.Add(lblSubtitulo);
            Controls.Add(lblEquipo);
            Controls.Add(btnJugar);
            Controls.Add(btnTutorial);
            Controls.Add(btnSalir);
            Margin = new Padding(4, 5, 4, 5);
            Name = "PantallaInicio";
            Size = new Size(1143, 750);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblSubtitulo;
        private Label lblEquipo;
        private Button btnJugar;
        private Button btnTutorial;
        private Button btnSalir;
    }
}
