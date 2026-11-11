namespace Kepler7.Game.Pantallas
{
    // Pantalla del tutorial: varias páginas de texto
    public partial class PantallaTutorial : UserControl
    {
        private NavegadorPantallas navegador;

        // Textos de cada página del tutorial
        private string[] paginas =
        {
            "¿Qué es Kepler-7?\n\n" +
            "Kepler-7 es una estación espacial en el borde de la galaxia. " +
            "Una nave alien atacó la estación y ocupó el sector 4. " +
            "Sos el comandante y tenés que poner la estación en orden y recuperar el sector.",

            "¿Cómo se juega?\n\n" +
            "Desde el hub vas a cada sector de la estación: el Hangar para construir tu nave, " +
            "el Laboratorio, el Control Central, el Censo, la Bóveda y el Inventario.\n\n" +
            "Cuando estés listo, entrá a la Misión. Ahí empieza un combate por turnos: " +
            "te movés, atacás, curás o construís torretas, y después juegan los enemigos. " +
            "Podés deshacer y rehacer tus acciones.",

            "¿Cómo se progresa?\n\n" +
            "Cada misión ganada te da XP y monedas. " +
            "Cada nivel que subís te da +1 de daño en combate. " +
            "La nave que elijas en el Hangar suma daño en el combate y más monedas al ganar.\n\n" +
            "Los logros se desbloquean a medida que avanzás en la partida. " +
            "Al final podés ver un resumen con todo lo que hiciste."
        };

        private int paginaActual = 0;

        public PantallaTutorial(NavegadorPantallas navegador)
        {
            InitializeComponent();
            Tema.Preparar(this);
            this.navegador = navegador;
            MostrarPagina();
        }

        // Muestra el texto de la página actual y el indicador "1/3"
        private void MostrarPagina()
        {
            lblTexto.Text = paginas[paginaActual];
            lblIndicador.Text = (paginaActual + 1) + "/" + paginas.Length;
            btnAnterior.Enabled = paginaActual > 0;
            btnSiguiente.Enabled = paginaActual < paginas.Length - 1;
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            paginaActual--;
            MostrarPagina();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            paginaActual++;
            MostrarPagina();
        }

        private void btnSaltar_Click(object sender, EventArgs e)
        {
            navegador.IrAHub();
        }
    }
}
