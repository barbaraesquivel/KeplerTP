namespace Kepler7.Core.Patrones.Comportamiento.Strategy
{
    // Elige cualquier acción al azar
    public class IAAleatoria : IEstrategiaIA
    {
        private static Random random = new Random();

        public DecisionIA DecidirAccion(Enemigo enemigo, Contexto contexto)
        {
            AccionIA accion = (AccionIA)random.Next(0, 5);
            return new DecisionIA(accion, $"[Aleatoria] {enemigo.Nombre} tiene los circuitos cruzados y elige: {accion}.");
        }
    }
}
