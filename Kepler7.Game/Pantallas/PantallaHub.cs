using Kepler7.Core.Progreso;

namespace Kepler7.Game.Pantallas
{
    // Pantalla central de la estación: desde acá se va a cada sector
    public partial class PantallaHub : UserControl
    {
        private NavegadorPantallas navegador;

        public PantallaHub(NavegadorPantallas navegador)
        {
            InitializeComponent();
            Tema.Preparar(this);
            this.navegador = navegador;
        }

        private void btnHangar_Click(object sender, EventArgs e)
        {
            navegador.IrAHangar();
        }

        private void btnLaboratorio_Click(object sender, EventArgs e)
        {
            navegador.IrALaboratorio();
        }

        private void btnControlCentral_Click(object sender, EventArgs e)
        {
            navegador.IrAControlCentral();
        }

        private void btnCenso_Click(object sender, EventArgs e)
        {
            navegador.IrAFlyweight();
        }

        private void btnBoveda_Click(object sender, EventArgs e)
        {
            navegador.IrAProxy();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            navegador.IrAVisitor();
        }

        // La misión muestra el briefing y desde ahí empieza el combate
        private void btnMision_Click(object sender, EventArgs e)
        {
            navegador.IrAMision();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            navegador.IrAInicio();
        }

        private void PantallaHub_Load(object sender, EventArgs e)
        {
            MostrarProgreso();
        }

        // Muestra nivel, XP y monedas guardados del jugador
        private void MostrarProgreso()
        {
            Progreso progreso = navegador.Progreso;
            lblProgreso.Text = "Nivel " + progreso.Nivel
                + "  |  XP " + progreso.Xp + "/" + Progreso.XpPorNivel
                + "  |  Monedas " + progreso.Monedas;
        }

        private void btnComunicaciones_Click(object sender, EventArgs e)
        {
            navegador.IrAComunicaciones();
        }

        private void btnEstrategiaIA_Click(object sender, EventArgs e)
        {
            navegador.IrAEstrategiaIA();
        }

        private void btnTurnos_Click(object sender, EventArgs e)
        {
            navegador.IrATurnos();
        }

        private void btnLogros_Click(object sender, EventArgs e)
        {
            navegador.IrALogros();
        }
    }
}
