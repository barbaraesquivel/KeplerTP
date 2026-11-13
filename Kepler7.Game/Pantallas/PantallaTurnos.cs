using Kepler7.Core.Modelo;
using Kepler7.Core.Patrones.Comportamiento.Template_Method;

namespace Kepler7.Game.Pantallas
{
    // Capítulo Turnos (patrón Template Method): elegir la unidad de apoyo
    public partial class PantallaTurnos : UserControl
    {
        private NavegadorPantallas navegador;
        private string unidadElegida = "";

        public PantallaTurnos(NavegadorPantallas navegador)
        {
            InitializeComponent();
            Tema.Preparar(this);
            this.navegador = navegador;
            lblHistoria.Text = Historia.TextoCapitulo(Capitulo.Turnos);
            ConfigurarDesplegable();
        }

        private void ConfigurarDesplegable()
        {
            cmbUnidades.Items.Add("Soldado");
            cmbUnidades.Items.Add("Médico");
            cmbUnidades.Items.Add("Francotirador");
            cmbUnidades.SelectedIndex = 0;
        }


        private void btnEjecutarTurno_Click(object sender, EventArgs e)
        {
            if (cmbUnidades.SelectedIndex == -1) return;

            string seleccion = cmbUnidades.SelectedItem.ToString();
            TurnoUnidad unidadSeleccionada = null;

            switch (seleccion)
            {
                case "Soldado":
                    unidadSeleccionada = new TurnoSoldado();
                    break;
                case "Médico":
                    unidadSeleccionada = new TurnoMedico();
                    break;
                case "Francotirador":
                    unidadSeleccionada = new TurnoFrancotirador();
                    break;
            }

            if (unidadSeleccionada != null)
            {
                // La última unidad que ejecutó su turno es la que acompaña al final
                unidadElegida = seleccion;
                lblUnidades.Text = "Unidad de apoyo: " + unidadElegida;
                btnContinuar.Enabled = true;

                List<string> historial = unidadSeleccionada.EjecutarTurno();

                lstHistorial.Items.Clear();

                lstHistorial.Items.Add("--- 1. INICIO ---");
                lstHistorial.Items.Add(historial[0]);
                lstHistorial.Items.Add("");

                lstHistorial.Items.Add("--- 2. DECISIÓN ---");
                lstHistorial.Items.Add(historial[1]);
                lstHistorial.Items.Add("");

                lstHistorial.Items.Add("--- 3. ACCIÓN ---");
                lstHistorial.Items.Add(historial[2]);
                lstHistorial.Items.Add("");

                lstHistorial.Items.Add("--- 4. FINALIZACIÓN ---");
                lstHistorial.Items.Add(historial[3]);
            }
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            navegador.Campana.UnidadDeApoyo = unidadElegida;
            navegador.TerminarCapitulo(Capitulo.Turnos);
        }
    }
}
