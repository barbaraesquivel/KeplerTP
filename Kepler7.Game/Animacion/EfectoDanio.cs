namespace Kepler7.Game.Animacion
{
    public class EfectoDanio
    {
        private const int Duracion = 30;

        public string Texto { get; }
        public float X { get; }
        public float Y { get; private set; }
        public Color Color { get; }
        public int FramesRestantes { get; private set; }

        public EfectoDanio(string texto, float x, float y, Color color)
        {
            Texto = texto;
            X = x;
            Y = y;
            Color = color;
            FramesRestantes = Duracion;
        }

        public bool Terminado
        {
            get { return FramesRestantes <= 0; }
        }

        public int Opacidad
        {
            get { return 255 * FramesRestantes / Duracion; }
        }

        public void Avanzar()
        {
            Y -= 0.03f;
            FramesRestantes--;
        }
    }
}
