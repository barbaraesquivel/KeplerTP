using Kepler7.Core.Modelo;

namespace Kepler7.Game.Pantallas
{
    // Pantalla que se muestra al ganar el combate
    public partial class PantallaVictoria : UserControl
    {
        private NavegadorPantallas navegador;

        public PantallaVictoria(NavegadorPantallas navegador, Mision mision)
        {
            InitializeComponent();
            this.navegador = navegador;
            DarRecompensas(mision);
            timerTitulo.Start();
        }

        // Calcula las recompensas (con el bonus de la nave) y las suma a la partida
        private void DarRecompensas(Mision mision)
        {
            int xp = mision.RecompensaXp;
            int monedas = mision.RecompensaMonedas;
            if (navegador.Partida.NaveElegida != null)
            {
                monedas = monedas + monedas * navegador.Partida.NaveElegida.BonusRecursos / 100;
            }

            // Avisar a IProgreso (implementado por Lautaro)
            navegador.Progreso.GanarXp(xp);
            navegador.Progreso.GanarMonedas(monedas);
            navegador.Progreso.Guardar();

            navegador.Partida.XpGanada += xp;
            navegador.Partida.MonedasGanadas += monedas;

            lblRecompensas.Text = "Recompensas: +" + xp + " XP y +" + monedas + " monedas";
        }

        // Efecto simple: el título cambia de color
        private void timerTitulo_Tick(object sender, EventArgs e)
        {
            if (lblTitulo.ForeColor == Color.Gold)
            {
                lblTitulo.ForeColor = Color.Green;
            }
            else
            {
                lblTitulo.ForeColor = Color.Gold;
            }
        }

        private void btnHub_Click(object sender, EventArgs e)
        {
            timerTitulo.Stop();
            navegador.IrAHub();
        }

        private void btnResumen_Click(object sender, EventArgs e)
        {
            timerTitulo.Stop();
            navegador.IrAFinal();
        }
    }
}
