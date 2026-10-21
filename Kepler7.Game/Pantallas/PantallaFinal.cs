namespace Kepler7.Game.Pantallas
{
    // Pantalla final (se completa en la semana 2)
    public partial class PantallaFinal : UserControl
    {
        private NavegadorPantallas navegador;

        public PantallaFinal(NavegadorPantallas navegador)
        {
            InitializeComponent();
            this.navegador = navegador;
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            navegador.IrAInicio();
        }
    }
}
