using Kepler7.Core.Modelo;

namespace Kepler7.Game.Animacion
{
    public class AnimadorTimer
    {
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private Control lienzo;
        private Dictionary<Personaje, PointF> posiciones = new Dictionary<Personaje, PointF>();
        private Dictionary<Personaje, float> vidasDibujadas = new Dictionary<Personaje, float>();
        private Dictionary<Personaje, int> ultimasVidas = new Dictionary<Personaje, int>();
        private Dictionary<Personaje, int> parpadeos = new Dictionary<Personaje, int>();
        private List<EfectoDanio> efectos = new List<EfectoDanio>();

        public Color ColorJugador { get; private set; }
        public Color ColorObjetivo { get; set; }

        public List<EfectoDanio> Efectos
        {
            get { return efectos; }
        }

        public AnimadorTimer(Control lienzo, Color colorInicial)
        {
            this.lienzo = lienzo;
            ColorJugador = colorInicial;
            ColorObjetivo = colorInicial;
            timer.Interval = 30;
            timer.Tick += timer_Tick;
            timer.Start();
        }

        public void Registrar(Personaje personaje)
        {
            posiciones[personaje] = new PointF(personaje.X, personaje.Y);
            vidasDibujadas[personaje] = personaje.Vida;
            ultimasVidas[personaje] = personaje.Vida;
            parpadeos[personaje] = 0;
        }

        public void Detener()
        {
            timer.Stop();
        }

        public PointF Posicion(Personaje personaje)
        {
            return posiciones[personaje];
        }

        public float VidaDibujada(Personaje personaje)
        {
            return vidasDibujadas[personaje];
        }

        public bool EstaParpadeando(Personaje personaje)
        {
            return parpadeos[personaje] > 0 && parpadeos[personaje] % 4 < 2;
        }

        public void MostrarTexto(Personaje personaje, string texto, Color color)
        {
            PointF posicion = posiciones[personaje];
            efectos.Add(new EfectoDanio(texto, posicion.X, posicion.Y, color));
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            foreach (Personaje personaje in new List<Personaje>(posiciones.Keys))
            {
                AnimarPersonaje(personaje);
            }
            for (int i = efectos.Count - 1; i >= 0; i--)
            {
                efectos[i].Avanzar();
                if (efectos[i].Terminado)
                {
                    efectos.RemoveAt(i);
                }
            }
            ColorJugador = Color.FromArgb(
                Acercar(ColorJugador.R, ColorObjetivo.R),
                Acercar(ColorJugador.G, ColorObjetivo.G),
                Acercar(ColorJugador.B, ColorObjetivo.B));
            lienzo.Invalidate();
        }

        private void AnimarPersonaje(Personaje personaje)
        {
            DetectarCambioDeVida(personaje);
            PointF posicion = posiciones[personaje];
            float nuevaX = posicion.X + (personaje.X - posicion.X) * 0.25f;
            float nuevaY = posicion.Y + (personaje.Y - posicion.Y) * 0.25f;
            posiciones[personaje] = new PointF(nuevaX, nuevaY);
            vidasDibujadas[personaje] += (personaje.Vida - vidasDibujadas[personaje]) * 0.1f;
            if (parpadeos[personaje] > 0)
            {
                parpadeos[personaje]--;
            }
        }

        private void DetectarCambioDeVida(Personaje personaje)
        {
            int diferencia = personaje.Vida - ultimasVidas[personaje];
            if (diferencia < 0)
            {
                MostrarTexto(personaje, diferencia.ToString(), Color.OrangeRed);
                parpadeos[personaje] = 12;
            }
            else if (diferencia > 0)
            {
                MostrarTexto(personaje, "+" + diferencia, Color.LimeGreen);
            }
            ultimasVidas[personaje] = personaje.Vida;
        }

        private int Acercar(int actual, int objetivo)
        {
            int paso = (objetivo - actual) / 6;
            if (paso == 0)
            {
                paso = Math.Sign(objetivo - actual);
            }
            return actual + paso;
        }
    }
}
