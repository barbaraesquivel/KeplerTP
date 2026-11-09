namespace Kepler7.Game.Pantallas
{
    partial class PantallaEstrategiaIA_strategy
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
            lstEnemigos = new ListBox();
            cmbEstrategias = new ComboBox();
            btnEjecutarTurno = new Button();
            txtDecision = new TextBox();
            lblEstrategias = new Label();
            lblListaEnemigos = new Label();
            SuspendLayout();
            // 
            // lstEnemigos
            // 
            lstEnemigos.FormattingEnabled = true;
            lstEnemigos.ItemHeight = 15;
            lstEnemigos.Location = new Point(67, 129);
            lstEnemigos.Name = "lstEnemigos";
            lstEnemigos.Size = new Size(267, 169);
            lstEnemigos.TabIndex = 0;
            // 
            // cmbEstrategias
            // 
            cmbEstrategias.FormattingEnabled = true;
            cmbEstrategias.Location = new Point(67, 56);
            cmbEstrategias.Name = "cmbEstrategias";
            cmbEstrategias.Size = new Size(267, 23);
            cmbEstrategias.TabIndex = 1;
            cmbEstrategias.SelectedIndexChanged += cmbEstrategia_SelectedIndexChanged;
            // 
            // btnEjecutarTurno
            // 
            btnEjecutarTurno.Location = new Point(78, 340);
            btnEjecutarTurno.Name = "btnEjecutarTurno";
            btnEjecutarTurno.Size = new Size(234, 63);
            btnEjecutarTurno.TabIndex = 2;
            btnEjecutarTurno.Text = "Ejecutar Turno";
            btnEjecutarTurno.UseVisualStyleBackColor = true;
            btnEjecutarTurno.Click += btnEjecutarTurno_Click;
            // 
            // txtDecision
            // 
            txtDecision.Location = new Point(395, 56);
            txtDecision.Multiline = true;
            txtDecision.Name = "txtDecision";
            txtDecision.ReadOnly = true;
            txtDecision.Size = new Size(298, 347);
            txtDecision.TabIndex = 3;
            // 
            // lblEstrategias
            // 
            lblEstrategias.AutoSize = true;
            lblEstrategias.Location = new Point(67, 38);
            lblEstrategias.Name = "lblEstrategias";
            lblEstrategias.Size = new Size(63, 15);
            lblEstrategias.TabIndex = 4;
            lblEstrategias.Text = "Estrategias";
            // 
            // lblListaEnemigos
            // 
            lblListaEnemigos.AutoSize = true;
            lblListaEnemigos.Location = new Point(67, 111);
            lblListaEnemigos.Name = "lblListaEnemigos";
            lblListaEnemigos.Size = new Size(86, 15);
            lblListaEnemigos.TabIndex = 4;
            lblListaEnemigos.Text = "Lista Enemigos";
            // 
            // PantallaEstrategiaIA_strategy
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblListaEnemigos);
            Controls.Add(lblEstrategias);
            Controls.Add(txtDecision);
            Controls.Add(btnEjecutarTurno);
            Controls.Add(cmbEstrategias);
            Controls.Add(lstEnemigos);
            Name = "PantallaEstrategiaIA_strategy";
            Size = new Size(736, 455);
            Load += PantallaEstrategiaIA_strategy_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstEnemigos;
        private ComboBox cmbEstrategias;
        private Button btnEjecutarTurno;
        private TextBox txtDecision;
        private Label lblEstrategias;
        private Label lblListaEnemigos;
    }
}
