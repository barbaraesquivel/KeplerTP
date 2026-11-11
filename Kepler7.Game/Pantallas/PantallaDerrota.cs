namespace Kepler7.Game.Pantallas
{
    // Pantalla que se muestra al perder el combate
    public partial class PantallaDerrota : UserControl
    {
        private NavegadorPantallas navegador;

        public PantallaDerrota(NavegadorPantallas navegador)
        {
            InitializeComponent();
            Tema.Preparar(this);
            this.navegador = navegador;
        }

        // Vuelve al briefing para intentar la misión otra vez
        private void btnReintentar_Click(object sender, EventArgs e)
        {
            navegador.IrAMision();
        }

        private void btnHub_Click(object sender, EventArgs e)
        {
            navegador.IrAHub();
        }
    }
}
