namespace Kepler7.Game.Pantallas
{
    // Pantalla del tutorial (se completa en la semana 2)
    public partial class PantallaTutorial : UserControl
    {
        private NavegadorPantallas navegador;

        public PantallaTutorial(NavegadorPantallas navegador)
        {
            InitializeComponent();
            this.navegador = navegador;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            navegador.IrAInicio();
        }
    }
}
