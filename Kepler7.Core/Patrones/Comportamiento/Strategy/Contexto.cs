namespace Kepler7.Core.Patrones.Comportamiento.Strategy
{
    // Datos de la situación que la IA usa para decidir
    public class Contexto
    {
        // Distancia en casillas (1 = al lado)
        public int DistanciaAlJugador { get; set; }
        public int SaludDelJugador { get; set; }

        public bool EstaAlLado
        {
            get { return DistanciaAlJugador <= 1; }
        }
    }
}
