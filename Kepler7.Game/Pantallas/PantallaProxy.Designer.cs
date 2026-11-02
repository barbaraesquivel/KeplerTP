namespace Kepler7.Game.Pantallas
{
    partial class PantallaProxy
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
            cmbRol = new ComboBox();
            label1 = new Label();
            btnAcceder = new Button();
            txtResultado = new TextBox();
            lstLogs = new ListBox();
            txtUsuario = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // cmbRol
            // 
            cmbRol.AutoCompleteCustomSource.AddRange(new string[] { "Capitán", "Oficial de Seguridad", "Ingeniero", "Tripulante", "Cocinero" });
            cmbRol.FormattingEnabled = true;
            cmbRol.Location = new Point(462, 75);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(182, 33);
            cmbRol.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(412, 80);
            label1.Name = "label1";
            label1.Size = new Size(41, 25);
            label1.TabIndex = 1;
            label1.Text = "Rol:";
            // 
            // btnAcceder
            // 
            btnAcceder.Location = new Point(412, 114);
            btnAcceder.Name = "btnAcceder";
            btnAcceder.Size = new Size(232, 68);
            btnAcceder.TabIndex = 2;
            btnAcceder.Text = "Intentar Acceso a Bóveda";
            btnAcceder.UseVisualStyleBackColor = true;
            btnAcceder.Click += btnAcceder_Click_1;
            // 
            // txtResultado
            // 
            txtResultado.Location = new Point(412, 203);
            txtResultado.Name = "txtResultado";
            txtResultado.Size = new Size(232, 31);
            txtResultado.TabIndex = 3;
            // 
            // lstLogs
            // 
            lstLogs.FormattingEnabled = true;
            lstLogs.ItemHeight = 25;
            lstLogs.Location = new Point(31, 258);
            lstLogs.Name = "lstLogs";
            lstLogs.Size = new Size(1090, 204);
            lstLogs.TabIndex = 4;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(463, 38);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(181, 31);
            txtUsuario.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(375, 44);
            label2.Name = "label2";
            label2.Size = new Size(82, 25);
            label2.TabIndex = 6;
            label2.Text = "Nombre:";
            // 
            // PantallaProxy
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label2);
            Controls.Add(txtUsuario);
            Controls.Add(lstLogs);
            Controls.Add(txtResultado);
            Controls.Add(btnAcceder);
            Controls.Add(label1);
            Controls.Add(cmbRol);
            Name = "PantallaProxy";
            Size = new Size(1160, 482);
            Load += PantallaProxy_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbRol;
        private Label label1;
        private Button btnAcceder;
        private TextBox txtResultado;
        private ListBox lstLogs;
        private TextBox txtUsuario;
        private Label label2;
    }
}
