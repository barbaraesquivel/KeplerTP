namespace Kepler7.Game.Pantallas
{
    // Pantalla del Control Central (patrón Facade)
    public partial class PantallaControlCentral : UserControl
    {
        private NavegadorPantallas navegador;

        public PantallaControlCentral(NavegadorPantallas navegador)
        {
            InitializeComponent();
            this.navegador = navegador;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            navegador.IrAHub();
        }
    }
}
