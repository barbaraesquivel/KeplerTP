using System.Drawing.Drawing2D;
using Kepler7.Core.Modelo;
using Kepler7.Core.Patrones.Comportamiento.Chain;
using Kepler7.Core.Patrones.Comportamiento.Command;
using Kepler7.Core.Patrones.Comportamiento.State;
using Kepler7.Core.Patrones.Comportamiento.Strategy;
using Kepler7.Core.Progreso;
using Kepler7.Game.Animacion;

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
        // El blindaje de K-7 absorbe casi todo el disparo de una torreta
        private const int DanioTorretaK7 = 2;
        private const int MaxMovimientosPorTurno = 2;
        private const int EsperaTurnoEnemigo = 600;

        private NavegadorPantallas navegador;
        private ModoCombate modo;

        // Solo en el combate final
        private ModificadoresFinal mods;
        private JefeK7 jefe;
        private int curasDisponibles;
        private bool disparoEspecialListo;
        private Personaje jugador;
        private List<Personaje> enemigos = new List<Personaje>();
        private Random random = new Random();
        private PanelCadenaDefensa panelCadena;
        private PanelEstadoPersonaje panelEstado;
        private GestorComandos gestor = new GestorComandos();
        private Base baseJugador = new Base();
        private AnimadorTimer animador;
        private Font fuenteEfectos = new Font("Segoe UI", 9F, FontStyle.Bold);

        private System.Windows.Forms.Timer timerTurnoEnemigo = new System.Windows.Forms.Timer();
        private int turno = 1;
        private int movimientosEnTurno = 0;
        private int comandosDelTurno = 0;
        private int deshechosDelTurno = 0;
        private bool juegaEnemigo = false;
        private string mensajeJugador = "";

        public PantallaCombate(NavegadorPantallas navegador, ModoCombate modo)
        {
            InitializeComponent();
            Tema.Preparar(this);
            this.navegador = navegador;
            this.modo = modo;
            timerTurnoEnemigo.Interval = EsperaTurnoEnemigo;
            timerTurnoEnemigo.Tick += timerTurnoEnemigo_Tick;
            CrearPersonajes();
            animador = new AnimadorTimer(panelEscenario, PanelEstadoPersonaje.ColorDeEstado(jugador.EstadoVisual));
            animador.Registrar(jugador);
            foreach (Personaje enemigo in enemigos)
            {
                animador.Registrar(enemigo);
            }
            panelCadena = new PanelCadenaDefensa(jugador, random, this);
            Controls.Add(panelCadena);
            panelEstado = new PanelEstadoPersonaje(jugador, this);
            Controls.Add(panelEstado);
            if (modo == ModoCombate.Final)
            {
                ConfigurarPantallaFinal();
            }
            AcomodarControles();
            Load += (s, e) => AcomodarControles();
            Actualizar();
        }

        // Asegura que las interfaces no se superpongan sin importar el escalado de Windows
        private void AcomodarControles()
        {
            panelEscenario.Location = new Point(15, 12);
            panelEscenario.Size = new Size(401, 241);

            if (panelCadena != null)
            {
                panelCadena.Location = new Point(425, 12);
                panelCadena.BringToFront();
            }

            if (panelEstado != null)
            {
                panelEstado.Location = new Point(425, 296);
                panelEstado.BringToFront();
            }

            btnAtacar.Location = new Point(15, 259);
            btnAtacar.Size = new Size(75, 32);

            btnIzquierda.Location = new Point(94, 259);
            btnIzquierda.Size = new Size(34, 32);

            btnArriba.Location = new Point(132, 259);
            btnArriba.Size = new Size(34, 32);

            btnAbajo.Location = new Point(170, 259);
            btnAbajo.Size = new Size(34, 32);

            btnDerecha.Location = new Point(208, 259);
            btnDerecha.Size = new Size(34, 32);

            btnTurnoEnemigo.Location = new Point(248, 259);
            btnTurnoEnemigo.Size = new Size(168, 32);

            btnCurar.Location = new Point(15, 296);
            btnCurar.Size = new Size(75, 30);

            btnConstruir.Location = new Point(94, 296);
            btnConstruir.Size = new Size(110, 30);

            btnDeshacer.Location = new Point(208, 296);
            btnDeshacer.Size = new Size(100, 30);

            btnRehacer.Location = new Point(312, 296);
            btnRehacer.Size = new Size(104, 30);

            lblMensaje.Location = new Point(15, 332);
            lblMensaje.Size = new Size(401, 44);

            lblBase.Location = new Point(15, 378);
            lblBase.Size = new Size(401, 20);

            lstHistorial.Location = new Point(15, 400);
            lstHistorial.Size = new Size(401, 74);

            lblTurno.Location = new Point(190, 490);
            lblTurno.Size = new Size(226, 20);

            lblObjetivos.Location = new Point(425, 432);
            lblObjetivos.Size = new Size(370, 92);

            btnVolver.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnVolver.Location = new Point(15, 482);
            btnVolver.Size = new Size(160, 34);
        }

        private void CrearPersonajes()
        {
            if (modo == ModoCombate.Final)
            {
                CrearCombateFinal();
                return;
            }
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
            bool enJuego = jugador.Vida > 0 && QuedanEnemigos() && !juegaEnemigo;
            ResultadoAccion permisoAtacar = jugador.Estado.Atacar(jugador);
            ResultadoAccion permisoMover = jugador.Estado.Mover(jugador, 0, 0);
            bool puedeAtacar = enJuego && permisoAtacar.Exito;
            bool puedeMover = enJuego && permisoMover.Exito;
            bool puedeActuar = puedeAtacar || puedeMover;
            btnAtacar.Enabled = puedeAtacar;
            btnIzquierda.Enabled = puedeMover;
            btnArriba.Enabled = puedeMover;
            btnAbajo.Enabled = puedeMover;
            btnDerecha.Enabled = puedeMover;
            btnCurar.Enabled = puedeActuar;
            btnConstruir.Enabled = puedeActuar;
            btnDeshacer.Enabled = puedeActuar && comandosDelTurno > 0;
            btnRehacer.Enabled = puedeActuar && deshechosDelTurno > 0;
            btnTurnoEnemigo.Enabled = enJuego;
            lblTurno.Text = juegaEnemigo ? "Turno " + turno + " - juegan los enemigos" : "Turno " + turno + " - movimientos: " + movimientosEnTurno + "/" + MaxMovimientosPorTurno;
            bool combateTerminado = jugador.Vida == 0 || !QuedanEnemigos();
            // Al terminar el combate el botón lleva a victoria o derrota
            btnVolver.Text = combateTerminado ? "Continuar" : "Abandonar";
            btnVolver.Enabled = !juegaEnemigo;
            if (enJuego && !puedeActuar)
            {
                InformarBloqueo(permisoMover.Mensaje);
            }
            // En el final el daño sale de los modificadores de la campaña, no del nivel
            string bonusNivel = modo == ModoCombate.Final ? "" : "   Bonus de nivel: +" + BonusNivel();
            lblBase.Text = "Recursos: " + baseJugador.Recursos + bonusNivel
                + "   Estructuras: " + string.Join(", ", baseJugador.Estructuras);
            panelEstado.ActualizarEstado();
            if (jugador.Estado.Nombre != "Normal")
            {
                navegador.ServicioLogros.RegistrarUsoPatron("State");
            }
            MostrarObjetivos();
            if (modo == ModoCombate.Final)
            {
                btnHackear.Enabled = enJuego && !jefe.HackUsado;
                MostrarK7();
                MostrarModificadores();
            }
            animador.ColorObjetivo = PanelEstadoPersonaje.ColorDeEstado(jugador.EstadoVisual);
            panelEscenario.Invalidate();
            // Actualizar() se llama después de cada acción, deshacer o rehacer
            MostrarHistorial();
        }

        // Los 3 logros que solo se consiguen en combate, con lo que hay que hacer
        private void MostrarObjetivos()
        {
            lblObjetivos.Text = "Logros de combate:\n"
                + Objetivo("Command") + "\n"
                + Objetivo("Chain of Responsibility") + "\n"
                + Objetivo("State");
        }

        private string Objetivo(string patron)
        {
            foreach (Logro logro in navegador.ServicioLogros.Logros)
            {
                if (logro.Patron == patron)
                {
                    string marca = logro.Desbloqueado ? "[✓] " : "[  ] ";
                    return marca + patron + ": " + Historia.PistaLogro(patron);
                }
            }
            return "";
        }

        // Muestra todo el historial de Command (incluye lo deshecho y rehecho)
        private void MostrarHistorial()
        {
            lstHistorial.Items.Clear();
            foreach (string linea in gestor.Historial)
            {
                lstHistorial.Items.Add(linea);
            }
            // Deja visible la última línea
            if (lstHistorial.Items.Count > 0)
            {
                lstHistorial.TopIndex = lstHistorial.Items.Count - 1;
            }
        }

        public void MostrarMensaje(string mensaje)
        {
            lblMensaje.Text = mensaje;
            if (!string.IsNullOrEmpty(mensaje))
            {
                navegador.ServicioLogros.RegistrarUsoPatron("Chain of Responsibility");
            }
        }

        private void InformarBloqueo(string mensaje)
        {
            if (lblMensaje.Text.Contains(mensaje))
            {
                return;
            }
            if (lblMensaje.Text != "")
            {
                lblMensaje.Text += "\n";
            }
            lblMensaje.Text += mensaje + ".";
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
            DibujarEfectos(g);
        }

        private void DibujarEfectos(Graphics g)
        {
            foreach (EfectoDanio efecto in animador.Efectos)
            {
                using (SolidBrush pincel = new SolidBrush(Color.FromArgb(efecto.Opacidad, efecto.Color)))
                {
                    g.DrawString(efecto.Texto, fuenteEfectos, pincel, efecto.X * Celda + 4, efecto.Y * Celda + 8);
                }
            }
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
            PointF posicion = animador.Posicion(jugador);
            float x = posicion.X * Celda;
            float y = posicion.Y * Celda;
            Color color = animador.ColorJugador;
            if (animador.EstaParpadeando(jugador))
            {
                color = Color.White;
            }
            using (SolidBrush pincel = new SolidBrush(color))
            {
                g.FillEllipse(pincel, x + 7, y + 11, Celda - 14, Celda - 14);
            }
            DibujarBarra(g, x + 3, y + 1, animador.VidaDibujada(jugador) / jugador.VidaMax, Brushes.LimeGreen);
            DibujarBarra(g, x + 3, y + 6, (float)PuntosDeEscudo() / EscudoMax, Brushes.DeepSkyBlue);
        }

        private void DibujarEnemigo(Graphics g, Personaje enemigo)
        {
            PointF posicion = animador.Posicion(enemigo);
            float x = posicion.X * Celda;
            float y = posicion.Y * Celda;
            // K-7 se dibuja violeta para diferenciarla de los aliens
            Brush color = modo == ModoCombate.Final ? Brushes.DarkMagenta : Brushes.DarkRed;
            if (enemigo.Vida == 0)
            {
                color = Brushes.Gray;
            }
            if (animador.EstaParpadeando(enemigo))
            {
                color = Brushes.White;
            }
            g.FillRectangle(color, x + 7, y + 11, Celda - 14, Celda - 14);
            DibujarBarra(g, x + 3, y + 1, animador.VidaDibujada(enemigo) / enemigo.VidaMax, Brushes.LimeGreen);
        }

        private void DibujarBarra(Graphics g, float x, float y, float porcentaje, Brush color)
        {
            int ancho = Celda - 6;
            g.FillRectangle(Brushes.DarkSlateGray, x, y, ancho, 4);
            g.FillRectangle(color, x, y, ancho * Math.Max(0, Math.Min(1, porcentaje)), 4);
        }

        // Cada nivel arriba del 1 suma 1 de daño al ataque
        private int BonusNivel()
        {
            return navegador.Progreso.Nivel - 1;
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
            int danio;
            string extra = "";
            if (modo == ModoCombate.Final)
            {
                danio = DanioContraK7(resultado.Valor, out extra);
            }
            else
            {
                // La nave elegida en el Hangar (Builder) suma Ataque / 10 al daño
                danio = resultado.Valor;
                if (navegador.Partida.NaveElegida != null)
                {
                    danio += navegador.Partida.NaveElegida.Ataque / 10;
                }
                danio += BonusNivel();
            }
            gestor.Ejecutar(new AtacarComando(objetivo, danio));
            navegador.ServicioLogros.RegistrarUsoPatron("Command");
            string mensaje = "Atacás a " + objetivo.Nombre + " y hacés " + danio + " de daño" + extra;
            if (!QuedanEnemigos())
            {
                mensaje += ". ¡Ganaste el combate!";
            }
            TerminarTurnoJugador(mensaje);
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
            ResultadoAccion resultado = jugador.Estado.Mover(jugador, dx, dy);
            if (!resultado.Exito)
            {
                lblMensaje.Text = resultado.Mensaje;
                return;
            }
            gestor.Ejecutar(new MoverComando(jugador, nuevaX, nuevaY));
            MostrarUltimoComando();
            SumarComandoDelTurno();
            movimientosEnTurno++;
            if (movimientosEnTurno >= MaxMovimientosPorTurno)
            {
                TerminarTurnoJugador(lblMensaje.Text);
                return;
            }
            Actualizar();
        }

        private void SumarComandoDelTurno()
        {
            comandosDelTurno++;
            deshechosDelTurno = 0;
        }

        private void MostrarUltimoComando()
        {
            lblMensaje.Text = gestor.Historial[gestor.Historial.Count - 1];
            navegador.ServicioLogros.RegistrarUsoPatron("Command");
        }

        private void btnCurar_Click(object sender, EventArgs e)
        {
            if (jugador.Vida == jugador.VidaMax)
            {
                lblMensaje.Text = "Ya tenés la vida al máximo";
                return;
            }
            // En el final solo hay las curaciones que se consiguieron en la campaña
            if (modo == ModoCombate.Final)
            {
                if (curasDisponibles == 0)
                {
                    lblMensaje.Text = "No te quedan curaciones";
                    return;
                }
                curasDisponibles--;
            }
            gestor.Ejecutar(new CurarComando(jugador, Curacion));
            MostrarUltimoComando();
            TerminarTurnoJugador(lblMensaje.Text);
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
            TerminarTurnoJugador(lblMensaje.Text);
        }

        private void btnDeshacer_Click(object sender, EventArgs e)
        {
            if (comandosDelTurno == 0 || !gestor.Deshacer())
            {
                lblMensaje.Text = "No hay nada para deshacer en este turno";
                return;
            }
            comandosDelTurno--;
            deshechosDelTurno++;
            movimientosEnTurno = Math.Max(0, movimientosEnTurno - 1);
            MostrarUltimoComando();
            Actualizar();
        }

        private void btnRehacer_Click(object sender, EventArgs e)
        {
            if (deshechosDelTurno == 0 || !gestor.Rehacer())
            {
                lblMensaje.Text = "No hay nada para rehacer en este turno";
                return;
            }
            comandosDelTurno++;
            deshechosDelTurno--;
            movimientosEnTurno++;
            MostrarUltimoComando();
            Actualizar();
        }

        private void TerminarTurnoJugador(string mensaje)
        {
            mensajeJugador = mensaje;
            movimientosEnTurno = 0;
            comandosDelTurno = 0;
            deshechosDelTurno = 0;
            lblMensaje.Text = mensajeJugador;
            if (jugador.Vida == 0 || !QuedanEnemigos())
            {
                Actualizar();
                return;
            }
            juegaEnemigo = true;
            lblMensaje.Text = mensajeJugador + " | Juegan los enemigos...";
            Actualizar();
            timerTurnoEnemigo.Start();
        }

        private void timerTurnoEnemigo_Tick(object sender, EventArgs e)
        {
            timerTurnoEnemigo.Stop();
            lblMensaje.Text = mensajeJugador;
            if (modo == ModoCombate.Final)
            {
                TurnoK7();
            }
            else
            {
                TurnoAliens();
            }
            juegaEnemigo = false;
            turno++;
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
            int danio = DanioTorreta;
            if (modo == ModoCombate.Final)
            {
                danio = DanioTorretaK7;
                if (jefe.Defendiendo)
                {
                    danio = danio / 2;
                }
            }
            foreach (string torreta in baseJugador.Estructuras)
            {
                Point posicion = PosicionDeTorreta(torreta);
                Personaje objetivo = BuscarEnemigoVivoMasCercano(posicion.X, posicion.Y);
                if (objetivo != null && Math.Abs(objetivo.X - posicion.X) + Math.Abs(objetivo.Y - posicion.Y) <= AlcanceTorreta)
                {
                    objetivo.Vida = Math.Max(0, objetivo.Vida - danio);
                    mensaje += "Torreta dispara a " + objetivo.Nombre + " (" + danio + "). ";
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
            // En el final este botón es "Esperar": el jugador pasa y juega K-7
            if (modo == ModoCombate.Final)
            {
                TerminarTurnoJugador("Esperás.");
                return;
            }
            TerminarTurnoJugador("Pasás el turno.");
        }

        private void TurnoAliens()
        {
            string mensaje = DispararTorretas();
            if (!QuedanEnemigos())
            {
                lblMensaje.Text = mensajeJugador + " | " + mensaje + "¡Ganaste el combate!";
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
                    if (resultado.DanioFinal == 0)
                    {
                        animador.MostrarTexto(jugador, "Bloqueado", Color.LightSkyBlue);
                    }
                    panelCadena.MostrarRecorrido(enemigo.Nombre, resultado);
                    navegador.ServicioLogros.RegistrarUsoPatron("Chain of Responsibility");
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
            lblMensaje.Text = mensajeJugador + " | " + mensaje;
            Actualizar();
        }

        // Daño total que recibieron los enemigos (ataques y torretas del jugador).
        // Se calcula al final, así lo deshecho no cuenta
        private int DanioHecho()
        {
            int danio = 0;
            foreach (Personaje enemigo in enemigos)
            {
                danio += enemigo.VidaMax - enemigo.Vida;
            }
            return danio;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            timerTurnoEnemigo.Stop();
            // Si el combate terminó, el navegador guarda el resultado y muestra victoria o derrota
            if (jugador.Vida == 0 || !QuedanEnemigos())
            {
                animador.Detener();
                navegador.TerminarCombate(modo, jugador.Vida > 0, DanioHecho(), gestor.Historial.Count);
                return;
            }
            // Abandonar el entrenamiento no cuenta; en la práctica y el final cuenta como derrota
            if (modo == ModoCombate.Entrenamiento)
            {
                animador.Detener();
                navegador.IrADiario();
                return;
            }
            DialogResult respuesta = MessageBox.Show("Abandonar cuenta como derrota y no hay reintento. ¿Abandonar?", "Abandonar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (respuesta == DialogResult.Yes)
            {
                animador.Detener();
                navegador.TerminarCombate(modo, false, DanioHecho(), gestor.Historial.Count);
            }
        }

        // ================== Combate final contra K-7 ==================

        // Comandante con los modificadores de la campaña y K-7 como único enemigo
        private void CrearCombateFinal()
        {
            mods = navegador.Campana.CalcularModificadores();

            jugador = new Personaje("Comandante", 100 + mods.VidaExtra, 12);
            jugador.X = 1;
            jugador.Y = 2;
            jugador.Defensa = new CadenaDefensa();
            if (mods.EscudoInicial > 0)
            {
                jugador.Defensa.Agregar(new Escudo(mods.EscudoInicial));
            }
            jugador.Defensa.Agregar(new Armadura(3 + mods.ArmaduraExtra));
            jugador.Defensa.Agregar(new Vida(jugador));

            baseJugador.Recursos = 100 + mods.RecursosExtra;
            curasDisponibles = mods.CuracionesExtra;
            disparoEspecialListo = mods.DisparoEspecial;

            jefe = new JefeK7(mods.JefeVidaExtra, mods.JefeAtaqueExtra, 8, 2);
            enemigos.Add(jefe.Cuerpo);
        }

        // Cambios de la pantalla solo para el final
        private void ConfigurarPantallaFinal()
        {
            panelCadena.SoloLectura();
            panelEstado.SoloLectura();
            lblObjetivos.Visible = false;
            btnDeshacer.Visible = false;
            btnRehacer.Visible = false;
            btnTurnoEnemigo.Text = "Esperar";
            lblK7.Visible = true;
            lblModificadores.Visible = true;
            // El botón de hackeo solo existe si se consiguió el código en la Bóveda
            btnHackear.Visible = mods.PuedeHackearIA;
            lblMensaje.Text = "K-7 te espera. Cada acción tuya es un turno; después juega K-7.";
        }

        // Daño del Comandante contra K-7 con los bonus de la campaña
        private int DanioContraK7(int danioBase, out string extra)
        {
            int danio = danioBase + mods.DanioExtra + mods.DanioContraJefe;
            extra = "";
            if (disparoEspecialListo)
            {
                danio = danio * 2;
                disparoEspecialListo = false;
                extra = " (disparo doble del francotirador)";
            }
            if (jefe.Defendiendo)
            {
                danio = danio / 2;
                extra += " (K-7 se defiende: mitad de daño)";
            }
            return danio;
        }

        // Turno de K-7: disparan las torretas, elige estrategia por fase y actúa según su Strategy
        private void TurnoK7()
        {
            if (jugador.Vida == 0 || !QuedanEnemigos())
            {
                return;
            }
            string mensaje = lblMensaje.Text + " | " + DispararTorretas();
            jefe.Defendiendo = false;
            if (!QuedanEnemigos())
            {
                lblMensaje.Text = mensaje + "¡K-7 fue destruido!";
                Actualizar();
                return;
            }

            mensaje += jefe.ActualizarFase();
            DecisionIA decision = jefe.Decidir(Distancia(jefe.Cuerpo, jugador), jugador.Vida);
            mensaje += "K-7 usa " + jefe.EstrategiaActual + ": " + AplicarDecision(decision);
            jefe.FinDeTurno();
            jugador.FinTurno();
            if (jugador.Vida == 0)
            {
                mensaje += " ¡K-7 te derrotó!";
            }
            lblMensaje.Text = mensaje;
            Actualizar();
        }

        private string AplicarDecision(DecisionIA decision)
        {
            switch (decision.Accion)
            {
                case AccionIA.Atacar:
                    if (EstanAlLado(jefe.Cuerpo, jugador))
                    {
                        return AtaqueDeK7();
                    }
                    return decision.Texto + " Pero estás lejos y falla.";
                case AccionIA.Acercarse:
                    AcercarEnemigo(jefe.Cuerpo);
                    return decision.Texto;
                case AccionIA.Defender:
                    jefe.Defendiendo = true;
                    return decision.Texto;
                case AccionIA.Huir:
                    AlejarEnemigo(jefe.Cuerpo);
                    return decision.Texto;
                default:
                    return decision.Texto;
            }
        }

        // El golpe pasa por la cadena de defensa. Si conocés su estrategia, recibís la mitad.
        private string AtaqueDeK7()
        {
            int vidaAntes = jugador.Vida;
            ResultadoDanio resultado = jugador.RecibirDanio(new Danio(jefe.Cuerpo.AtaqueBase, "Fisico", jefe.Cuerpo));
            int danio = resultado.DanioFinal;
            string nota = "";
            if (jefe.EstrategiaActual == mods.IaAnalizada && danio > 0)
            {
                danio = danio - danio / 2;
                jugador.Vida = Math.Max(0, vidaAntes - danio);
                nota = " (la estudiaste: mitad de daño)";
            }
            panelCadena.MostrarRecorrido("K-7", resultado);
            navegador.ServicioLogros.RegistrarUsoPatron("Chain of Responsibility");
            if (danio == 0)
            {
                animador.MostrarTexto(jugador, "Bloqueado", Color.LightSkyBlue);
            }
            return "ataca y te hace " + danio + " de daño" + nota + ".";
        }

        // Distancia en casillas contando diagonales (1 = al lado)
        private int Distancia(Personaje a, Personaje b)
        {
            return Math.Max(Math.Abs(a.X - b.X), Math.Abs(a.Y - b.Y));
        }

        // Un paso en dirección contraria al jugador, si la casilla está libre
        private void AlejarEnemigo(Personaje enemigo)
        {
            int dx = Math.Sign(enemigo.X - jugador.X);
            int dy = Math.Sign(enemigo.Y - jugador.Y);
            if (dx != 0 && PuedeIr(enemigo.X + dx, enemigo.Y))
            {
                enemigo.Mover(dx, 0);
            }
            else if (dy != 0 && PuedeIr(enemigo.X, enemigo.Y + dy))
            {
                enemigo.Mover(0, dy);
            }
        }

        private bool PuedeIr(int x, int y)
        {
            bool dentro = x >= 0 && x < Columnas && y >= 0 && y < Filas;
            return dentro && !EstaOcupada(x, y);
        }

        private void btnHackear_Click(object sender, EventArgs e)
        {
            if (!jefe.Hackear())
            {
                return;
            }
            TerminarTurnoJugador("Usás el código de apagado: K-7 queda en IAAleatoria por " + JefeK7.TurnosHackeo + " turnos.");
        }

        private void MostrarK7()
        {
            string texto = "K-7 usa: " + jefe.EstrategiaActual;
            if (jefe.TurnosHackeado > 0)
            {
                texto += " (hackeada, " + jefe.TurnosHackeado + " turnos)";
            }
            if (jefe.Defendiendo)
            {
                texto += " (defendiéndose)";
            }
            texto += "\nVida de K-7: " + jefe.Cuerpo.Vida + " / " + jefe.Cuerpo.VidaMax;
            lblK7.Text = texto;
        }

        // Panel lateral con los modificadores de la campaña que están en juego
        private void MostrarModificadores()
        {
            string ia = mods.IaAnalizada == "" ? "ninguna" : mods.IaAnalizada;
            string francotirador = mods.DisparoEspecial ? (disparoEspecialListo ? "listo" : "usado") : "no";
            string hackeo = mods.PuedeHackearIA ? (jefe.HackUsado ? "usado" : "disponible") : "no (sin código)";
            lblModificadores.Text = "Modificadores de la campaña:\n"
                + "Vida: " + jugador.Vida + " / " + jugador.VidaMax + " (base 100, " + ConSigno(mods.VidaExtra) + ")\n"
                + "Daño: 12 " + ConSigno(mods.DanioExtra) + " " + ConSigno(mods.DanioContraJefe) + " contra K-7\n"
                + "Armadura: " + (3 + mods.ArmaduraExtra) + "   Escudo: " + PuntosDeEscudo() + "\n"
                + "Recursos: " + baseJugador.Recursos + " (torreta: " + CostoTorreta + ", hace " + DanioTorretaK7 + " a K-7)\n"
                + "Curaciones: " + curasDisponibles + " de +" + Curacion + "\n"
                + "Disparo doble: " + francotirador + "   Hackeo: " + hackeo + "\n"
                + "IA estudiada: " + ia + " (mitad de daño)\n"
                + "K-7: vida " + JefeK7.VidaBase + " " + ConSigno(mods.JefeVidaExtra) + ", ataque " + JefeK7.AtaqueBase + " " + ConSigno(mods.JefeAtaqueExtra);
        }

        private string ConSigno(int valor)
        {
            return valor >= 0 ? "+" + valor : valor.ToString();
        }
    }
}
