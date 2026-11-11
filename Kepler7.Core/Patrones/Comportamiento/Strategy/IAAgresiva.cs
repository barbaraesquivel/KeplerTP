namespace Kepler7.Core.Patrones.Comportamiento.Strategy
{
    public class IAAgresiva : IEstrategiaIA
    {
        public string DecidirAccion(Enemigo enemigo, Contexto contexto)
        {
            return $"[Agresiva] {enemigo.Nombre} ignora su propia salud y ataca con todo su arsenal.";
        }
    }
}
