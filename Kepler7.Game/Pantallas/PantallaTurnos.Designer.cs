namespace Kepler7.Game.Pantallas
{
    partial class PantallaTurnos
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            cmbUnidades = new ComboBox();
            btnEjecutarTurno = new Button();
            lstHistorial = new ListBox();
            lblUnidades = new Label();
            btnContinuar = new Button();
            lblHistoria = new Label();
            SuspendLayout();
            // 
            // cmbUnidades
            // 
            cmbUnidades.FormattingEnabled = true;
            cmbUnidades.Location = new Point(114, 87);
            cmbUnidades.Name = "cmbUnidades";
            cmbUnidades.Size = new Size(273, 23);
            cmbUnidades.TabIndex = 0;
            // 
            // btnEjecutarTurno
            // 
            btnEjecutarTurno.Location = new Point(433, 63);
            btnEjecutarTurno.Name = "btnEjecutarTurno";
            btnEjecutarTurno.Size = new Size(249, 68);
            btnEjecutarTurno.TabIndex = 1;
            btnEjecutarTurno.Text = "Ejecutar Turno";
            btnEjecutarTurno.UseVisualStyleBackColor = true;
            btnEjecutarTurno.Click += btnEjecutarTurno_Click;
            // 
            // lstHistorial
            // 
            lstHistorial.FormattingEnabled = true;
            lstHistorial.ItemHeight = 15;
            lstHistorial.Location = new Point(76, 181);
            lstHistorial.Name = "lstHistorial";
            lstHistorial.Size = new Size(606, 334);
            lstHistorial.TabIndex = 2;
            // 
            // lblUnidades
            // 
            lblUnidades.AutoSize = true;
            lblUnidades.Location = new Point(114, 69);
            lblUnidades.Name = "lblUnidades";
            lblUnidades.Size = new Size(56, 15);
            lblUnidades.TabIndex = 3;
            lblUnidades.Text = "Unidades";
            // 
            // btnContinuar
            // 
            btnContinuar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnContinuar.Location = new Point(522, 530);
            btnContinuar.Name = "btnContinuar";
            btnContinuar.Size = new Size(160, 35);
            btnContinuar.TabIndex = 4;
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
            lblHistoria.Location = new Point(76, 2);
            lblHistoria.Name = "lblHistoria";
            lblHistoria.Padding = new Padding(4);
            lblHistoria.Size = new Size(606, 56);
            lblHistoria.TabIndex = 50;
            lblHistoria.Text = "Historia del capítulo";
            // 
            // PantallaTurnos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblHistoria);
            Controls.Add(btnContinuar);
            Controls.Add(lblUnidades);
            Controls.Add(lstHistorial);
            Controls.Add(btnEjecutarTurno);
            Controls.Add(cmbUnidades);
            Name = "PantallaTurnos";
            Size = new Size(765, 584);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbUnidades;
        private Button btnEjecutarTurno;
        private ListBox lstHistorial;
        private Label lblUnidades;
        private Button btnContinuar;
        private Label lblHistoria;
    }
}
