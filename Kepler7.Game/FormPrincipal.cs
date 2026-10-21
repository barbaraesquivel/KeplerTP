namespace Kepler7.Game
{
    // Formulario principal del juego
    public partial class FormPrincipal : Form
    {
        private NavegadorPantallas navegador;

        public FormPrincipal()
        {
            InitializeComponent();
            // El formulario es el contenedor donde se van cambiando las pantallas
            navegador = new NavegadorPantallas(this);
            navegador.IrAInicio();
        }
    }
}
