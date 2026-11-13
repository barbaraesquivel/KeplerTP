using Kepler7.Core.Modelo;
using Kepler7.Core.Patrones.Estructurales.Facade;

namespace Kepler7.Game.Pantallas
{
    // Pantalla del Control Central (patrón Facade)
    public partial class PantallaControlCentral : UserControl
    {
        private NavegadorPantallas navegador;

        // Una sola fachada mientras la pantalla está abierta
        private ControlCentral control = new ControlCentral();

        public PantallaControlCentral(NavegadorPantallas navegador)
        {
            InitializeComponent();
            Tema.Preparar(this);
            this.navegador = navegador;
            lblHistoria.Text = Historia.TextoCapitulo(Capitulo.ControlCentral);
            ActualizarPantalla();
        }

        private void btnIniciarTurno_Click(object sender, EventArgs e)
        {
            control.IniciarTurno();
            navegador.ServicioLogros.RegistrarUsoPatron("Facade");
            // Con un turno iniciado ya se puede seguir (aunque después se apague)
            btnContinuar.Enabled = true;
            ActualizarPantalla();
        }

        private void btnEmergencia_Click(object sender, EventArgs e)
        {
            control.EntrarEnEmergencia();
            navegador.ServicioLogros.RegistrarUsoPatron("Facade");
            ActualizarPantalla();
        }

        private void btnSalirEmergencia_Click(object sender, EventArgs e)
        {
            control.SalirDeEmergencia();
            navegador.ServicioLogros.RegistrarUsoPatron("Facade");
            ActualizarPantalla();
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            control.ApagarEstacion();
            navegador.ServicioLogros.RegistrarUsoPatron("Facade");
            ActualizarPantalla();
        }

        // Muestra estado, energía y los pasos de la última operación
        private void ActualizarPantalla()
        {
            lblEstado.Text = "Estado: " + control.Estado;
            lblEstado.ForeColor = ColorDelEstado(control.Estado);
            bool hayEnergia = control.NivelEnergia > 0;
            btnIniciarTurno.Enabled = hayEnergia && control.Estado == EstadoEstacion.Apagada;
            btnEmergencia.Enabled = hayEnergia && control.Estado == EstadoEstacion.Normal;
            btnSalirEmergencia.Enabled = control.Estado == EstadoEstacion.Emergencia;
            btnApagar.Enabled = control.Estado != EstadoEstacion.Apagada;

            barEnergia.Value = control.NivelEnergia;
            lblEnergia.Text = "Energía: " + control.NivelEnergia;

            lstSecuencia.Items.Clear();
            foreach (string paso in control.Secuencia)
            {
                lstSecuencia.Items.Add(paso);
            }
        }

        private Color ColorDelEstado(EstadoEstacion estado)
        {
            if (estado == EstadoEstacion.Normal)
            {
                return Tema.Exito;
            }
            if (estado == EstadoEstacion.Emergencia)
            {
                return Tema.Peligro;
            }
            return Color.DarkGray;
        }

        // Guarda cómo quedó la estación
        private void btnContinuar_Click(object sender, EventArgs e)
        {
            navegador.Campana.EnergiaRestante = control.NivelEnergia;
            navegador.Campana.EstadoEstacion = control.Estado;
            navegador.TerminarCapitulo(Capitulo.ControlCentral);
        }
    }
}
