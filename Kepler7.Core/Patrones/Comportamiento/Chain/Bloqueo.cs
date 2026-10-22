namespace Kepler7.Core.Patrones.Comportamiento.Chain
{
    public class Bloqueo : IManejadorDanio
    {
        public IManejadorDanio Siguiente { get; set; }
        public int Porcentaje { get; set; }

        public Bloqueo(int porcentaje)
        {
            Porcentaje = porcentaje;
        }

        public void Manejar(Danio danio)
        {
            int recibido = danio.Cantidad;
            int absorbido = recibido * Porcentaje / 100;
            danio.Cantidad = recibido - absorbido;
            danio.Resultado.AgregarPaso("Bloqueo", recibido, absorbido);
            if (danio.Cantidad > 0 && Siguiente != null)
            {
                Siguiente.Manejar(danio);
            }
        }
    }
}
