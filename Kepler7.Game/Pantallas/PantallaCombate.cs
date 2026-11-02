using System.Drawing.Drawing2D;
using Kepler7.Core.Modelo;
using Kepler7.Core.Patrones.Comportamiento.Chain;
using Kepler7.Core.Patrones.Comportamiento.State;

namespace Kepler7.Game.Pantallas
{
    public partial class PantallaCombate : UserControl
    {
        private const int Celda = 40;
        private const int Columnas = 10;
        private const int Filas = 6;
        private const int EscudoMax = 30;

        private NavegadorPantallas navegador;
        private Personaje jugador;
        private List<Personaje> enemigos = new List<Personaje>();
        private Random random = new Random();
        private PanelCadenaDefensa panelCadena;
        private PanelEstadoPersonaje panelEstado;

        public PantallaCombate(NavegadorPantallas navegador)
        {
            InitializeComponent();
            this.navegador = navegador;
            CrearPersonajes();
            panelCadena = new PanelCadenaDefensa(jugador, random, this);
            panelCadena.Location = new Point(420, 10);
            Controls.Add(panelCadena);
            panelEstado = new PanelEstadoPersonaje(jugador, this);
            panelEstado.Location = new Point(420, 295);
            Controls.Add(panelEstado);
            Actualizar();
        }

        private void CrearPersonajes()
        {
            jugador = new Personaje("Comandante", 100, 12);
            jugador.X = 1;
            jugador.Y = 2;
            jugador.Defensa = new CadenaDefensa();
            jugador.Defensa.Agregar(new Armadura(3));
            jugador.Defensa.Agregar(new Vida(jugador));

            enemigos.Add(CrearEnemigo("Alien 1", 7, 1));
            enemigos.Add(CrearEnemigo("Alien 2", 8, 4));
        }

        private Personaje CrearEnemigo(string nombre, int x, int y)
        {
            Personaje enemigo = new Personaje(nombre, 50, 15);
            enemigo.X = x;
            enemigo.Y = y;
            return enemigo;
        }

        public void Actualizar()
        {
            bool vivo = jugador.Vida > 0;
            bool puedeActuar = vivo && jugador.EstadoVisual != EstadoVisual.Aturdido;
            btnAtacar.Enabled = puedeActuar;
            btnIzquierda.Enabled = puedeActuar;
            btnArriba.Enabled = puedeActuar;
            btnAbajo.Enabled = puedeActuar;
            btnDerecha.Enabled = puedeActuar;
            btnTurnoEnemigo.Enabled = vivo;
            panelEstado.ActualizarEstado();
            panelEscenario.Invalidate();
        }

        public void MostrarMensaje(string mensaje)
        {
            lblMensaje.Text = mensaje;
        }

        private bool EstanAlLado(Personaje a, Personaje b)
        {
            return Math.Abs(a.X - b.X) <= 1 && Math.Abs(a.Y - b.Y) <= 1;
        }

        private bool EstaOcupada(int x, int y)
        {
            if (jugador.X == x && jugador.Y == y)
            {
                return true;
            }
            foreach (Personaje enemigo in enemigos)
            {
                if (enemigo.Vida > 0 && enemigo.X == x && enemigo.Y == y)
                {
                    return true;
                }
            }
            return false;
        }

        private Personaje BuscarEnemigoAlLado()
        {
            foreach (Personaje enemigo in enemigos)
            {
                if (enemigo.Vida > 0 && EstanAlLado(jugador, enemigo))
                {
                    return enemigo;
                }
            }
            return null;
        }

        private bool QuedanEnemigos()
        {
            foreach (Personaje enemigo in enemigos)
            {
                if (enemigo.Vida > 0)
                {
                    return true;
                }
            }
            return false;
        }

        private void AcercarEnemigo(Personaje enemigo)
        {
            int dx = Math.Sign(jugador.X - enemigo.X);
            int dy = Math.Sign(jugador.Y - enemigo.Y);
            if (dx != 0 && !EstaOcupada(enemigo.X + dx, enemigo.Y))
            {
                enemigo.Mover(dx, 0);
            }
            else if (dy != 0 && !EstaOcupada(enemigo.X, enemigo.Y + dy))
            {
                enemigo.Mover(0, dy);
            }
        }

        private int PuntosDeEscudo()
        {
            int puntos = 0;
            foreach (IManejadorDanio eslabon in jugador.Defensa.Eslabones)
            {
                if (eslabon is Escudo escudo)
                {
                    puntos += escudo.Puntos;
                }
            }
            return puntos;
        }

        private void panelEscenario_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            DibujarGrilla(g);
            foreach (Personaje enemigo in enemigos)
            {
                DibujarEnemigo(g, enemigo);
            }
            DibujarJugador(g);
        }

