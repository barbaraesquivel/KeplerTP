using Kepler7.Core.Patrones.Creacionales.Prototype;

namespace Kepler7.Game.Pantallas
{
    public partial class PanelLaboratorio : UserControl
    {
        private NavegadorPantallas navegador;
        private LaboratorioClonacion laboratorio;
        private TripulanteClonable original;
        private TripulanteClonable clon;
        private string originalAlEmpezar;

        public PanelLaboratorio(NavegadorPantallas navegador)
        {
            InitializeComponent();
            this.navegador = navegador;
            CrearOriginal();
            laboratorio = new LaboratorioClonacion(100, 20);
            laboratorio.RegistrarPrototipo("Ana", original);
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

        private string SiNo(bool valor)
        {
            if (valor)
            {
                return "Sí";
            }
            return "No";
        }

        private void ActualizarPantalla()
        {
            lblRecursos.Text = "Recursos: " + laboratorio.Recursos;
            MostrarTripulante(lstOriginal, original);
            MostrarTripulante(lstClon, clon);
            if (clon == null)
            {
                lblComparacion.Text = "Cloná al tripulante para comparar.";
                return;
            }
            lblComparacion.Text = "¿Comparten la lista de habilidades? " + SiNo(ReferenceEquals(original.Habilidades, clon.Habilidades))
                + "     ¿Comparten el equipamiento? " + SiNo(ReferenceEquals(original.Equipo, clon.Equipo))
                + "\n¿El original sigue igual que al principio? " + SiNo(original.ToString() == originalAlEmpezar);
        }

        private void btnClonar_Click(object sender, EventArgs e)
        {
            TripulanteClonable nuevo = laboratorio.Fabricar("Ana");
            if (nuevo == null)
            {
                lblComparacion.Text = "No alcanzan los recursos para clonar.";
                return;
            }
            clon = nuevo;
            clon.Nombre = "Ana (clon)";
            ActualizarPantalla();
        }

        private void btnModificarClon_Click(object sender, EventArgs e)
        {
            if (clon == null)
            {
                lblComparacion.Text = "Primero tenés que clonar.";
                return;
            }
            clon.Nivel++;
            clon.Habilidades.Add("Habilidad nivel " + clon.Nivel);
            clon.Equipo.Arma = "Rifle de plasma";
            clon.Equipo.Objetos.Add("Botiquin");
            ActualizarPantalla();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            navegador.IrAInicio();
        }
    }
}
