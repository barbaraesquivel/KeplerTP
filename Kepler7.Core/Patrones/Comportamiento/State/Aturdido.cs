using Kepler7.Core.Modelo;
using Kepler7.Core.Patrones.Comportamiento.Chain;

namespace Kepler7.Core.Patrones.Comportamiento.State
{
    public class Aturdido : IEstadoPersonaje
    {
        public int TurnosRestantes { get; set; }

        public Aturdido(int turnos)
        {
            TurnosRestantes = turnos;
        }

        public string Nombre
        {
            get { return "Aturdido"; }
        }

        public EstadoVisual Visual
        {
            get { return EstadoVisual.Aturdido; }
        }

        public ResultadoAccion Atacar(Personaje personaje)
        {
            return new ResultadoAccion(false, personaje.Nombre + " está aturdido y no puede atacar", 0);
        }

        public ResultadoAccion Mover(Personaje personaje, int dx, int dy)
        {
            return new ResultadoAccion(false, personaje.Nombre + " está aturdido y no puede moverse", 0);
        }

        public ResultadoDanio RecibirDanio(Personaje personaje, Danio danio)
        {
            return personaje.Defensa.Procesar(danio);
        }

        public void FinTurno(Personaje personaje)
        {
            TurnosRestantes--;
            if (TurnosRestantes <= 0)
            {
                personaje.CambiarEstado(new Normal());
            }
        }
    }
}
