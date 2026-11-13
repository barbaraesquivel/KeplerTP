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
            lblTitulo = new Label();
            lblInventario = new Label();
            lstInventario = new ListBox();
            lblVisitante = new Label();
            cmbVisitante = new ComboBox();
            btnAplicar = new Button();
            btnRestablecer = new Button();
            lblResultado = new Label();
            txtResultado = new TextBox();
            btnContinuar = new Button();
            lblHistoria = new Label();
            btnComprar = new Button();
            lblSaldo = new Label();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitulo.Location = new Point(25, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(440, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Analizador de Inventario - Patrón Visitor";
            // 
            // lblInventario
            // 
            lblInventario.AutoSize = true;
            lblInventario.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblInventario.Location = new Point(25, 108);
            lblInventario.Name = "lblInventario";
            lblInventario.Size = new Size(300, 20);
            lblInventario.TabIndex = 1;
            lblInventario.Text = "Tienda: seleccioná un ítem y tocá Comprar.";
            // 
            // lstInventario
            // 
            lstInventario.Font = new Font("Consolas", 8.8F);
            lstInventario.FormattingEnabled = true;
            lstInventario.ItemHeight = 17;
            lstInventario.Location = new Point(25, 131);
            lstInventario.Name = "lstInventario";
            lstInventario.Size = new Size(720, 106);
            lstInventario.TabIndex = 2;
            // 
            // lblVisitante
            // 
            lblVisitante.AutoSize = true;
            lblVisitante.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblVisitante.Location = new Point(25, 247);
            lblVisitante.Name = "lblVisitante";
            lblVisitante.Size = new Size(187, 20);
            lblVisitante.TabIndex = 3;
            lblVisitante.Text = "Elegir Visitante a aplicar:";
            // 
            // cmbVisitante
            // 
            cmbVisitante.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVisitante.FormattingEnabled = true;
            cmbVisitante.Items.AddRange(new object[] { "Calculador de Precio (CalculadorPrecio)", "Contador de Armas (ContadorArmas)", "Aplicador de Veneno (AplicadorVeneno)" });
            cmbVisitante.Location = new Point(25, 270);
            cmbVisitante.Name = "cmbVisitante";
            cmbVisitante.Size = new Size(340, 28);
            cmbVisitante.TabIndex = 4;
            // 
            // btnAplicar
            // 
            btnAplicar.BackColor = Color.LightSteelBlue;
            btnAplicar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAplicar.Location = new Point(380, 268);
            btnAplicar.Name = "btnAplicar";
            btnAplicar.Size = new Size(180, 32);
            btnAplicar.TabIndex = 5;
            btnAplicar.Text = "Aplicar Visitante";
            btnAplicar.UseVisualStyleBackColor = false;
            btnAplicar.Click += btnAplicar_Click;
            // 
            // btnRestablecer
            // 
            btnRestablecer.Location = new Point(570, 268);
            btnRestablecer.Name = "btnRestablecer";
            btnRestablecer.Size = new Size(175, 32);
            btnRestablecer.TabIndex = 6;
            btnRestablecer.Text = "Restablecer Inventario";
            btnRestablecer.UseVisualStyleBackColor = true;
            btnRestablecer.Click += btnRestablecer_Click;
            // 
            // lblResultado
            // 
            lblResultado.AutoSize = true;
            lblResultado.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblResultado.Location = new Point(25, 310);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(276, 20);
            lblResultado.TabIndex = 7;
            lblResultado.Text = "Resultado de la operación del Visitor:";
            // 
            // txtResultado
            // 
            txtResultado.BackColor = Color.Black;
            txtResultado.Font = new Font("Consolas", 9F);
            txtResultado.ForeColor = Color.LimeGreen;
            txtResultado.Location = new Point(25, 333);
            txtResultado.Multiline = true;
            txtResultado.Name = "txtResultado";
            txtResultado.ReadOnly = true;
            txtResultado.ScrollBars = ScrollBars.Vertical;
            txtResultado.Size = new Size(720, 155);
            txtResultado.TabIndex = 8;
            txtResultado.Text = "Seleccioná un visitante y hacé clic en 'Aplicar Visitante'.";
            // 
            // btnContinuar
            // 
            btnContinuar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnContinuar.Location = new Point(25, 502);
            btnContinuar.Name = "btnContinuar";
            btnContinuar.Size = new Size(180, 36);
            btnContinuar.TabIndex = 9;
            btnContinuar.Text = "Continuar";
            btnContinuar.Enabled = false;
            btnContinuar.UseVisualStyleBackColor = true;
            btnContinuar.Click += btnContinuar_Click;
            // 
            // btnComprar
            // 
            btnComprar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnComprar.Location = new Point(220, 502);
            btnComprar.Name = "btnComprar";
            btnComprar.Size = new Size(180, 36);
            btnComprar.TabIndex = 51;
            btnComprar.Text = "Comprar seleccionado";
            btnComprar.UseVisualStyleBackColor = true;
            btnComprar.Click += btnComprar_Click;
            // 
            // lblSaldo
            // 
            lblSaldo.AutoSize = true;
            lblSaldo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSaldo.ForeColor = Color.FromArgb(90, 220, 140);
            lblSaldo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblSaldo.Location = new Point(415, 510);
            lblSaldo.Name = "lblSaldo";
            lblSaldo.Size = new Size(90, 19);
            lblSaldo.TabIndex = 52;
            lblSaldo.Text = "Monedas: 0";
            // 
            // lblHistoria
            // 
            lblHistoria.BorderStyle = BorderStyle.FixedSingle;
            lblHistoria.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic);
            lblHistoria.ForeColor = Color.FromArgb(255, 220, 130);
            lblHistoria.Location = new Point(25, 46);
            lblHistoria.Name = "lblHistoria";
            lblHistoria.Padding = new Padding(4);
            lblHistoria.Size = new Size(720, 56);
            lblHistoria.TabIndex = 50;
            lblHistoria.Text = "Historia del capítulo";
            // 
            // PantallaVisitor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblHistoria);
            Controls.Add(btnComprar);
            Controls.Add(lblSaldo);
            Controls.Add(btnContinuar);
            Controls.Add(txtResultado);
            Controls.Add(lblResultado);
            Controls.Add(btnRestablecer);
            Controls.Add(btnAplicar);
            Controls.Add(cmbVisitante);
            Controls.Add(lblVisitante);
            Controls.Add(lstInventario);
            Controls.Add(lblInventario);
            Controls.Add(lblTitulo);
            Name = "PantallaVisitor";
            Size = new Size(770, 555);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblInventario;
        private ListBox lstInventario;
        private Label lblVisitante;
        private ComboBox cmbVisitante;
        private Button btnAplicar;
        private Button btnRestablecer;
        private Label lblResultado;
        private TextBox txtResultado;
        private Button btnContinuar;
        private Label lblHistoria;
        private Button btnComprar;
        private Label lblSaldo;
    }
}
