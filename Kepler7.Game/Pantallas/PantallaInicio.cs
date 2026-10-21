namespace Kepler7.Game.Pantallas
{
    // Pantalla de inicio del juego
    public partial class PantallaInicio : UserControl
    {
        private NavegadorPantallas navegador;

        public PantallaInicio(NavegadorPantallas navegador)
        {
            InitializeComponent();
            this.navegador = navegador;
        }

        private void btnJugar_Click(object sender, EventArgs e)
        {
            navegador.IrAHub();
        }

        private void btnTutorial_Click(object sender, EventArgs e)
        {
            navegador.IrATutorial();
        }
    }
}
