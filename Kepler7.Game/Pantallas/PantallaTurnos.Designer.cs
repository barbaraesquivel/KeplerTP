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
            btnVolver = new Button();
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
            // btnVolver
            // 
            btnVolver.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnVolver.Location = new Point(522, 530);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(160, 35);
            btnVolver.TabIndex = 4;
            btnVolver.Text = "Volver al hub";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // PantallaTurnos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnVolver);
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
        private Button btnVolver;
    }
}
