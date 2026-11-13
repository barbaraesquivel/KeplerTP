using Kepler7.Core.Modelo;
using Kepler7.Core.Patrones.Estructurales.Flyweight;

namespace Kepler7.Game.Pantallas
{
    public partial class PantallaFlyweight : UserControl
    {
        private NavegadorPantallas navegador;
        private FabricaEspecies fabrica;
        private List<Tripulante> tripulantes;
        private int proximoId = 1;
        private int censados = 0;

        public PantallaFlyweight(NavegadorPantallas navegador)
        {
            InitializeComponent();
            Tema.Preparar(this);
            this.navegador = navegador;
            lblHistoria.Text = Historia.TextoCapitulo(Capitulo.Censo);
            fabrica = new FabricaEspecies();
            tripulantes = new List<Tripulante>();

            CargarCombos();
            ActualizarContador();
        }

        private void CargarCombos()
        {
            cmbEspecies.Items.Clear();
            foreach (var esp in DemostradorFlyweight.EspeciesDisponibles)
            {
                cmbEspecies.Items.Add($"{esp.Nombre} ({esp.Planeta})");
            }
            if (cmbEspecies.Items.Count > 0)
            {
                cmbEspecies.SelectedIndex = 0;
            }

            cmbRango.Items.Clear();
            cmbRango.Items.AddRange(new object[] { "Capitán", "Teniente", "Oficial", "Científico", "Ingeniero", "Médico" });
            cmbRango.SelectedIndex = 0;

            cmbCantidad.SelectedIndex = 0;
        }

        private void ActualizarContador()
        {
            lblContador.Text = $"Especies creadas: {fabrica.CantidadEspeciesCreadas} / Tripulantes creados: {tripulantes.Count}";
        }

        private void btnCrearTripulante_Click(object sender, EventArgs e)
        {
            if (cmbEspecies.SelectedIndex < 0) return;

            var datos = DemostradorFlyweight.EspeciesDisponibles[cmbEspecies.SelectedIndex];
            string nombre = string.IsNullOrWhiteSpace(txtNombre.Text) ? $"Tripulante_{proximoId}" : txtNombre.Text;
            string rango = cmbRango.SelectedItem != null ? cmbRango.SelectedItem.ToString() : "Tripulante";

            if (ExisteTripulante(nombre, rango))
            {
                MessageBox.Show("Ya existe un tripulante llamado " + nombre + " con el rango " + rango + ".");
                return;
            }

            int especiesAntes = fabrica.CantidadEspeciesCreadas;

            // Se solicita la instancia compartida a la fábrica
            IEspecie especie = fabrica.ObtenerEspecie(datos.Nombre, datos.Color, datos.Planeta, datos.Dieta);

            bool esInstanciaReutilizada = (fabrica.CantidadEspeciesCreadas == especiesAntes);

            Tripulante nuevo = new Tripulante(proximoId++, nombre, rango, especie);
            tripulantes.Add(nuevo);
            navegador.ServicioLogros.RegistrarUsoPatron("Flyweight");

            lstTripulantes.Items.Insert(0, $"{nuevo} [Dieta: {especie.Dieta}, Color: {especie.Color}]");

            ActualizarContador();

            if (esInstanciaReutilizada)
            {
                lblDetalle.Text = $"Tripulante #{nuevo.Id} creado. Se REUTILIZÓ la instancia compartida de '{especie.Nombre}'.";
            }
            else
            {
                lblDetalle.Text = $"Tripulante #{nuevo.Id} creado. Se registró NUEVA especie '{especie.Nombre}' en el diccionario.";
            }
        }

        private bool ExisteTripulante(string nombre, string rango)
        {
            foreach (Tripulante tripulante in tripulantes)
            {
                bool mismoNombre = string.Equals(tripulante.Nombre.Trim(), nombre.Trim(), StringComparison.OrdinalIgnoreCase);
                if (mismoNombre && tripulante.Rango == rango)
                {
                    return true;
                }
            }
            return false;
        }

        // Censo masivo con la cantidad elegida (500, 2000 o 10000)
        private void btnCensoMasivo_Click(object sender, EventArgs e)
        {
            int cantidad = int.Parse(cmbCantidad.SelectedItem.ToString());
            ResultadoComparacion resultado = DemostradorFlyweight.EjecutarComparacion(fabrica, cantidad);
            censados = cantidad;
            btnContinuar.Enabled = true;
            navegador.ServicioLogros.RegistrarUsoPatron("Flyweight");

            // Sincronizamos la cantidad de tripulantes para el contador de pantalla
            int totalTripulantesActual = tripulantes.Count + resultado.TotalTripulantes;
            lblContador.Text = $"Especies creadas: {fabrica.CantidadEspeciesCreadas} / Tripulantes creados: {totalTripulantesActual}";

            txtComparacion.Text =
                "DEMOSTRACIÓN NUMÉRICA" + Environment.NewLine +
                $"Tripulantes simulados: {resultado.TotalTripulantes:N0}" + Environment.NewLine +
                $"Especies en la estación: {resultado.EspeciesConFlyweight}" + Environment.NewLine +
                Environment.NewLine +
                $"[CON FLYWEIGHT]" + Environment.NewLine +
                $"- Objetos de especie: {resultado.EspeciesConFlyweight} (compartidos)" + Environment.NewLine +
                $"- Memoria aprox.: {resultado.MemoriaConMB:F2} MB" + Environment.NewLine +
                Environment.NewLine +
                $"[SIN PATRÓN]" + Environment.NewLine +
                $"- Objetos de especie: {resultado.EspeciesSinFlyweight:N0} (duplicados)" + Environment.NewLine +
                $"- Memoria aprox.: {resultado.MemoriaSinMB:F2} MB" + Environment.NewLine +
                Environment.NewLine +
                $"------------------------------" + Environment.NewLine +
                $"¡Ahorro de memoria!: {resultado.AhorroPorcentaje:F1}%" + Environment.NewLine +
                $"Instancias evitadas: {resultado.EspeciesSinFlyweight - resultado.EspeciesConFlyweight:N0}";

            lblDetalle.Text = "Censo de " + cantidad + " tripulantes ejecutado. Revisá el cuadro verde con los resultados.";
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            fabrica.Reiniciar();
            tripulantes.Clear();
            lstTripulantes.Items.Clear();
            proximoId = 1;
            censados = 0;
            btnContinuar.Enabled = false;
            ActualizarContador();
            txtComparacion.Text = "Demostración numérica:\r\nElegí la cantidad y tocá \"Ejecutar censo de:\" para comparar con y sin el patrón Flyweight.";
            lblDetalle.Text = "Censo reiniciado a cero.";
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            navegador.Campana.TripulantesCensados = censados;
            navegador.TerminarCapitulo(Capitulo.Censo);
        }
    }
}
