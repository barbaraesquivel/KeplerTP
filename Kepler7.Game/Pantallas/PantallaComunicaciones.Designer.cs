namespace Kepler7.Game.Pantallas
{
    partial class PantallaComunicaciones
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
            cmbTipoMensaje = new ComboBox();
            cmbCifrado = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            txtMensaje = new TextBox();
            label3 = new Label();
            btnEnviar = new Button();
            txtMensajeOriginalMuestra = new TextBox();
            txtMensajeCifradoMuestra = new TextBox();
            lblMensajeOriginal = new Label();
            lblMensajeCifrado = new Label();
            SuspendLayout();
            // 
            // cmbTipoMensaje
            // 
            cmbTipoMensaje.FormattingEnabled = true;
            cmbTipoMensaje.Location = new Point(216, 58);
            cmbTipoMensaje.Name = "cmbTipoMensaje";
            cmbTipoMensaje.Size = new Size(194, 23);
            cmbTipoMensaje.TabIndex = 0;
            // 
            // cmbCifrado
            // 
            cmbCifrado.FormattingEnabled = true;
            cmbCifrado.Location = new Point(416, 58);
            cmbCifrado.Name = "cmbCifrado";
            cmbCifrado.Size = new Size(194, 23);
            cmbCifrado.TabIndex = 0;
            cmbCifrado.SelectedIndexChanged += cmbCifrado_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(216, 40);
            label1.Name = "label1";
            label1.Size = new Size(93, 15);
            label1.TabIndex = 1;
            label1.Text = "Tipo de Mensaje";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(416, 40);
            label2.Name = "label2";
            label2.Size = new Size(46, 15);
            label2.TabIndex = 1;
            label2.Text = "Cifrado";
            // 
            // txtMensaje
            // 
            txtMensaje.Location = new Point(216, 168);
            txtMensaje.Multiline = true;
            txtMensaje.Name = "txtMensaje";
            txtMensaje.Size = new Size(394, 124);
            txtMensaje.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(216, 150);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 1;
            label3.Text = "Mensaje";
            // 
            // btnEnviar
            // 
            btnEnviar.Location = new Point(305, 309);
            btnEnviar.Name = "btnEnviar";
            btnEnviar.Size = new Size(199, 56);
            btnEnviar.TabIndex = 3;
            btnEnviar.Text = "Enviar";
            btnEnviar.UseVisualStyleBackColor = true;
            btnEnviar.Click += btnEnviar_Click;
            // 
            // txtMensajeOriginalMuestra
            // 
            txtMensajeOriginalMuestra.Location = new Point(63, 427);
            txtMensajeOriginalMuestra.Multiline = true;
            txtMensajeOriginalMuestra.Name = "txtMensajeOriginalMuestra";
            txtMensajeOriginalMuestra.ReadOnly = true;
            txtMensajeOriginalMuestra.Size = new Size(347, 219);
            txtMensajeOriginalMuestra.TabIndex = 4;
            // 
            // txtMensajeCifradoMuestra
            // 
            txtMensajeCifradoMuestra.Location = new Point(416, 427);
            txtMensajeCifradoMuestra.Multiline = true;
            txtMensajeCifradoMuestra.Name = "txtMensajeCifradoMuestra";
            txtMensajeCifradoMuestra.ReadOnly = true;
            txtMensajeCifradoMuestra.Size = new Size(347, 219);
            txtMensajeCifradoMuestra.TabIndex = 4;
            // 
            // lblMensajeOriginal
            // 
            lblMensajeOriginal.AutoSize = true;
            lblMensajeOriginal.Location = new Point(63, 409);
            lblMensajeOriginal.Name = "lblMensajeOriginal";
            lblMensajeOriginal.Size = new Size(96, 15);
            lblMensajeOriginal.TabIndex = 1;
            lblMensajeOriginal.Text = "Mensaje Original";
            // 
            // lblMensajeCifrado
            // 
            lblMensajeCifrado.AutoSize = true;
            lblMensajeCifrado.Location = new Point(416, 409);
            lblMensajeCifrado.Name = "lblMensajeCifrado";
            lblMensajeCifrado.Size = new Size(93, 15);
            lblMensajeCifrado.TabIndex = 1;
            lblMensajeCifrado.Text = "Mensaje Cifrado";
            // 
            // PantallaComunicaciones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtMensajeCifradoMuestra);
            Controls.Add(txtMensajeOriginalMuestra);
            Controls.Add(btnEnviar);
            Controls.Add(txtMensaje);
            Controls.Add(lblMensajeCifrado);
            Controls.Add(lblMensajeOriginal);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmbCifrado);
            Controls.Add(cmbTipoMensaje);
            Name = "PantallaComunicaciones";
            Size = new Size(798, 671);
            Load += PantallaComunicaciones_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbTipoMensaje;
        private ComboBox cmbCifrado;
        private Label label1;
        private Label label2;
        private TextBox txtMensaje;
        private Label label3;
        private Button btnEnviar;
        private TextBox txtMensajeOriginalMuestra;
        private TextBox txtMensajeCifradoMuestra;
        private Label lblMensajeOriginal;
        private Label lblMensajeCifrado;
    }
}
