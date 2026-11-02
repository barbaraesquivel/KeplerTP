namespace Kepler7.Game.Pantallas
{
    partial class PantallaInicio
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            btnJugar = new Button();
            btnTutorial = new Button();
            btnProbarFlyweight = new Button();
            btnProbarProxy = new Button();
            btnProbarVisitor = new Button();
            btnProbarCombate = new Button();
            btnProbarLaboratorio = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.Location = new Point(43, 50);
            lblTitulo.Margin = new Padding(4, 0, 4, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(182, 54);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Kepler-7";
            // 
            // btnJugar
            // 
            btnJugar.Location = new Point(43, 167);
            btnJugar.Margin = new Padding(4, 5, 4, 5);
            btnJugar.Name = "btnJugar";
            btnJugar.Size = new Size(229, 58);
            btnJugar.TabIndex = 1;
            btnJugar.Text = "Jugar";
            btnJugar.UseVisualStyleBackColor = true;
            btnJugar.Click += btnJugar_Click;
            // 
            // btnTutorial
            // 
            btnTutorial.Location = new Point(43, 250);
            btnTutorial.Margin = new Padding(4, 5, 4, 5);
            btnTutorial.Name = "btnTutorial";
            btnTutorial.Size = new Size(229, 58);
            btnTutorial.TabIndex = 2;
            btnTutorial.Text = "Tutorial";
            btnTutorial.UseVisualStyleBackColor = true;
            btnTutorial.Click += btnTutorial_Click;
            // 
            // btnProbarFlyweight
            // 
            btnProbarFlyweight.Location = new Point(43, 329);
            btnProbarFlyweight.Margin = new Padding(4, 5, 4, 5);
            btnProbarFlyweight.Name = "btnProbarFlyweight";
            btnProbarFlyweight.Size = new Size(229, 58);
            btnProbarFlyweight.TabIndex = 3;
            btnProbarFlyweight.Text = "Probar Flyweight";
            btnProbarFlyweight.UseVisualStyleBackColor = true;
            btnProbarFlyweight.Click += btnProbarFlyweight_Click;
            // 
            // btnProbarProxy
            // 
            btnProbarProxy.Location = new Point(43, 408);
            btnProbarProxy.Margin = new Padding(4, 5, 4, 5);
            btnProbarProxy.Name = "btnProbarProxy";
            btnProbarProxy.Size = new Size(229, 58);
            btnProbarProxy.TabIndex = 4;
            btnProbarProxy.Text = "Probar Proxy";
            btnProbarProxy.UseVisualStyleBackColor = true;
            btnProbarProxy.Click += btnProbarProxy_Click_1;
            // 
            // btnProbarVisitor
            // 
            btnProbarVisitor.Location = new Point(43, 487);
            btnProbarVisitor.Margin = new Padding(4, 5, 4, 5);
            btnProbarVisitor.Name = "btnProbarVisitor";
            btnProbarVisitor.Size = new Size(229, 58);
            btnProbarVisitor.TabIndex = 5;
            btnProbarVisitor.Text = "Probar Visitor";
            btnProbarVisitor.UseVisualStyleBackColor = true;
            btnProbarVisitor.Click += btnProbarVisitor_Click;
            //
            // btnProbarCombate
            //
            btnProbarCombate.Location = new Point(43, 566);
            btnProbarCombate.Margin = new Padding(4, 5, 4, 5);
            btnProbarCombate.Name = "btnProbarCombate";
            btnProbarCombate.Size = new Size(229, 58);
            btnProbarCombate.TabIndex = 6;
            btnProbarCombate.Text = "Probar Combate";
            btnProbarCombate.UseVisualStyleBackColor = true;
            btnProbarCombate.Click += btnProbarCombate_Click;
            //
            // btnProbarLaboratorio
            //
            btnProbarLaboratorio.Location = new Point(43, 645);
            btnProbarLaboratorio.Margin = new Padding(4, 5, 4, 5);
            btnProbarLaboratorio.Name = "btnProbarLaboratorio";
            btnProbarLaboratorio.Size = new Size(229, 58);
            btnProbarLaboratorio.TabIndex = 7;
            btnProbarLaboratorio.Text = "Probar Laboratorio";
            btnProbarLaboratorio.UseVisualStyleBackColor = true;
            btnProbarLaboratorio.Click += btnProbarLaboratorio_Click;
            //
            // PantallaInicio
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnProbarLaboratorio);
            Controls.Add(btnProbarCombate);
            Controls.Add(btnProbarVisitor);
            Controls.Add(btnProbarProxy);
            Controls.Add(btnProbarFlyweight);
            Controls.Add(lblTitulo);
            Controls.Add(btnJugar);
            Controls.Add(btnTutorial);
            Margin = new Padding(4, 5, 4, 5);
            Name = "PantallaInicio";
            Size = new Size(1143, 750);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Button btnJugar;
        private Button btnTutorial;
        private Button btnProbarFlyweight;
        private Button btnProbarProxy;
        private Button btnProbarVisitor;
        private Button btnProbarCombate;
        private Button btnProbarLaboratorio;
    }
}
