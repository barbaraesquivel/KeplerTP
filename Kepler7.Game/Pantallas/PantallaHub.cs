namespace Kepler7.Game.Pantallas
{
    // Pantalla central de la estación (se completa en la semana 2)
    public partial class PantallaHub : UserControl
    {
        private NavegadorPantallas navegador;

        public PantallaHub(NavegadorPantallas navegador)
        {
            InitializeComponent();
            this.navegador = navegador;
        }

        private void btnMision_Click(object sender, EventArgs e)
        {
            navegador.IrAMision();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            navegador.IrAInicio();
        }
    }
}
