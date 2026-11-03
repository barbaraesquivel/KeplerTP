namespace Kepler7.Game.Pantallas
{
    partial class PantallaVisitor
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
            btnAnalizar = new Button();
            txtReporte = new TextBox();
            lblValorTotal = new Label();
            lblTotalItems = new Label();
            btnVolver = new Button();
            SuspendLayout();
            // 
            // btnAnalizar
            // 
            btnAnalizar.Location = new Point(59, 39);
            btnAnalizar.Name = "btnAnalizar";
            btnAnalizar.Size = new Size(300, 59);
            btnAnalizar.TabIndex = 0;
            btnAnalizar.Text = "Analizar Inventario con Visitors";
            btnAnalizar.UseVisualStyleBackColor = true;
            btnAnalizar.Click += btnAnalizar_Click_1;
            // 
            // txtReporte
            // 
            txtReporte.Location = new Point(59, 120);
            txtReporte.Multiline = true;
            txtReporte.Name = "txtReporte";
            txtReporte.Size = new Size(393, 54);
            txtReporte.TabIndex = 1;
            // 
            // lblValorTotal
            // 
            lblValorTotal.AutoSize = true;
            lblValorTotal.Location = new Point(59, 190);
            lblValorTotal.Name = "lblValorTotal";
            lblValorTotal.Size = new Size(135, 25);
            lblValorTotal.TabIndex = 2;
            lblValorTotal.Text = "Valor Estimado:";
            // 
            // lblTotalItems
            // 
            lblTotalItems.AutoSize = true;
            lblTotalItems.Location = new Point(58, 221);
            lblTotalItems.Name = "lblTotalItems";
            lblTotalItems.Size = new Size(102, 25);
            lblTotalItems.TabIndex = 3;
            lblTotalItems.Text = "Total Items:";
            // 
            // btnVolver
            // 
            btnVolver.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnVolver.Location = new Point(29, 384);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(229, 58);
            btnVolver.TabIndex = 4;
            btnVolver.Text = "Volver al hub";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // PantallaVisitor
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnVolver);
            Controls.Add(lblTotalItems);
            Controls.Add(lblValorTotal);
            Controls.Add(txtReporte);
            Controls.Add(btnAnalizar);
            Name = "PantallaVisitor";
            Size = new Size(618, 475);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnVolver;
        private Button btnAnalizar;
        private TextBox txtReporte;
        private Label lblValorTotal;
        private Label lblTotalItems;
    }
}
