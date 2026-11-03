using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Windows.Forms;
using Kepler7.Core.Modelo;
using Kepler7.Core.Patrones.Comportamiento.Visitor;

namespace Kepler7.Game.Pantallas
{
    public partial class PantallaVisitor : UserControl
    {
        private List<ItemInventario> _inventario;

        private NavegadorPantallas navegador;

        public PantallaVisitor(NavegadorPantallas navegador)
        {
            InitializeComponent();
            this.navegador = navegador;
            CargarInventarioEjemplo();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            navegador.IrAHub();
        }

        private void CargarInventarioEjemplo()
        {
            _inventario = new List<ItemInventario>
            {
                new Arma("Rifle Plasma", 2, 500, 45, 9.0),
                new Arma("Pistola Láser", 5, 150, 20, 5.5),
                new Medicamento("Kit de Primeros Auxilios", 10, 50, 30, false),
                new Medicamento("Suero Antídoto (Antiguo)", 3, 80, 50, true),
                new Herramienta("Soplete de Corte", 1, 300, 85),
                new Herramienta("Llave Multiuso", 4, 40, 100)
            };
        }

        private void btnAnalizar_Click_1(object sender, EventArgs e)
        {
            // Instanciamos los dos Visitors (operaciones independientes)
            var visitorValor = new VisitorValorTotal();
            var visitorReporte = new VisitorReporte();

            // Recorremos la lista y aplicamos los visitors
            foreach (var item in _inventario)
            {
                item.Aceptar(visitorValor);
                item.Aceptar(visitorReporte);
            }

            // Desplegamos resultados
            txtReporte.Text = "=== REPORTE GENERADO POR VISITOR ===\r\n\r\n" + visitorReporte.ObtenerReporte();

            lblValorTotal.Text = $"Valor Estimado: {visitorValor.ValorTotalCreditos:N2} cr.";
            lblTotalItems.Text = $"Total Items: {visitorValor.CantidadTotalItems} (Armas: {visitorValor.TotalArmas}, Meds: {visitorValor.TotalMedicamentos}, Herramientas: {visitorValor.TotalHerramientas})";

        }
    }
}