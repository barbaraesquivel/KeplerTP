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

        private void btnProbarFlyweight_Click(object sender, EventArgs e)
        {
            navegador.IrAFlyweight();
        }

        private void btnProbarProxy_Click_1(object sender, EventArgs e)
        {
            navegador.IrAProxy();
        }

        private void btnProbarVisitor_Click(object sender, EventArgs e)
        {
            navegador.IrAVisitor();
        }

        private void btnProbarCombate_Click(object sender, EventArgs e)
        {
            navegador.IrACombate();
        }

        private void btnProbarLaboratorio_Click(object sender, EventArgs e)
        {
            navegador.IrALaboratorio();
        }
    }
}
