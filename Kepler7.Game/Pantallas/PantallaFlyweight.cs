using System;
using System.Windows.Forms;
using Kepler7.Core.Patrones.Estructurales.Flyweight;

namespace Kepler7.Game.Pantallas
{
    public partial class PantallaFlyweight : UserControl // o Form, según cómo estén las otras pantallas
    {
        private NavegadorPantallas navegador;

        public PantallaFlyweight(NavegadorPantallas navegador)
        {
            InitializeComponent();
            this.navegador = navegador;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            navegador.IrAHub();
        }

        private void btnEjecutarPrueba_Click_1(object sender, EventArgs e)
        {
            ResultadoComparacion resultado = DemostradorFlyweight.EjecutarDemostracion(10000);

            lblResultado.Text = $"=== DEMOSTRACIÓN PATRÓN FLYWEIGHT ===" + Environment.NewLine +
                                $"Total Tripulantes: {resultado.TotalTripulantes:N0}" + Environment.NewLine +
                                $"Instancias de Especie en Memoria: {resultado.ObjetosEspecieCreados}" + Environment.NewLine +
                                $"----------------------------------------" + Environment.NewLine +
                                $"Memoria CON Flyweight: {resultado.MemoriaConMB:F2} MB" + Environment.NewLine +
                                $"Memoria SIN Flyweight: {resultado.MemoriaSinMB:F2} MB" + Environment.NewLine +
                                $"----------------------------------------" + Environment.NewLine +
                                $"¡Ahorro de Memoria!: {resultado.AhorroPorcentaje:F1}%";
        }

    }
}