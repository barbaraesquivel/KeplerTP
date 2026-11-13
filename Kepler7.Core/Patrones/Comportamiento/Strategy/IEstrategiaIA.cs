namespace Kepler7.Core.Patrones.Comportamiento.Strategy
{
    // Interfaz Strategy: cada IA decide qué hacer en su turno
    public interface IEstrategiaIA
    {
        DecisionIA DecidirAccion(Enemigo enemigo, Contexto contexto);
    }
}
