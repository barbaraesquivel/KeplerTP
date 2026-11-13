using Kepler7.Core.Modelo;
using Kepler7.Core.Patrones.Comportamiento.Visitor;

namespace Kepler7.Game.Pantallas
{
    // Capítulo Inventario (patrón Visitor): comprar equipo con las monedas
    public partial class PantallaVisitor : UserControl
    {
        private List<IItem> _inventario;
        private NavegadorPantallas navegador;

        public PantallaVisitor(NavegadorPantallas navegador)
        {
            InitializeComponent();
            Tema.Preparar(this);
            this.navegador = navegador;
            lblHistoria.Text = Historia.TextoCapitulo(Capitulo.Inventario);
            InicializarInventario();
            MostrarSaldo();

            if (cmbVisitante.Items.Count > 0)
            {
                cmbVisitante.SelectedIndex = 0;
            }
        }

        private void InicializarInventario()
        {
            _inventario = CatalogoTienda.CrearItems();
            ActualizarListaInventario();
        }

        // Muestra las monedas y habilita Continuar si ya compró o si no le alcanza para nada
        private void MostrarSaldo()
        {
            int monedas = navegador.Progreso.Monedas;
            lblSaldo.Text = "Monedas: " + monedas + "  |  Compraste: " + navegador.Campana.ItemsComprados.Count;
            bool compro = navegador.Campana.ItemsComprados.Count > 0;
            btnContinuar.Enabled = compro || !AlcanzaParaAlgo(monedas);
        }

        private bool AlcanzaParaAlgo(int monedas)
        {
            foreach (IItem item in _inventario)
            {
                if (!YaComprado(item) && item.Precio <= monedas)
                {
                    return true;
                }
            }
            return false;
        }

        // Cada ítem de la tienda se puede comprar una sola vez
        private bool YaComprado(IItem item)
        {
            return navegador.Campana.ItemsComprados.Contains(item.Nombre);
        }

        // Compra el ítem elegido (el precio lo suma el Visitor CalculadorPrecio)
        private void btnComprar_Click(object sender, EventArgs e)
        {
            if (lstInventario.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccioná un ítem de la lista primero.");
                return;
            }

            IItem item = _inventario[lstInventario.SelectedIndex];
            if (YaComprado(item))
            {
                MessageBox.Show("Ya compraste " + item.Nombre + ". Cada ítem se compra una sola vez.");
                return;
            }
            List<IItem> carrito = new List<IItem> { item };
            if (!navegador.Campana.ComprarCarrito(carrito, navegador.Progreso))
            {
                MessageBox.Show("No te alcanzan las monedas para " + item.Nombre + " (cuesta " + item.Precio + ", tenés " + navegador.Progreso.Monedas + ").");
                return;
            }

            navegador.Progreso.Guardar();
            navegador.ServicioLogros.RegistrarUsoPatron("Visitor");
            txtResultado.Text = "Compraste " + item.Nombre + " por " + item.Precio + " monedas.";
            ActualizarListaInventario();
            MostrarSaldo();
        }

        private void ActualizarListaInventario()
        {
            lstInventario.Items.Clear();
            foreach (var item in _inventario)
            {
                string marca = YaComprado(item) ? "[COMPRADO] " : "";
                lstInventario.Items.Add(marca + item.ToString());
            }
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            IVisitor visitante;

            switch (cmbVisitante.SelectedIndex)
            {
                case 0:
                    visitante = new CalculadorPrecio();
                    break;
                case 1:
                    visitante = new ContadorArmas();
                    break;
                case 2:
                    visitante = new AplicadorVeneno();
                    break;
                default:
                    visitante = new CalculadorPrecio();
                    break;
            }

            // Recorremos los ítems y cada uno acepta al visitor (Doble Dispatch)
            foreach (var item in _inventario)
            {
                item.Aceptar(visitante);
            }

            // Mostramos el resultado generado por el Visitor en el cuadro de texto
            txtResultado.Text = visitante.ObtenerResultado();
            navegador.ServicioLogros.RegistrarUsoPatron("Visitor");

            // Si se aplicó veneno, los ítems cambiaron su estado, actualizamos la lista
            ActualizarListaInventario();
        }

        private void btnRestablecer_Click(object sender, EventArgs e)
        {
            InicializarInventario();
            txtResultado.Text = "Inventario restablecido a su estado original.";
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            navegador.TerminarCapitulo(Capitulo.Inventario);
        }
    }
}
