namespace Kepler7.Core.Patrones.Comportamiento.Chain
{
    public class Escudo : IManejadorDanio
    {
        public IManejadorDanio Siguiente { get; set; }
        public int Puntos { get; set; }

        public Escudo(int puntos)
        {
            Puntos = puntos;
        }

        public void Manejar(Danio danio)
        {
            int recibido = danio.Cantidad;
            int absorbido = Math.Min(Puntos, recibido);
            Puntos -= absorbido;
            danio.Cantidad = recibido - absorbido;
            danio.Resultado.AgregarPaso("Escudo", recibido, absorbido);
            if (danio.Cantidad > 0 && Siguiente != null)
            {
                Siguiente.Manejar(danio);
            }
        }
    }
}
