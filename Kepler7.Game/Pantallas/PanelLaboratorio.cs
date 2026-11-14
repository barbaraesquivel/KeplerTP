using Kepler7.Core.Modelo;
using Kepler7.Core.Patrones.Creacionales.Prototype;

namespace Kepler7.Game.Pantallas
{
    public partial class PanelLaboratorio : UserControl
    {
        private NavegadorPantallas navegador;
        private LaboratorioClonacion laboratorio;
        private TripulanteClonable original;
        private List<TripulanteClonable> clones = new List<TripulanteClonable>();
        private string originalAlEmpezar;
        private PruebaIndependencia prueba = new PruebaIndependencia();

        public PanelLaboratorio(NavegadorPantallas navegador)
        {
            InitializeComponent();
            Tema.Preparar(this);
            this.navegador = navegador;
            lblHistoria.Text = Historia.TextoCapitulo(Capitulo.Laboratorio);
            // Clonar es opcional: se puede seguir sin clonar
            btnContinuar.Enabled = true;
            CrearOriginal();
            laboratorio = new LaboratorioClonacion(60, 20);
            laboratorio.RegistrarPrototipo("Ana", original);
            // Registrar el prototipo ya usa el patrón (clonar es opcional en la campaña)
            navegador.ServicioLogros.RegistrarUsoPatron("Prototype");
            btnClonar.Text = "Clonar (cuesta " + laboratorio.CostoClonacion + ")";
            ActualizarPantalla();
        }

        private void CrearOriginal()
        {
            Equipamiento equipo = new Equipamiento("Pistola laser", "Traje espacial");
            equipo.Objetos.Add("Linterna");
            original = new TripulanteClonable("Ana", "Humana", 3, equipo);
            original.Habilidades.Add("Pilotar");
            original.Habilidades.Add("Reparar");
            originalAlEmpezar = original.ToString();
        }

        private void MostrarTripulante(ListBox lista, TripulanteClonable tripulante)
        {
            lista.Items.Clear();
            if (tripulante == null)
            {
                lista.Items.Add("(todavía no hay clon)");
                return;
            }
            lista.Items.Add("Nombre: " + tripulante.Nombre);
            lista.Items.Add("Especie: " + tripulante.Especie);
            lista.Items.Add("Nivel: " + tripulante.Nivel);
            lista.Items.Add("Habilidades:");
            foreach (string habilidad in tripulante.Habilidades)
            {
                lista.Items.Add("   - " + habilidad);
            }
            lista.Items.Add("Arma: " + tripulante.Equipo.Arma);
            lista.Items.Add("Traje: " + tripulante.Equipo.Traje);
            lista.Items.Add("Objetos:");
            foreach (string objeto in tripulante.Equipo.Objetos)
            {
                lista.Items.Add("   - " + objeto);
            }
        }

        private TripulanteClonable ClonSeleccionado()
        {
            if (cmbClones.SelectedIndex < 0)
            {
                return null;
            }
            return clones[cmbClones.SelectedIndex];
        }

        private void ActualizarPantalla()
        {
            TripulanteClonable clon = ClonSeleccionado();
            lblRecursos.Text = "Recursos: " + laboratorio.Recursos + "  |  Clones: " + clones.Count + "/" + Campana.MaxClones;
            btnClonar.Enabled = clones.Count < Campana.MaxClones && laboratorio.Recursos >= laboratorio.CostoClonacion;
            btnModificarClon.Enabled = clon != null;
            MostrarTripulante(lstOriginal, original);
            MostrarTripulante(lstClon, clon);
            if (clon == null)
            {
                lblClon.Text = "Clon";
                lblComparacion.Text = "Cloná al tripulante para comparar.";
                return;
            }
            lblClon.Text = clon.Nombre;
            lblComparacion.Text = string.Join("\n", prueba.Comparar(original, originalAlEmpezar, clon));
        }

        private void btnClonar_Click(object sender, EventArgs e)
        {
            TripulanteClonable nuevo = laboratorio.Fabricar("Ana");
            if (nuevo == null)
            {
                lblComparacion.Text = "No alcanzan los recursos para clonar.";
                return;
            }
            nuevo.Nombre = "Ana (clon " + (clones.Count + 1) + ")";
            clones.Add(nuevo);
            cmbClones.Items.Add(nuevo.Nombre);
            cmbClones.SelectedIndex = clones.Count - 1;
            navegador.ServicioLogros.RegistrarUsoPatron("Prototype");
            ActualizarPantalla();
        }

        private void cmbClones_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarPantalla();
        }

        private void btnModificarClon_Click(object sender, EventArgs e)
        {
            TripulanteClonable clon = ClonSeleccionado();
            if (clon == null)
            {
                lblComparacion.Text = "Primero tenés que clonar.";
                return;
            }
            prueba.ModificarClon(clon);
            ActualizarPantalla();
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            navegador.Campana.ClonesCreados = clones.Count;
            navegador.TerminarCapitulo(Capitulo.Laboratorio);
        }
    }
}
