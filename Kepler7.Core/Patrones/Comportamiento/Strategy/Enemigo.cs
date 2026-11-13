namespace Kepler7.Core.Patrones.Comportamiento.Strategy
{
    public class Enemigo
    {
        public string Nombre { get; set; }
        public int Salud { get; set; }

        private IEstrategiaIA estrategia;

        public Enemigo(string nombre, int salud, IEstrategiaIA estrategiaInicial)
        {
            this.Nombre = nombre;
            this.Salud = salud;
            this.estrategia = estrategiaInicial;
        }

        public void SetEstrategia(IEstrategiaIA nuevaEstrategia)
        {
            this.estrategia = nuevaEstrategia;
        }

        public DecisionIA EjecutarAccion(Contexto contextoActual)
        {
            return this.estrategia.DecidirAccion(this, contextoActual);
        }

        public string NombreEstrategiaActual => this.estrategia.GetType().Name;

    }
}
