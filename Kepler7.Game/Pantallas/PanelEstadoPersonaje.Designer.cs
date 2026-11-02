namespace Kepler7.Game.Pantallas
{
    partial class PanelEstadoPersonaje
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
            pnlIcono = new Panel();
            lblEstado = new Label();
            btnVeneno = new Button();
            btnAturdir = new Button();
            btnBerserk = new Button();
            btnNormal = new Button();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTitulo.Location = new Point(5, 5);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Estado del personaje";
            //
            // pnlIcono
            //
            pnlIcono.Location = new Point(5, 28);
            pnlIcono.Name = "pnlIcono";
            pnlIcono.Size = new Size(50, 50);
            pnlIcono.TabIndex = 1;
            pnlIcono.Paint += pnlIcono_Paint;
            //
            // lblEstado
            //
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblEstado.Location = new Point(65, 42);
            lblEstado.Name = "lblEstado";
            lblEstado.TabIndex = 2;
            lblEstado.Text = "Estado: Normal";
            //
            // btnVeneno
            //
            btnVeneno.Location = new Point(5, 90);
            btnVeneno.Name = "btnVeneno";
            btnVeneno.Size = new Size(85, 28);
            btnVeneno.TabIndex = 3;
            btnVeneno.Text = "Veneno";
            btnVeneno.UseVisualStyleBackColor = true;
            btnVeneno.Click += btnVeneno_Click;
            //
            // btnAturdir
            //
            btnAturdir.Location = new Point(95, 90);
            btnAturdir.Name = "btnAturdir";
            btnAturdir.Size = new Size(85, 28);
            btnAturdir.TabIndex = 4;
            btnAturdir.Text = "Aturdir";
            btnAturdir.UseVisualStyleBackColor = true;
            btnAturdir.Click += btnAturdir_Click;
            //
            // btnBerserk
            //
            btnBerserk.Location = new Point(185, 90);
            btnBerserk.Name = "btnBerserk";
            btnBerserk.Size = new Size(85, 28);
            btnBerserk.TabIndex = 5;
            btnBerserk.Text = "Berserk";
            btnBerserk.UseVisualStyleBackColor = true;
            btnBerserk.Click += btnBerserk_Click;
            //
            // btnNormal
            //
            btnNormal.Location = new Point(275, 90);
            btnNormal.Name = "btnNormal";
            btnNormal.Size = new Size(85, 28);
            btnNormal.TabIndex = 6;
            btnNormal.Text = "Normal";
            btnNormal.UseVisualStyleBackColor = true;
            btnNormal.Click += btnNormal_Click;
            //
            // PanelEstadoPersonaje
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(lblTitulo);
            Controls.Add(pnlIcono);
            Controls.Add(lblEstado);
            Controls.Add(btnVeneno);
            Controls.Add(btnAturdir);
            Controls.Add(btnBerserk);
            Controls.Add(btnNormal);
            Name = "PanelEstadoPersonaje";
            Size = new Size(370, 130);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Panel pnlIcono;
        private Label lblEstado;
        private Button btnVeneno;
        private Button btnAturdir;
        private Button btnBerserk;
        private Button btnNormal;
    }
}
