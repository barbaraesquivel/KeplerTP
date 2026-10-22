namespace Kepler7.Core.Patrones.Comportamiento.Chain
{
    public interface IManejadorDanio
    {
        IManejadorDanio Siguiente { get; set; }
        void Manejar(Danio danio);
    }
}
