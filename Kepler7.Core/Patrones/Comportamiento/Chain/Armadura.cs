namespace Kepler7.Core.Patrones.Comportamiento.Chain
{
    public class Armadura : IManejadorDanio
    {
        public IManejadorDanio Siguiente { get; set; }
        public int Reduccion { get; set; }

        public Armadura(int reduccion)
        {
            Reduccion = reduccion;
        }

        public void Manejar(Danio danio)
        {
            int recibido = danio.Cantidad;
            int absorbido = Math.Min(Reduccion, recibido);
            danio.Cantidad = recibido - absorbido;
            danio.Resultado.AgregarPaso("Armadura", recibido, absorbido);
            if (danio.Cantidad > 0 && Siguiente != null)
            {
                Siguiente.Manejar(danio);
            }
        }
    }
}
