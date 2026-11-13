namespace Kepler7.Core.Patrones.Comportamiento.Strategy
{
    // Remata si el jugador está débil, huye si ella está débil; si no, combate normal
    public class IACalculadora : IEstrategiaIA
    {
        public const int VidaJugadorDebil = 40;
        public const int VidaPropiaCritica = 30;

        public DecisionIA DecidirAccion(Enemigo enemigo, Contexto contexto)
        {
            // Jugador débil: va a rematar siempre
            if (contexto.SaludDelJugador < VidaJugadorDebil)
            {
                if (contexto.EstaAlLado)
                {
                    return new DecisionIA(AccionIA.Atacar, $"[Calculadora] {enemigo.Nombre} detecta que estás débil y ataca.");
                }
                return new DecisionIA(AccionIA.Acercarse, $"[Calculadora] {enemigo.Nombre} detecta que estás débil y va a buscarte.");
            }
            if (enemigo.Salud < VidaPropiaCritica)
            {
                return new DecisionIA(AccionIA.Huir, $"[Calculadora] {enemigo.Nombre} detecta salud crítica y se aleja un paso.");
            }
            if (contexto.EstaAlLado)
            {
                return new DecisionIA(AccionIA.Atacar, $"[Calculadora] {enemigo.Nombre} calcula el golpe exacto y ataca.");
            }
            return new DecisionIA(AccionIA.Acercarse, $"[Calculadora] {enemigo.Nombre} calcula la ruta más corta y se acerca.");
        }
    }
}
