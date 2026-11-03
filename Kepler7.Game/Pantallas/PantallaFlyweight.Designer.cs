namespace Kepler7.Game.Pantallas
{
    partial class PantallaFlyweight
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
            lblResultado = new Label();
            btnEjecutarPrueba = new Button();
            btnVolver = new Button();
            SuspendLayout();
            // 
            // lblResultado
            // 
            lblResultado.AutoSize = true;
            lblResultado.Location = new Point(93, 149);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(0, 25);
            lblResultado.TabIndex = 0;
            // 
            // btnEjecutarPrueba
            // 
            btnEjecutarPrueba.Location = new Point(114, 61);
            btnEjecutarPrueba.Name = "btnEjecutarPrueba";
            btnEjecutarPrueba.Size = new Size(302, 69);
            btnEjecutarPrueba.TabIndex = 1;
            btnEjecutarPrueba.Text = "Ejecutar Demostración Flyweight";
            btnEjecutarPrueba.UseVisualStyleBackColor = true;
            btnEjecutarPrueba.Click += btnEjecutarPrueba_Click_1;
            // 
            // btnVolver
            // 
            btnVolver.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnVolver.Location = new Point(29, 369);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(229, 58);
            btnVolver.TabIndex = 2;
            btnVolver.Text = "Volver al hub";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // PantallaFlyweight
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnVolver);
            Controls.Add(btnEjecutarPrueba);
            Controls.Add(lblResultado);
            Name = "PantallaFlyweight";
            Size = new Size(728, 460);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnVolver;
        private Label lblResultado;
        private Button btnEjecutarPrueba;
    }
}
