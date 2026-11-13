namespace Kepler7.Core.Patrones.Comportamiento.Strategy
{
    // Lo que decidió la estrategia: la acción (para el juego) y un texto (para mostrar)
    public class DecisionIA
    {
        public AccionIA Accion { get; set; }
        public string Texto { get; set; }

        public DecisionIA(AccionIA accion, string texto)
        {
            Accion = accion;
            Texto = texto;
        }
    }
}
