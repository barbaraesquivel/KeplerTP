using Kepler7.Core.Patrones.Comportamiento.Visitor;

namespace Kepler7.Game.Pantallas
{
    public partial class PantallaVisitor : UserControl
    {
        private List<IItem> _inventario;
        private NavegadorPantallas navegador;

        public PantallaVisitor(NavegadorPantallas navegador)
        {
            InitializeComponent();
            Tema.Preparar(this);
            this.navegador = navegador;
            InicializarInventario();

            if (cmbVisitante.Items.Count > 0)
            {
                cmbVisitante.SelectedIndex = 0;
            }
        }

        private void InicializarInventario()
        {
            _inventario = new List<IItem>
            {
                new Arma("Rifle de Plasma", 500, 45),
                new Arma("Pistola Láser", 150, 20),
                new Arma("Cuchillo Táctico", 80, 15),
                new Pocion("Poción de Salud", 50, 40),
                new Pocion("Elixir de Regeneración", 120, 100),
                new Armadura("Traje Espacial Blindado", 600, 50),
                new Armadura("Escudo de Nanofibra", 350, 30)
            };

            ActualizarListaInventario();
        }

        private void ActualizarListaInventario()
        {
            lstInventario.Items.Clear();
            foreach (var item in _inventario)
            {
                lstInventario.Items.Add(item.ToString());
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

        private void btnVolver_Click(object sender, EventArgs e)
        {
            navegador.IrAHub();
        }
    }
}
