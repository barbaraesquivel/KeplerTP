using Kepler7.Core.Modelo;

namespace Kepler7.Core.Patrones.Comportamiento.Chain
{
    public class Vida : IManejadorDanio
    {
        public IManejadorDanio Siguiente { get; set; }
        public Unidad Objetivo { get; set; }

        public Vida(Unidad objetivo)
        {
            Objetivo = objetivo;
        }

        public void Manejar(Danio danio)
        {
            int recibido = danio.Cantidad;
            Objetivo.Vida = Math.Max(0, Objetivo.Vida - recibido);
            danio.Cantidad = 0;
            danio.Resultado.DanioFinal = recibido;
            danio.Resultado.AgregarPaso("Vida", recibido, recibido);
        }
    }
}
