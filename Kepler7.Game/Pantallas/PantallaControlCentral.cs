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
            this.navegador = navegador;
            ActualizarPantalla();
        }

        private void btnIniciarTurno_Click(object sender, EventArgs e)
        {
            control.IniciarTurno();
            ActualizarPantalla();
        }

        private void btnEmergencia_Click(object sender, EventArgs e)
        {
            control.EntrarEnEmergencia();
            ActualizarPantalla();
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            control.ApagarEstacion();
            ActualizarPantalla();
        }

        // Muestra estado, energía y los pasos de la última operación
        private void ActualizarPantalla()
        {
            lblEstado.Text = "Estado: " + control.Estado;
            lblEstado.ForeColor = ColorDelEstado(control.Estado);

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
                return Color.Green;
            }
            if (estado == EstadoEstacion.Emergencia)
            {
                return Color.Red;
            }
            return Color.Gray;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            navegador.IrAHub();
        }
    }
}
