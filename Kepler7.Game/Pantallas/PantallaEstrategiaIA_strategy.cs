using Kepler7.Core.Patrones.Comportamiento.Strategy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kepler7.Game.Pantallas
{
    public partial class PantallaEstrategiaIA_strategy : UserControl
    {
        private List<Enemigo> escuadron;
        private Contexto contextoSimulado;
        public PantallaEstrategiaIA_strategy()
        {
            InitializeComponent(); 
            ConfigurarPantalla();
        }

        private void ConfigurarPantalla()
        {
            // Se simula un entorno para que la IA tome decisiones
            contextoSimulado = new Contexto { DistanciaAlJugador = 15, SaludDelJugador = 100 };

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

        private void PantallaEstrategiaIA_strategy_Load(object sender, EventArgs e)
        {

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

            txtDecision.Text = enemigoSeleccionado.EjecutarAccion(contextoSimulado);
        }
    }
}
