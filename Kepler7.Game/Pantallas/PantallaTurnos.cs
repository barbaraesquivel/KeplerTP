using Kepler7.Core.Patrones.Comportamiento.Template_Method;
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
    public partial class PantallaTurnos : UserControl
    {
        public PantallaTurnos()
        {
            InitializeComponent();
            ConfigurarDesplegable();
        }

        private void ConfigurarDesplegable()
        {
            cmbUnidades.Items.Add("Soldado");
            cmbUnidades.Items.Add("Médico");
            cmbUnidades.Items.Add("Francotirador");
            cmbUnidades.Items.Add("Comandante");
            cmbUnidades.SelectedIndex = 0;
        }


        private void PantallaTurnos_Load(object sender, EventArgs e)
        {

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
                case "Comandante":
                    unidadSeleccionada = new TurnoComandante();
                    break;
            }

            if (unidadSeleccionada != null)
            {
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
    }
}
