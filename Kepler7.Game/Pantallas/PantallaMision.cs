using Kepler7.Core.Modelo;
using Kepler7.Core.Patrones.Creacionales.Builder;

namespace Kepler7.Game.Pantallas
{
    // Briefing de la misión antes del combate
    public partial class PantallaMision : UserControl
    {
        private NavegadorPantallas navegador;

        public PantallaMision(NavegadorPantallas navegador)
        {
            InitializeComponent();
            this.navegador = navegador;
            MostrarMision();
        }

        private void MostrarMision()
        {
            Mision mision = navegador.Mision;
            lblTitulo.Text = mision.Nombre;
            lblObjetivo.Text = "Objetivo: " + mision.Objetivo;

            Nave nave = navegador.Partida.NaveElegida;
            if (nave == null)
            {
                lblNave.Text = "Sin nave: elegí una en el Hangar";
            }
            else
            {
                lblNave.Text = "Nave: " + nave.Tipo + " (bonus de recursos: +" + nave.BonusRecursos + "%)";
            }
        }

        private void btnComenzar_Click(object sender, EventArgs e)
        {
            navegador.IrACombate();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            navegador.IrAHub();
        }
    }
}
