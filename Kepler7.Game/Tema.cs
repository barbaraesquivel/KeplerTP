using System.Drawing.Drawing2D;
using Kepler7.Game.Pantallas;

namespace Kepler7.Game
{
    // Tema visual espacial de la estación Kepler-7 (colores, fondo con estrellas y estilo de controles)
    public static class Tema
    {
        public static readonly Color FondoOscuro = Color.FromArgb(8, 12, 30);
        public static readonly Color FondoPanel = Color.FromArgb(20, 28, 60);
        public static readonly Color Texto = Color.FromArgb(230, 235, 255);
        public static readonly Color Acento = Color.FromArgb(0, 200, 255);
        public static readonly Color AcentoSuave = Color.FromArgb(60, 90, 160);
        public static readonly Color Peligro = Color.FromArgb(230, 80, 80);
        public static readonly Color Exito = Color.FromArgb(90, 220, 140);

        // Color de abajo del degradado (azul violáceo oscuro)
        private static readonly Color FondoViolaceo = Color.FromArgb(35, 20, 70);
        private static readonly Color EstrellaCeleste = Color.FromArgb(150, 210, 255);
        private const int CantidadEstrellas = 70;

        // Posiciones de las estrellas en proporción (0 a 1) del tamaño de la pantalla.
        // Se generan una sola vez con semilla fija para que no cambien al repintar.
        private static readonly List<PointF> estrellas = CrearEstrellas();

        private static List<PointF> CrearEstrellas()
        {
            Random random = new Random(7);
            List<PointF> lista = new List<PointF>();
            for (int i = 0; i < CantidadEstrellas; i++)
            {
                lista.Add(new PointF((float)random.NextDouble(), (float)random.NextDouble()));
            }
            return lista;
        }

        // Único método que usan las pantallas: pone el fondo y el estilo de los controles
        public static void Preparar(Control pantalla)
        {
            PonerFondo(pantalla);
            Aplicar(pantalla);
        }

        // Fondo oscuro con degradado y estrellas dibujado en el Paint de la pantalla
        public static void PonerFondo(Control pantalla)
        {
            pantalla.BackColor = FondoOscuro;
            pantalla.Paint += DibujarFondo;
            // Al cambiar de tamaño se redibuja todo (las estrellas son proporcionales)
            pantalla.Resize += (s, e) => pantalla.Invalidate();
        }

        private static void DibujarFondo(object sender, PaintEventArgs e)
        {
            Control pantalla = (Control)sender;
            Rectangle area = pantalla.ClientRectangle;
            if (area.Width == 0 || area.Height == 0)
            {
                return;
            }

            using (LinearGradientBrush degradado = new LinearGradientBrush(area, FondoOscuro, FondoViolaceo, LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(degradado, area);
            }
            DibujarEstrellas(e.Graphics, area);
        }

        private static void DibujarEstrellas(Graphics g, Rectangle area)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (SolidBrush blanco = new SolidBrush(Color.White))
            using (SolidBrush celeste = new SolidBrush(EstrellaCeleste))
            {
                for (int i = 0; i < estrellas.Count; i++)
                {
                    // El tamaño (1 a 3 px) y el color salen del número de estrella
                    int tamanio = 1 + i % 3;
                    Brush pincel = i % 4 == 0 ? celeste : blanco;
                    float x = estrellas[i].X * area.Width;
                    float y = estrellas[i].Y * area.Height;
                    g.FillEllipse(pincel, x, y, tamanio, tamanio);
                }
            }
        }

        // Recorre los controles hijos (y los hijos de esos) y les pone los colores del tema
        public static void Aplicar(Control pantalla)
        {
            foreach (Control control in pantalla.Controls)
            {
                // El escenario del combate se dibuja a mano: no se toca
                if (control is PanelEscenario)
                {
                    continue;
                }
                AplicarControl(control);
                Aplicar(control);
            }
        }

        private static void AplicarControl(Control control)
        {
            if (control is Label label)
            {
                AplicarLabel(label);
            }
            else if (control is Button boton)
            {
                AplicarBoton(boton);
            }
            else if (control is ComboBox combo)
            {
                combo.FlatStyle = FlatStyle.Flat;
                combo.BackColor = FondoPanel;
                combo.ForeColor = Texto;
            }
            else if (control is TextBox || control is ListBox)
            {
                control.BackColor = FondoPanel;
                control.ForeColor = Texto;
            }
            else if (control is Panel || control is GroupBox)
            {
                control.BackColor = FondoPanel;
                control.ForeColor = Texto;
            }
        }

        // Solo cambia el color de los labels que tienen el color por defecto.
        // Los que ya tienen un color propio (victoria, derrota, estados) lo conservan.
        private static void AplicarLabel(Label label)
        {
            label.BackColor = Color.Transparent;
            if (label.ForeColor != SystemColors.ControlText)
            {
                return;
            }
            if (label.Name == "lblTitulo")
            {
                label.ForeColor = Acento;
            }
            else
            {
                label.ForeColor = Texto;
            }
        }

        private static void AplicarBoton(Button boton)
        {
            boton.FlatStyle = FlatStyle.Flat;
            boton.UseVisualStyleBackColor = false;
            boton.ForeColor = Texto;
            boton.FlatAppearance.BorderColor = Acento;
            boton.FlatAppearance.MouseOverBackColor = Color.FromArgb(80, 120, 200);
            PintarBotonSegunEstado(boton);
            // Un botón deshabilitado se ve gris para que se note que no se puede usar
            boton.EnabledChanged += (s, e) => PintarBotonSegunEstado(boton);
        }

        private static void PintarBotonSegunEstado(Button boton)
        {
            boton.BackColor = boton.Enabled ? AcentoSuave : Color.FromArgb(70, 75, 95);
        }
    }
}
