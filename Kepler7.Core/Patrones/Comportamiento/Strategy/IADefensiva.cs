namespace Kepler7.Core.Patrones.Comportamiento.Strategy
{
    // Si está al lado ataca la mitad de las veces; el resto del tiempo se defiende
    public class IADefensiva : IEstrategiaIA
    {
        private static Random random = new Random();

        public DecisionIA DecidirAccion(Enemigo enemigo, Contexto contexto)
        {
            if (contexto.EstaAlLado && random.Next(2) == 0)
            {
                return new DecisionIA(AccionIA.Atacar, $"[Defensiva] {enemigo.Nombre} aprovecha la cercanía y ataca.");
            }
            return new DecisionIA(AccionIA.Defender, $"[Defensiva] {enemigo.Nombre} levanta un escudo de energía (recibe la mitad de daño).");
        }
    }
}
