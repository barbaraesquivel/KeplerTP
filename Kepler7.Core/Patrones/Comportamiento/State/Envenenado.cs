using Kepler7.Core.Modelo;
using Kepler7.Core.Patrones.Comportamiento.Chain;

namespace Kepler7.Core.Patrones.Comportamiento.State
{
    public class Envenenado : IEstadoPersonaje
    {
        public int DanioPorTurno { get; set; }
        public int TurnosRestantes { get; set; }

        public Envenenado(int danioPorTurno, int turnos)
        {
            DanioPorTurno = danioPorTurno;
            TurnosRestantes = turnos;
        }

        public string Nombre
        {
            get { return "Envenenado"; }
        }

        public EstadoVisual Visual
        {
            get { return EstadoVisual.Envenenado; }
        }

        public ResultadoAccion Atacar(Personaje personaje)
        {
            int danio = personaje.AtaqueBase;
            return new ResultadoAccion(true, personaje.Nombre + " ataca envenenado y hace " + danio + " de daño", danio);
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
            personaje.Vida = Math.Max(0, personaje.Vida - DanioPorTurno);
            TurnosRestantes--;
            if (TurnosRestantes <= 0)
            {
                personaje.CambiarEstado(new Normal());
            }
        }
    }
}
