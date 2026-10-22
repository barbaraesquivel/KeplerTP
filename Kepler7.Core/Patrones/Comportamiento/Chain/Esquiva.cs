namespace Kepler7.Core.Patrones.Comportamiento.Chain
{
    public class Esquiva : IManejadorDanio
    {
        public IManejadorDanio Siguiente { get; set; }
        public int Probabilidad { get; set; }
        private Random random;

        public Esquiva(int probabilidad, Random random)
        {
            Probabilidad = probabilidad;
            this.random = random;
        }

        public void Manejar(Danio danio)
        {
            int recibido = danio.Cantidad;
            if (random.Next(100) < Probabilidad)
            {
                danio.Cantidad = 0;
                danio.Resultado.AgregarPaso("Esquiva", recibido, recibido);
                return;
            }
            danio.Resultado.AgregarPaso("Esquiva", recibido, 0);
            if (Siguiente != null)
            {
                Siguiente.Manejar(danio);
            }
        }
    }
}
