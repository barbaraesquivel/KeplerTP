namespace Kepler7.Game.Pantallas
{
    // Pantalla de inicio del juego
    public partial class PantallaInicio : UserControl
    {
        private NavegadorPantallas navegador;

        public PantallaInicio(NavegadorPantallas navegador)
        {
            InitializeComponent();
            Tema.Preparar(this);
            this.navegador = navegador;
        }

        // Empieza una campaña nueva desde cero
        private void btnJugar_Click(object sender, EventArgs e)
        {
            navegador.IniciarCampana();
        }

        private void btnTutorial_Click(object sender, EventArgs e)
        {
            navegador.IrATutorial();
        }

        // Cierra la aplicación
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
