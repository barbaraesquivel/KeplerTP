using Kepler7.Core.Modelo;
using Kepler7.Core.Patrones.Comportamiento.Chain;

namespace Kepler7.Core.Patrones.Comportamiento.State
{
    public class Normal : IEstadoPersonaje
    {
        public string Nombre
        {
            get { return "Normal"; }
        }

        public EstadoVisual Visual
        {
            get { return EstadoVisual.Normal; }
        }

        public ResultadoAccion Atacar(Personaje personaje)
        {
            int danio = personaje.AtaqueBase;
            return new ResultadoAccion(true, personaje.Nombre + " ataca y hace " + danio + " de daño", danio);
        }

        public ResultadoAccion Mover(Personaje personaje, int dx, int dy)
        {
            personaje.X += dx;
            personaje.Y += dy;
            return new ResultadoAccion(true, personaje.Nombre + " se mueve a (" + personaje.X + ", " + personaje.Y + ")", 1);
        }

        public ResultadoDanio RecibirDanio(Personaje personaje, Danio danio)
        {
            return personaje.Defensa.Procesar(danio);
        }

        public void FinTurno(Personaje personaje)
        {
        }
    }
}
