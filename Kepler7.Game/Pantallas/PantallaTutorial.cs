namespace Kepler7.Game.Pantallas
{
    // Pantalla del tutorial: varias páginas de texto
    public partial class PantallaTutorial : UserControl
    {
        private NavegadorPantallas navegador;

        // Textos de cada página del tutorial
        private string[] paginas =
        {
            "¿Qué pasó en Kepler-7?\n\n" +
            "Kepler-7 es una estación espacial en el borde de la galaxia. " +
            "Su IA central, K-7, dejó de obedecer y se volvió contra la tripulación.\n\n" +
            "Sos el Comandante: tenés que preparar la estación día por día y al final enfrentar a K-7.",

            "Una campaña en capítulos\n\n" +
            "La campaña tiene 11 capítulos en orden: Hangar, Laboratorio, Comunicaciones, Control Central, " +
            "Censo, Bóveda, Inventario, Turnos, Estrategia IA, Práctica y el Final.\n\n" +
            "El Diario de misión te dice en qué capítulo estás. En cada uno hacés la acción pedida y tocás Continuar. " +
            "No se puede saltear capítulos ni volver atrás: lo que elegís, queda.",

            "Tus decisiones se acumulan\n\n" +
            "Cada capítulo deja un efecto para el combate final: la nave suma daño y armadura, los clones suman vida, " +
            "el cifrado te da escudo, el código de la bóveda te deja hackear a K-7, y así.\n\n" +
            "Las malas decisiones también cuentan: un mensaje sin cifrar o una intrusión detectada hacen más fuerte a K-7. " +
            "En el Diario ves siempre la lista de decisiones y su efecto.",

            "El final depende de vos\n\n" +
            "Para abrir el Final necesitás los 12 logros (uno por patrón). " +
            "Contra K-7 cada acción tuya es un turno, y K-7 cambia de estrategia según su vida.\n\n" +
            "Si preparaste bien la estación, vas a ganar con holgura; si no, K-7 se queda con todo. " +
            "El epílogo te cuenta qué decisiones pesaron más."
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
            navegador.IrAInicio();
        }
    }
}
