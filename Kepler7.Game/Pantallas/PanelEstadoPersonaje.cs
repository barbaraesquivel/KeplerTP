using System.Drawing.Drawing2D;
using Kepler7.Core.Modelo;
using Kepler7.Core.Patrones.Comportamiento.State;

namespace Kepler7.Game.Pantallas
{
    public partial class PanelEstadoPersonaje : UserControl
    {
        private Personaje jugador;
        private PantallaCombate pantalla;

        public PanelEstadoPersonaje(Personaje jugador, PantallaCombate pantalla)
        {
            InitializeComponent();
            BackColor = Tema.FondoPanel;
            Tema.Aplicar(this);
            this.jugador = jugador;
            this.pantalla = pantalla;
            ActualizarEstado();
        }

        public static Color ColorDeEstado(EstadoVisual estado)
        {
            switch (estado)
            {
                case EstadoVisual.Envenenado:
                    return Color.LimeGreen;
                case EstadoVisual.Aturdido:
                    return Color.Gold;
                case EstadoVisual.Berserk:
                    return Color.Red;
                default:
                    return Color.SteelBlue;
            }
        }

        public void ActualizarEstado()
        {
            lblEstado.Text = "Estado: " + jugador.Estado.Nombre;
            pnlIcono.Invalidate();
        }

        private void pnlIcono_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (SolidBrush pincel = new SolidBrush(ColorDeEstado(jugador.EstadoVisual)))
            {
                e.Graphics.FillEllipse(pincel, 2, 2, pnlIcono.Width - 5, pnlIcono.Height - 5);
            }
        }

        private void CambiarEstado(IEstadoPersonaje nuevoEstado)
        {
            jugador.CambiarEstado(nuevoEstado);
            pantalla.MostrarMensaje("");
            pantalla.Actualizar();
        }

        private void btnVeneno_Click(object sender, EventArgs e)
        {
            CambiarEstado(new Envenenado(5, 3));
        }

        private void btnAturdir_Click(object sender, EventArgs e)
        {
            CambiarEstado(new Aturdido(2));
        }

        private void btnBerserk_Click(object sender, EventArgs e)
        {
            CambiarEstado(new Berserk(3));
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            CambiarEstado(new Normal());
        }
    }
}
