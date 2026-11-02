using System.Drawing.Drawing2D;
using Kepler7.Core.Modelo;
using Kepler7.Core.Patrones.Comportamiento.Chain;
using Kepler7.Core.Patrones.Comportamiento.Command;
using Kepler7.Core.Patrones.Comportamiento.State;

namespace Kepler7.Game.Pantallas
{
    public partial class PantallaCombate : UserControl
    {
        private const int Celda = 40;
        private const int Columnas = 10;
        private const int Filas = 6;
        private const int EscudoMax = 30;
        private const int Curacion = 20;
        private const int CostoTorreta = 30;
        private const int DanioTorreta = 6;
        private const int AlcanceTorreta = 3;

        private NavegadorPantallas navegador;
        private Personaje jugador;
        private List<Personaje> enemigos = new List<Personaje>();
        private Random random = new Random();
        private PanelCadenaDefensa panelCadena;
        private PanelEstadoPersonaje panelEstado;
        private GestorComandos gestor = new GestorComandos();
        private Base baseJugador = new Base();

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

            baseJugador.Recursos = 100;

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
            bool enJuego = jugador.Vida > 0 && QuedanEnemigos();
            bool puedeActuar = enJuego && jugador.EstadoVisual != EstadoVisual.Aturdido;
            btnAtacar.Enabled = puedeActuar;
            btnIzquierda.Enabled = puedeActuar;
            btnArriba.Enabled = puedeActuar;
            btnAbajo.Enabled = puedeActuar;
            btnDerecha.Enabled = puedeActuar;
            btnCurar.Enabled = enJuego;
            btnConstruir.Enabled = enJuego;
            btnDeshacer.Enabled = enJuego;
            btnRehacer.Enabled = enJuego;
            btnTurnoEnemigo.Enabled = enJuego;
            lblBase.Text = "Recursos: " + baseJugador.Recursos + "   Estructuras: " + string.Join(", ", baseJugador.Estructuras);
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
            return HayTorreta(x, y);
        }

        private Point PosicionDeTorreta(string torreta)
        {
            int inicio = torreta.IndexOf('(') + 1;
            int fin = torreta.IndexOf(')');
            string[] partes = torreta.Substring(inicio, fin - inicio).Split(',');
            return new Point(int.Parse(partes[0]), int.Parse(partes[1]));
        }

        private bool HayTorreta(int x, int y)
        {
            foreach (string torreta in baseJugador.Estructuras)
            {
                Point posicion = PosicionDeTorreta(torreta);
                if (posicion.X == x && posicion.Y == y)
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
            DibujarTorretas(g);
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

        private void DibujarTorretas(Graphics g)
        {
            foreach (string torreta in baseJugador.Estructuras)
            {
                Point posicion = PosicionDeTorreta(torreta);
                int x = posicion.X * Celda;
                int y = posicion.Y * Celda;
                Point[] triangulo =
                {
                    new Point(x + Celda / 2, y + 5),
                    new Point(x + 5, y + Celda - 5),
                    new Point(x + Celda - 5, y + Celda - 5)
                };
                g.FillPolygon(Brushes.Silver, triangulo);
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
            ResultadoAccion resultado = jugador.Estado.Atacar(jugador);
            if (!resultado.Exito)
            {
                lblMensaje.Text = resultado.Mensaje;
                return;
            }
            gestor.Ejecutar(new AtacarComando(objetivo, resultado.Valor));
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
            gestor.Ejecutar(new MoverComando(jugador, nuevaX, nuevaY));
            MostrarUltimoComando();
            Actualizar();
        }

        private void MostrarUltimoComando()
        {
            lblMensaje.Text = gestor.Historial[gestor.Historial.Count - 1];
        }

        private void btnCurar_Click(object sender, EventArgs e)
        {
            if (jugador.Vida == jugador.VidaMax)
            {
                lblMensaje.Text = "Ya tenés la vida al máximo";
                return;
            }
            gestor.Ejecutar(new CurarComando(jugador, Curacion));
            MostrarUltimoComando();
            Actualizar();
        }

        private void btnConstruir_Click(object sender, EventArgs e)
        {
            if (baseJugador.Recursos < CostoTorreta)
            {
                lblMensaje.Text = "No alcanzan los recursos para construir";
                return;
            }
            if (HayTorreta(jugador.X, jugador.Y))
            {
                lblMensaje.Text = "Ya hay una torreta en esta casilla";
                return;
            }
            string torreta = "Torreta (" + jugador.X + "," + jugador.Y + ")";
            gestor.Ejecutar(new ConstruirComando(baseJugador, torreta, CostoTorreta));
            MostrarUltimoComando();
            Actualizar();
        }

        private void btnDeshacer_Click(object sender, EventArgs e)
        {
            if (!gestor.Deshacer())
            {
                lblMensaje.Text = "No hay nada para deshacer";
                return;
            }
            MostrarUltimoComando();
            Actualizar();
        }

        private void btnRehacer_Click(object sender, EventArgs e)
        {
            if (!gestor.Rehacer())
            {
                lblMensaje.Text = "No hay nada para rehacer";
                return;
            }
            MostrarUltimoComando();
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

        private string DispararTorretas()
        {
            string mensaje = "";
            foreach (string torreta in baseJugador.Estructuras)
            {
                Point posicion = PosicionDeTorreta(torreta);
                Personaje objetivo = BuscarEnemigoVivoMasCercano(posicion.X, posicion.Y);
                if (objetivo != null && Math.Abs(objetivo.X - posicion.X) + Math.Abs(objetivo.Y - posicion.Y) <= AlcanceTorreta)
                {
                    objetivo.Vida = Math.Max(0, objetivo.Vida - DanioTorreta);
                    mensaje += "Torreta dispara a " + objetivo.Nombre + " (" + DanioTorreta + "). ";
                }
            }
            return mensaje;
        }

        private Personaje BuscarEnemigoVivoMasCercano(int x, int y)
        {
            Personaje masCercano = null;
            int menorDistancia = int.MaxValue;
            foreach (Personaje enemigo in enemigos)
            {
                int distancia = Math.Abs(enemigo.X - x) + Math.Abs(enemigo.Y - y);
                if (enemigo.Vida > 0 && distancia < menorDistancia)
                {
                    masCercano = enemigo;
                    menorDistancia = distancia;
                }
            }
            return masCercano;
        }

        private void btnTurnoEnemigo_Click(object sender, EventArgs e)
        {
            string mensaje = DispararTorretas();
            if (!QuedanEnemigos())
            {
                lblMensaje.Text = mensaje + "¡Ganaste el combate!";
                Actualizar();
                return;
            }
            foreach (Personaje enemigo in enemigos)
            {
                if (enemigo.Vida > 0 && EstanAlLado(jugador, enemigo))
                {
                    string tipo = "Fisico";
                    if (random.Next(100) < 25)
                    {
                        tipo = "Veneno";
                    }
                    ResultadoDanio resultado = jugador.RecibirDanio(new Danio(enemigo.AtaqueBase, tipo, enemigo));
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
