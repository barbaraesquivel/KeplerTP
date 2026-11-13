using Kepler7.Core.Modelo;
using Kepler7.Core.Patrones.Comportamiento.Strategy;

namespace Kepler7.Game.Pantallas
{
    // Capítulo Estrategia IA (patrón Strategy): estudiar un algoritmo de K-7
    public partial class PantallaEstrategiaIA : UserControl
    {
        private NavegadorPantallas navegador;
        private string iaEstudiada = "";
        private List<Enemigo> escuadron;
        private Contexto contextoSimulado;

        public PantallaEstrategiaIA(NavegadorPantallas navegador)
        {
            InitializeComponent();
            Tema.Preparar(this);
            this.navegador = navegador;
            lblHistoria.Text = Historia.TextoCapitulo(Capitulo.EstrategiaIA);
            ConfigurarPantalla();
        }

        private void ConfigurarPantalla()
        {
            // Se simula un entorno para que la IA tome decisiones
            contextoSimulado = new Contexto { DistanciaAlJugador = 1, SaludDelJugador = 100 };

            escuadron = new List<Enemigo>
            {
                new Enemigo("Zángano Explorador", 50, new IAAleatoria()),
                new Enemigo("Guardián Pesado", 200, new IADefensiva()),
                new Enemigo("Cazador Élite", 18, new IACalculadora())
            };

            cmbEstrategias.Items.AddRange(new object[] { "IAAgresiva", "IADefensiva", "IAAleatoria", "IACalculadora" });

            RefrescarLista();
        }

        private void RefrescarLista()
        {
            int seleccionPrevia = lstEnemigos.SelectedIndex;
            lstEnemigos.Items.Clear();

            foreach (var enemigo in escuadron)
            {
                lstEnemigos.Items.Add($"{enemigo.Nombre} | IA Actual: {enemigo.NombreEstrategiaActual}");
            }

            if (seleccionPrevia >= 0) lstEnemigos.SelectedIndex = seleccionPrevia;
        }

        private void cmbEstrategia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstEnemigos.SelectedIndex == -1 || cmbEstrategias.SelectedIndex == -1) return;

            Enemigo enemigoSeleccionado = escuadron[lstEnemigos.SelectedIndex];
            string seleccion = cmbEstrategias.SelectedItem.ToString();

            IEstrategiaIA nuevaIA = seleccion switch
            {
                "IAAgresiva" => new IAAgresiva(),
                "IADefensiva" => new IADefensiva(),
                "IACalculadora" => new IACalculadora(),
                _ => new IAAleatoria()
            };

            enemigoSeleccionado.SetEstrategia(nuevaIA);
            RefrescarLista();
        }

        private void btnEjecutarTurno_Click(object sender, EventArgs e)
        {
            if (lstEnemigos.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccioná un enemigo de la lista primero.");
                return;
            }

            Enemigo enemigoSeleccionado = escuadron[lstEnemigos.SelectedIndex];

            DecisionIA decision = enemigoSeleccionado.EjecutarAccion(contextoSimulado);
            txtDecision.Text = decision.Texto + Environment.NewLine + "Acción elegida: " + decision.Accion;

            // La estrategia cuya decisión se vio es la que queda estudiada
            iaEstudiada = enemigoSeleccionado.NombreEstrategiaActual;
            txtDecision.Text += Environment.NewLine + Environment.NewLine + "Estrategia estudiada: " + iaEstudiada;
            btnContinuar.Enabled = true;
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            navegador.Campana.IaAnalizada = iaEstudiada;
            navegador.TerminarCapitulo(Capitulo.EstrategiaIA);
        }
    }
}
