using Kepler7.Core.Patrones.Creacionales.Builder;

namespace Kepler7.Game.Pantallas
{
    // Pantalla del Hangar (patrón Builder)
    public partial class PantallaHangar : UserControl
    {
        private NavegadorPantallas navegador;

        // Última nave construida (null si todavía no se construyó ninguna)
        private Nave naveConstruida;

        public PantallaHangar(NavegadorPantallas navegador)
        {
            InitializeComponent();
            this.navegador = navegador;
            cmbReceta.SelectedIndex = 0;
        }

        // Crea el builder (receta) según lo elegido en el ComboBox
        private INaveBuilder CrearReceta()
        {
            if (cmbReceta.Text == "Combate")
            {
                return new RecetaCombate();
            }
            if (cmbReceta.Text == "Carga")
            {
                return new RecetaCarga();
            }
            return new RecetaExploradora();
        }

        private void btnCompleta_Click(object sender, EventArgs e)
        {
            IngenieroJefe ingeniero = new IngenieroJefe(CrearReceta());
            naveConstruida = ingeniero.ConstruirNaveCompleta();
            MostrarNave();
        }

        private void btnBasica_Click(object sender, EventArgs e)
        {
            IngenieroJefe ingeniero = new IngenieroJefe(CrearReceta());
            naveConstruida = ingeniero.ConstruirNaveBasica();
            MostrarNave();
        }

        private void MostrarNave()
        {
            txtDescripcion.Text = naveConstruida.Describir();
            lblAviso.Text = "";
            // Pide que se vuelva a dibujar el panel de barras
            panelAtributos.Invalidate();
        }

        // Dibuja con GDI+ una barra por cada atributo de la nave
        private void panelAtributos_Paint(object sender, PaintEventArgs e)
        {
            if (naveConstruida == null)
            {
                e.Graphics.DrawString("Construí una nave para ver sus atributos", Font, Brushes.Gray, 10, 10);
                return;
            }
            DibujarBarra(e.Graphics, "Ataque", naveConstruida.Ataque, Brushes.IndianRed, 20);
            DibujarBarra(e.Graphics, "Defensa", naveConstruida.Defensa, Brushes.SteelBlue, 65);
            DibujarBarra(e.Graphics, "Velocidad", naveConstruida.Velocidad, Brushes.Goldenrod, 110);
            DibujarBarra(e.Graphics, "Autonomía", naveConstruida.Autonomia, Brushes.SeaGreen, 155);
        }

        private void DibujarBarra(Graphics g, string nombre, int valor, Brush color, int y)
        {
            const int maximo = 60;
            const int anchoTotal = 160;
            int ancho = Math.Min(valor, maximo) * anchoTotal / maximo;
            g.DrawString(nombre, Font, Brushes.Black, 10, y);
            g.FillRectangle(Brushes.LightGray, 85, y, anchoTotal, 18);
            g.FillRectangle(color, 85, y, ancho, 18);
            g.DrawString(valor.ToString(), Font, Brushes.Black, 255, y);
        }

        // Guarda la nave en la partida para que dé bonus en la misión
        private void btnUsar_Click(object sender, EventArgs e)
        {
            if (naveConstruida == null)
            {
                lblAviso.Text = "Primero construí una nave";
                return;
            }
            navegador.Partida.NaveElegida = naveConstruida;
            lblAviso.Text = "Nave " + naveConstruida.Tipo + " lista para la misión";
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            navegador.IrAHub();
        }
    }
}
