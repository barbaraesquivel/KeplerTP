using Kepler7.Core.Modelo;
using Kepler7.Core.Progreso;

namespace Kepler7.Game.Pantallas
{
    // Diario de misión: muestra el capítulo actual, la historia y las decisiones tomadas
    public partial class PantallaHub : UserControl
    {
        private NavegadorPantallas navegador;

        public PantallaHub(NavegadorPantallas navegador)
        {
            InitializeComponent();
            Tema.Preparar(this);
            this.navegador = navegador;
            MostrarDiario();
        }

        private void MostrarDiario()
        {
            Campana campana = navegador.Campana;
            Capitulo actual = campana.Actual;
            int numero = (int)actual + 1;
            int total = (int)Capitulo.Final + 1;

            lblCapitulo.Text = "Capítulo " + numero + " de " + total + ": " + Historia.Nombre(actual);
            lblHistoria.Text = Historia.TextoDiario(actual);
            MostrarDecisiones(campana);
            MostrarProgreso();
            MostrarLogros();

            btnIrCapitulo.Text = "Ir a: " + Historia.Nombre(actual);
            lblFaltan.Text = "";
            if (actual == Capitulo.Final)
            {
                MostrarRequisitoFinal();
            }
        }

        // El Final pide los 12 logros. Si falta alguno se muestra cuál y cómo conseguirlo.
        private void MostrarRequisitoFinal()
        {
            List<Logro> faltantes = navegador.ServicioLogros.Faltantes();
            if (faltantes.Count == 0)
            {
                lblFaltan.ForeColor = Tema.Exito;
                lblFaltan.Text = "Tenés los 12 logros. K-7 te espera.";
                return;
            }

            string texto = "";
            foreach (Logro logro in faltantes)
            {
                texto += "Te falta: " + logro.Patron + " – " + Historia.PistaLogro(logro.Patron) + "\n";
            }
            lblFaltan.Text = texto;
            // Los logros de combate se consiguen en el entrenamiento (no cambia la campaña)
            btnIrCapitulo.Text = "Ir a: Entrenamiento";
        }

        private void MostrarDecisiones(Campana campana)
        {
            lstDecisiones.Items.Clear();
            foreach (string linea in campana.CalcularModificadores().Resumen)
            {
                lstDecisiones.Items.Add(linea);
            }
            if (lstDecisiones.Items.Count == 0)
            {
                lstDecisiones.Items.Add("Todavía no tomaste ninguna decisión.");
            }
        }

        // Muestra nivel, XP y monedas del jugador
        private void MostrarProgreso()
        {
            Progreso progreso = navegador.Progreso;
            lblProgreso.Text = "Nivel " + progreso.Nivel
                + "  |  XP " + progreso.Xp + "/" + Progreso.XpPorNivel
                + "  |  Monedas " + progreso.Monedas;
        }

        private void MostrarLogros()
        {
            int desbloqueados = 0;
            foreach (Logro logro in navegador.ServicioLogros.Logros)
            {
                if (logro.Desbloqueado)
                {
                    desbloqueados++;
                }
            }
            lblLogros.Text = "Logros: " + desbloqueados + " / " + navegador.ServicioLogros.Logros.Count;
        }

        private void btnIrCapitulo_Click(object sender, EventArgs e)
        {
            navegador.IrACapituloActual();
        }

        private void btnLogros_Click(object sender, EventArgs e)
        {
            navegador.IrALogros();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Si salís al inicio y tocás Jugar, la campaña empieza de cero. ¿Salir?", "Salir al inicio", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                navegador.IrAInicio();
            }
        }
    }
}
