using Kepler7.Core.Modelo;
using Kepler7.Core.Progreso;

namespace Kepler7.Game.Pantallas
{
    // Pantalla que se muestra al ganar el combate
    public partial class PantallaVictoria : UserControl
    {
        private NavegadorPantallas navegador;

        public PantallaVictoria(NavegadorPantallas navegador, Mision mision)
        {
            InitializeComponent();
            Tema.Preparar(this);
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

            // Suma la XP y las monedas al progreso y lo guarda
            int nivelAntes = navegador.Progreso.Nivel;
            navegador.Progreso.GanarXp(xp);
            navegador.Progreso.GanarMonedas(monedas);
            navegador.Progreso.Guardar();

            navegador.Partida.XpGanada += xp;
            navegador.Partida.MonedasGanadas += monedas;

            lblRecompensas.Text = "Recompensas: +" + xp + " XP y +" + monedas + " monedas";
            MostrarProgreso(nivelAntes);
        }

        // Muestra el total acumulado y avisa si subió de nivel
        private void MostrarProgreso(int nivelAntes)
        {
            Progreso progreso = navegador.Progreso;
            lblTotal.Text = "Nivel " + progreso.Nivel
                + " - XP " + progreso.Xp + "/" + Progreso.XpPorNivel
                + " - Monedas totales " + progreso.Monedas;

            if (progreso.Nivel > nivelAntes)
            {
                lblSubioNivel.Text = "¡Subiste al nivel " + progreso.Nivel + "!";
                lblSubioNivel.Visible = true;
            }
        }

        // Efecto simple: el título cambia de color
        private void timerTitulo_Tick(object sender, EventArgs e)
        {
            if (lblTitulo.ForeColor == Color.Gold)
            {
                lblTitulo.ForeColor = Tema.Exito;
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
