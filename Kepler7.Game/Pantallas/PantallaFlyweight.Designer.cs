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
            lblTitulo = new Label();
            lblContador = new Label();
            lblEspecie = new Label();
            cmbEspecies = new ComboBox();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblRango = new Label();
            cmbRango = new ComboBox();
            btnCrearTripulante = new Button();
            btnCensoMasivo = new Button();
            btnReiniciar = new Button();
            lblDetalle = new Label();
            lblLista = new Label();
            lstTripulantes = new ListBox();
            txtComparacion = new TextBox();
            btnContinuar = new Button();
            lblHistoria = new Label();
            cmbCantidad = new ComboBox();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitulo.Location = new Point(25, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(410, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Censo de Tripulación - Patrón Flyweight";
            // 
            // lblContador
            // 
            lblContador.AutoSize = true;
            lblContador.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblContador.ForeColor = Color.FromArgb(90, 220, 140);
            lblContador.Location = new Point(25, 106);
            lblContador.Name = "lblContador";
            lblContador.Size = new Size(392, 25);
            lblContador.TabIndex = 1;
            lblContador.Text = "Especies creadas: 0 / Tripulantes creados: 0";
            // 
            // lblEspecie
            // 
            lblEspecie.AutoSize = true;
            lblEspecie.Location = new Point(25, 142);
            lblEspecie.Name = "lblEspecie";
            lblEspecie.Size = new Size(61, 20);
            lblEspecie.TabIndex = 2;
            lblEspecie.Text = "Especie:";
            // 
            // cmbEspecies
            // 
            cmbEspecies.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEspecies.FormattingEnabled = true;
            cmbEspecies.Location = new Point(90, 138);
            cmbEspecies.Name = "cmbEspecies";
            cmbEspecies.Size = new Size(220, 28);
            cmbEspecies.TabIndex = 3;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(325, 142);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(67, 20);
            lblNombre.TabIndex = 4;
            lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(398, 138);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(130, 27);
            txtNombre.TabIndex = 5;
            txtNombre.Text = "Elena Vega";
            // 
            // lblRango
            // 
            lblRango.AutoSize = true;
            lblRango.Location = new Point(25, 176);
            lblRango.Name = "lblRango";
            lblRango.Size = new Size(55, 20);
            lblRango.TabIndex = 6;
            lblRango.Text = "Rango:";
            // 
            // cmbRango
            // 
            cmbRango.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRango.FormattingEnabled = true;
            cmbRango.Location = new Point(90, 172);
            cmbRango.Name = "cmbRango";
            cmbRango.Size = new Size(220, 28);
            cmbRango.TabIndex = 7;
            // 
            // btnCrearTripulante
            // 
            btnCrearTripulante.Location = new Point(325, 171);
            btnCrearTripulante.Name = "btnCrearTripulante";
            btnCrearTripulante.Size = new Size(203, 30);
            btnCrearTripulante.TabIndex = 8;
            btnCrearTripulante.Text = "Crear Tripulante";
            btnCrearTripulante.UseVisualStyleBackColor = true;
            btnCrearTripulante.Click += btnCrearTripulante_Click;
            // 
            // btnCensoMasivo
            // 
            btnCensoMasivo.BackColor = Color.LightSteelBlue;
            btnCensoMasivo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCensoMasivo.Location = new Point(25, 210);
            btnCensoMasivo.Name = "btnCensoMasivo";
            btnCensoMasivo.Size = new Size(250, 32);
            btnCensoMasivo.TabIndex = 9;
            btnCensoMasivo.Text = "Ejecutar censo de:";
            btnCensoMasivo.UseVisualStyleBackColor = false;
            btnCensoMasivo.Click += btnCensoMasivo_Click;
            // 
            // cmbCantidad
            // 
            cmbCantidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCantidad.FormattingEnabled = true;
            cmbCantidad.Items.AddRange(new object[] { "500", "2000", "10000" });
            cmbCantidad.Location = new Point(285, 212);
            cmbCantidad.Name = "cmbCantidad";
            cmbCantidad.Size = new Size(105, 28);
            cmbCantidad.TabIndex = 52;
            // 
            // btnReiniciar
            // 
            btnReiniciar.Location = new Point(400, 210);
            btnReiniciar.Name = "btnReiniciar";
            btnReiniciar.Size = new Size(128, 32);
            btnReiniciar.TabIndex = 10;
            btnReiniciar.Text = "Reiniciar Censo";
            btnReiniciar.UseVisualStyleBackColor = true;
            btnReiniciar.Click += btnReiniciar_Click;
            // 
            // lblDetalle
            // 
            lblDetalle.AutoSize = true;
            lblDetalle.Location = new Point(25, 247);
            lblDetalle.Name = "lblDetalle";
            lblDetalle.Size = new Size(423, 20);
            lblDetalle.TabIndex = 11;
            lblDetalle.Text = "Seleccioná especie y creá tripulantes para probar el patrón.";
            // 
            // lblLista
            // 
            lblLista.AutoSize = true;
            lblLista.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblLista.Location = new Point(25, 272);
            lblLista.Name = "lblLista";
            lblLista.Size = new Size(177, 20);
            lblLista.TabIndex = 12;
            lblLista.Text = "Tripulantes registrados:";
            // 
            // lstTripulantes
            // 
            lstTripulantes.FormattingEnabled = true;
            lstTripulantes.Location = new Point(25, 295);
            lstTripulantes.Name = "lstTripulantes";
            lstTripulantes.Size = new Size(420, 204);
            lstTripulantes.TabIndex = 13;
            // 
            // txtComparacion
            // 
            txtComparacion.BackColor = Color.Black;
            txtComparacion.Font = new Font("Consolas", 8.8F);
            txtComparacion.ForeColor = Color.LimeGreen;
            txtComparacion.Location = new Point(455, 295);
            txtComparacion.Multiline = true;
            txtComparacion.Name = "txtComparacion";
            txtComparacion.ReadOnly = true;
            txtComparacion.ScrollBars = ScrollBars.Vertical;
            txtComparacion.Size = new Size(300, 204);
            txtComparacion.TabIndex = 14;
            txtComparacion.Text = "Demostración numérica:\r\nElegí la cantidad y tocá \"Ejecutar censo de:\" para comparar con y sin el patrón Flyweight.";
            // 
            // btnContinuar
            // 
            btnContinuar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnContinuar.Location = new Point(25, 507);
            btnContinuar.Name = "btnContinuar";
            btnContinuar.Size = new Size(180, 36);
            btnContinuar.TabIndex = 15;
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
            lblHistoria.Location = new Point(25, 46);
            lblHistoria.Name = "lblHistoria";
            lblHistoria.Padding = new Padding(4);
            lblHistoria.Size = new Size(730, 56);
            lblHistoria.TabIndex = 50;
            lblHistoria.Text = "Historia del capítulo";
            // 
            // PantallaFlyweight
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblHistoria);
            Controls.Add(cmbCantidad);
            Controls.Add(btnContinuar);
            Controls.Add(txtComparacion);
            Controls.Add(lstTripulantes);
            Controls.Add(lblLista);
            Controls.Add(lblDetalle);
            Controls.Add(btnReiniciar);
            Controls.Add(btnCensoMasivo);
            Controls.Add(btnCrearTripulante);
            Controls.Add(cmbRango);
            Controls.Add(lblRango);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Controls.Add(cmbEspecies);
            Controls.Add(lblEspecie);
            Controls.Add(lblContador);
            Controls.Add(lblTitulo);
            Name = "PantallaFlyweight";
            Size = new Size(770, 555);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblContador;
        private Label lblEspecie;
        private ComboBox cmbEspecies;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblRango;
        private ComboBox cmbRango;
        private Button btnCrearTripulante;
        private Button btnCensoMasivo;
        private Button btnReiniciar;
        private Label lblDetalle;
        private Label lblLista;
        private ListBox lstTripulantes;
        private TextBox txtComparacion;
        private Button btnContinuar;
        private Label lblHistoria;
        private ComboBox cmbCantidad;
    }
}
