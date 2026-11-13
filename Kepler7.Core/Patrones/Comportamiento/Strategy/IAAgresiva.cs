namespace Kepler7.Core.Patrones.Comportamiento.Strategy
{
    // Si está al lado ataca; si no, se acerca
    public class IAAgresiva : IEstrategiaIA
    {
        public DecisionIA DecidirAccion(Enemigo enemigo, Contexto contexto)
        {
            if (contexto.EstaAlLado)
            {
                return new DecisionIA(AccionIA.Atacar, $"[Agresiva] {enemigo.Nombre} ataca con todo su arsenal.");
            }
            return new DecisionIA(AccionIA.Acercarse, $"[Agresiva] {enemigo.Nombre} avanza directo hacia vos.");
        }
    }
}