        private void DibujarGrilla(Graphics g)
        {
            for (int i = 0; i <= Columnas; i++)
            {
                g.DrawLine(Pens.DimGray, i * Celda, 0, i * Celda, Filas * Celda);
            }
            for (int j = 0; j <= Filas; j++)
            {
                g.DrawLine(Pens.DimGray, 0, j * Celda, Columnas * Celda, j * Celda);
            }
        }

        private void DibujarJugador(Graphics g)
        {
            int x = jugador.X * Celda;
            int y = jugador.Y * Celda;
            using (SolidBrush pincel = new SolidBrush(PanelEstadoPersonaje.ColorDeEstado(jugador.EstadoVisual)))
            {
                g.FillEllipse(pincel, x + 7, y + 11, Celda - 14, Celda - 14);
            }
            DibujarBarra(g, x + 3, y + 1, (float)jugador.Vida / jugador.VidaMax, Brushes.LimeGreen);
            DibujarBarra(g, x + 3, y + 6, (float)PuntosDeEscudo() / EscudoMax, Brushes.DeepSkyBlue);
        }

        private void DibujarEnemigo(Graphics g, Personaje enemigo)
        {
            int x = enemigo.X * Celda;
            int y = enemigo.Y * Celda;
            Brush color = Brushes.DarkRed;
            if (enemigo.Vida == 0)
            {
                color = Brushes.Gray;
            }
            g.FillRectangle(color, x + 7, y + 11, Celda - 14, Celda - 14);
            DibujarBarra(g, x + 3, y + 1, (float)enemigo.Vida / enemigo.VidaMax, Brushes.LimeGreen);
        }

        private void DibujarBarra(Graphics g, int x, int y, float porcentaje, Brush color)
        {
            int ancho = Celda - 6;
            g.FillRectangle(Brushes.DarkSlateGray, x, y, ancho, 4);
            g.FillRectangle(color, x, y, ancho * Math.Min(1, porcentaje), 4);
        }

        private void btnAtacar_Click(object sender, EventArgs e)
        {
            Personaje objetivo = BuscarEnemigoAlLado();
            if (objetivo == null)
            {
                lblMensaje.Text = "No hay ningún enemigo al lado para atacar";
                return;
            }
            ResultadoAccion resultado = jugador.Atacar(objetivo);
            lblMensaje.Text = resultado.Mensaje + " a " + objetivo.Nombre;
            if (!QuedanEnemigos())
            {
                lblMensaje.Text += ". ¡Ganaste el combate!";
            }
            Actualizar();
        }

        private void MoverJugador(int dx, int dy)
        {
            int nuevaX = jugador.X + dx;
            int nuevaY = jugador.Y + dy;
            if (nuevaX < 0 || nuevaX >= Columnas || nuevaY < 0 || nuevaY >= Filas)
            {
                lblMensaje.Text = "No se puede salir del escenario";
                return;
            }
            if (EstaOcupada(nuevaX, nuevaY))
            {
                lblMensaje.Text = "Esa casilla está ocupada";
                return;
            }
            ResultadoAccion resultado = jugador.Mover(dx, dy);
            lblMensaje.Text = resultado.Mensaje;
            Actualizar();
        }

        private void btnIzquierda_Click(object sender, EventArgs e)
        {
            MoverJugador(-1, 0);
        }

        private void btnArriba_Click(object sender, EventArgs e)
        {
            MoverJugador(0, -1);
        }

        private void btnAbajo_Click(object sender, EventArgs e)
        {
            MoverJugador(0, 1);
        }

        private void btnDerecha_Click(object sender, EventArgs e)
        {
            MoverJugador(1, 0);
        }

        private void btnTurnoEnemigo_Click(object sender, EventArgs e)
        {
            string mensaje = "";
            foreach (Personaje enemigo in enemigos)
            {
                if (enemigo.Vida > 0 && EstanAlLado(jugador, enemigo))
                {
                    ResultadoDanio resultado = jugador.RecibirDanio(new Danio(enemigo.AtaqueBase, "Fisico", enemigo));
                    mensaje += enemigo.Nombre + " te hace " + resultado.DanioFinal + " de daño. ";
                    panelCadena.MostrarRecorrido(enemigo.Nombre, resultado);
                }
                else if (enemigo.Vida > 0)
                {
                    AcercarEnemigo(enemigo);
                    mensaje += enemigo.Nombre + " se acerca. ";
                }
            }
            jugador.FinTurno();
            if (jugador.Vida == 0)
            {
                mensaje += "¡Fuiste derrotado!";
            }
            lblMensaje.Text = mensaje;
            Actualizar();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            navegador.IrAInicio();
        }
    }
}
