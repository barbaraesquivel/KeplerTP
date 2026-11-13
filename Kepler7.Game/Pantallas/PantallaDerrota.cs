using Kepler7.Core.Modelo;

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

        // La derrota vale: no hay reintento, se llega herido al final
        private void btnContinuar_Click(object sender, EventArgs e)
        {
            navegador.Campana.PracticaGanada = false;
            navegador.TerminarCapitulo(Capitulo.Practica);
        }
    }
}
