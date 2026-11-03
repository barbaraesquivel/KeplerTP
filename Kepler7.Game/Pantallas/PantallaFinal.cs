using Kepler7.Core.Modelo;

namespace Kepler7.Game.Pantallas
{
    // Pantalla final: resumen de la partida
    public partial class PantallaFinal : UserControl
    {
        private NavegadorPantallas navegador;

        public PantallaFinal(NavegadorPantallas navegador)
        {
            InitializeComponent();
            this.navegador = navegador;
            MostrarResumen();
        }

        // Lee los datos guardados en la partida y los muestra
        private void MostrarResumen()
        {
            Partida partida = navegador.Partida;
            string nave = "ninguna";
            if (partida.NaveElegida != null)
            {
                nave = partida.NaveElegida.Tipo;
            }

            lblResumen.Text = "Misiones ganadas: " + partida.MisionesGanadas + Environment.NewLine
                + "Misiones perdidas: " + partida.MisionesPerdidas + Environment.NewLine
                + "Daño total: " + partida.DanioTotal + Environment.NewLine
                + "Comandos usados: " + partida.ComandosUsados + Environment.NewLine
                + "Nave elegida: " + nave + Environment.NewLine
                + "XP ganada: " + partida.XpGanada + Environment.NewLine
                + "Monedas ganadas: " + partida.MonedasGanadas;
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            navegador.IrAInicio();
        }
    }
}
