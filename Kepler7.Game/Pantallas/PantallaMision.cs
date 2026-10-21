namespace Kepler7.Game.Pantallas
{
    // Pantalla de la misión (se completa en la semana 2)
    public partial class PantallaMision : UserControl
    {
        private NavegadorPantallas navegador;

        public PantallaMision(NavegadorPantallas navegador)
        {
            InitializeComponent();
            this.navegador = navegador;
        }

        private void btnTerminar_Click(object sender, EventArgs e)
        {
            navegador.IrAFinal();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            navegador.IrAHub();
        }
    }
}
