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
            btnContinuar = new Button();
            lblHistoria = new Label();
            lblSaldo = new Label();
            btnProbar = new Button();
            lblEfecto = new Label();
            SuspendLayout();
            // 
            // cmbTipoMensaje
            // 
            cmbTipoMensaje.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoMensaje.FormattingEnabled = true;
            cmbTipoMensaje.Location = new Point(216, 80);
            cmbTipoMensaje.Name = "cmbTipoMensaje";
            cmbTipoMensaje.Size = new Size(194, 23);
            cmbTipoMensaje.TabIndex = 0;
            // 
            // cmbCifrado
            // 
            cmbCifrado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCifrado.FormattingEnabled = true;
            cmbCifrado.Location = new Point(416, 80);
            cmbCifrado.Name = "cmbCifrado";
            cmbCifrado.Size = new Size(194, 23);
            cmbCifrado.TabIndex = 0;
            cmbCifrado.SelectedIndexChanged += cmbCifrado_SelectedIndexChanged;
            // 
            // lblSaldo
            // 
            lblSaldo.Location = new Point(216, 110);
            lblSaldo.Name = "lblSaldo";
            lblSaldo.Size = new Size(394, 50);
            lblSaldo.TabIndex = 51;
            lblSaldo.Text = "Monedas: 0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(216, 62);
            label1.Name = "label1";
            label1.Size = new Size(93, 15);
            label1.TabIndex = 1;
            label1.Text = "Tipo de Mensaje";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(416, 62);
            label2.Name = "label2";
            label2.Size = new Size(46, 15);
            label2.TabIndex = 1;
            label2.Text = "Cifrado";
            // 
            // txtMensaje
            // 
            txtMensaje.Location = new Point(216, 190);
            txtMensaje.Multiline = true;
            txtMensaje.Name = "txtMensaje";
            txtMensaje.Size = new Size(394, 124);
            txtMensaje.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(216, 172);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 1;
            label3.Text = "Mensaje";
            // 
            // btnEnviar
            // 
            btnEnviar.Location = new Point(416, 325);
            btnEnviar.Name = "btnEnviar";
            btnEnviar.Size = new Size(194, 50);
            btnEnviar.TabIndex = 3;
            btnEnviar.Text = "Enviar definitivo";
            btnEnviar.UseVisualStyleBackColor = true;
            btnEnviar.Click += btnEnviar_Click;
            //
            // btnProbar
            //
            btnProbar.Location = new Point(216, 325);
            btnProbar.Name = "btnProbar";
            btnProbar.Size = new Size(194, 50);
            btnProbar.TabIndex = 6;
            btnProbar.Text = "Probar";
            btnProbar.UseVisualStyleBackColor = true;
            btnProbar.Click += btnProbar_Click;
            //
            // lblEfecto
            //
            lblEfecto.Location = new Point(63, 380);
            lblEfecto.Name = "lblEfecto";
            lblEfecto.Size = new Size(700, 26);
            lblEfecto.TabIndex = 52;
            lblEfecto.Text = "Probá combinaciones de tipo y cifrado antes del envío definitivo.";
            // 
            // txtMensajeOriginalMuestra
            // 
            txtMensajeOriginalMuestra.Location = new Point(63, 427);
            txtMensajeOriginalMuestra.Multiline = true;
            txtMensajeOriginalMuestra.Name = "txtMensajeOriginalMuestra";
            txtMensajeOriginalMuestra.ReadOnly = true;
            txtMensajeOriginalMuestra.Size = new Size(347, 150);
            txtMensajeOriginalMuestra.TabIndex = 4;
            // 
            // txtMensajeCifradoMuestra
            // 
            txtMensajeCifradoMuestra.Location = new Point(416, 427);
            txtMensajeCifradoMuestra.Multiline = true;
            txtMensajeCifradoMuestra.Name = "txtMensajeCifradoMuestra";
            txtMensajeCifradoMuestra.ReadOnly = true;
            txtMensajeCifradoMuestra.Size = new Size(347, 150);
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
            // btnContinuar
            // 
            btnContinuar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnContinuar.Location = new Point(603, 585);
            btnContinuar.Name = "btnContinuar";
            btnContinuar.Size = new Size(160, 35);
            btnContinuar.TabIndex = 5;
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
            lblHistoria.Location = new Point(63, 2);
            lblHistoria.Name = "lblHistoria";
            lblHistoria.Padding = new Padding(4);
            lblHistoria.Size = new Size(700, 56);
            lblHistoria.TabIndex = 50;
            lblHistoria.Text = "Historia del capítulo";
            // 
            // PantallaComunicaciones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblHistoria);
            Controls.Add(lblSaldo);
            Controls.Add(btnContinuar);
            Controls.Add(txtMensajeCifradoMuestra);
            Controls.Add(txtMensajeOriginalMuestra);
            Controls.Add(btnEnviar);
            Controls.Add(btnProbar);
            Controls.Add(lblEfecto);
            Controls.Add(txtMensaje);
            Controls.Add(lblMensajeCifrado);
            Controls.Add(lblMensajeOriginal);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmbCifrado);
            Controls.Add(cmbTipoMensaje);
            Name = "PantallaComunicaciones";
            Size = new Size(800, 630);
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
        private Button btnContinuar;
        private Label lblHistoria;
        private Label lblSaldo;
        private Button btnProbar;
        private Label lblEfecto;
    }
}
