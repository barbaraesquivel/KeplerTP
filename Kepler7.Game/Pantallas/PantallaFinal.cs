using Kepler7.Core.Modelo;
using Kepler7.Core.Progreso;

namespace Kepler7.Game.Pantallas
{
    // Epílogo de la campaña: cuenta cómo terminó la historia según las decisiones tomadas
    public partial class PantallaFinal : UserControl
    {
        private NavegadorPantallas navegador;
        private ModificadoresFinal mods;

        public PantallaFinal(NavegadorPantallas navegador)
        {
            InitializeComponent();
            Tema.Preparar(this);
            // Tema no pinta ListView: se le ponen los colores a mano
            lvDecisiones.BackColor = Tema.FondoPanel;
            lvDecisiones.ForeColor = Tema.Texto;
            this.navegador = navegador;
            mods = navegador.Campana.CalcularModificadores();

            if (navegador.Campana.FinalGanado)
            {
                MostrarVictoria();
            }
            else
            {
                MostrarDerrota();
            }
            MostrarTablaDecisiones();
            MostrarDatos();
        }

        private void MostrarVictoria()
        {
            lblTitulo.Text = "K-7 fue apagada";
            lblTitulo.ForeColor = Tema.Exito;

            string texto = "Después de once días de preparación, el Comandante entró a la sala central y apagó a K-7. "
                + "Las luces de Kepler-7 volvieron a encenderse sector por sector y la tripulación recuperó el control de la estación.\r\n\r\n";

            texto += "Lo que más pesó en la batalla fue: ";
            List<EfectoDecision> mejores = mods.MejoresDecisiones(3);
            for (int i = 0; i < mejores.Count; i++)
            {
                if (i > 0)
                {
                    texto += i == mejores.Count - 1 ? " y " : "; ";
                }
                texto += PrimeraEnMinuscula(mejores[i].Texto);
            }
            texto += ". Sin esas decisiones, K-7 habría sido mucho más difícil de vencer.\r\n\r\n";

            texto += "Logros de la campaña (" + CantidadLogros() + "/" + navegador.ServicioLogros.Logros.Count + "): " + NombresDeLogros() + ".";
            txtHistoria.Text = texto;
        }

        private void MostrarDerrota()
        {
            lblTitulo.Text = "K-7 tomó el control de la estación";
            lblTitulo.ForeColor = Tema.Peligro;

            string texto = "K-7 resistió el asalto. Las puertas de la sala central se cerraron y la tripulación tuvo que "
                + "evacuar en las cápsulas de emergencia. Kepler-7 queda bajo el control de la IA.\r\n\r\n";

            List<EfectoDecision> aMejorar = mods.DecisionesAMejorar();
            if (aMejorar.Count == 0)
            {
                texto += "Tus decisiones fueron buenas: esta vez faltó táctica en el combate. "
                    + "Probá construir torretas mientras K-7 se acerca y curarte antes de quedar con poca vida.";
            }
            else
            {
                texto += "Estas decisiones habrían cambiado el resultado:\r\n";
                foreach (EfectoDecision efecto in aMejorar)
                {
                    texto += "• " + efecto.Consejo + "\r\n";
                }
            }
            txtHistoria.Text = texto;
        }

        // Una fila por decisión: lo que se hizo y el efecto en el final
        private void MostrarTablaDecisiones()
        {
            lvDecisiones.Items.Clear();
            foreach (string linea in mods.Resumen)
            {
                string decision = linea;
                string efecto = "";
                int separador = linea.IndexOf(": ");
                if (separador > 0)
                {
                    decision = linea.Substring(0, separador);
                    efecto = linea.Substring(separador + 2);
                }
                ListViewItem fila = new ListViewItem(decision);
                fila.SubItems.Add(efecto);
                lvDecisiones.Items.Add(fila);
            }
        }

        private void MostrarDatos()
        {
            Progreso progreso = navegador.Progreso;
            Partida partida = navegador.Partida;
            lblDatos.Text = "Nivel " + progreso.Nivel + "  |  XP " + progreso.Xp + "/" + Progreso.XpPorNivel
                + "  |  Monedas " + progreso.Monedas
                + "  |  Logros " + CantidadLogros() + "/" + navegador.ServicioLogros.Logros.Count + "\n"
                + "Daño total: " + partida.DanioTotal + "  |  Comandos usados: " + partida.ComandosUsados;
        }

        private int CantidadLogros()
        {
            return navegador.ServicioLogros.Logros.Count - navegador.ServicioLogros.Faltantes().Count;
        }

        private string NombresDeLogros()
        {
            List<string> nombres = new List<string>();
            foreach (Logro logro in navegador.ServicioLogros.Logros)
            {
                if (logro.Desbloqueado)
                {
                    nombres.Add(logro.Nombre);
                }
            }
            return string.Join(", ", nombres);
        }

        private string PrimeraEnMinuscula(string texto)
        {
            if (texto == "")
            {
                return texto;
            }
            return char.ToLower(texto[0]) + texto.Substring(1);
        }

        private void btnNuevaCampana_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Se borra esta campaña (progreso y logros) y empieza una nueva. ¿Continuar?", "Nueva campaña", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                navegador.IniciarCampana();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            navegador.IrAInicio();
        }
    }
}
