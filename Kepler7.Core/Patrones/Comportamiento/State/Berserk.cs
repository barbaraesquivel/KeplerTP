using Kepler7.Core.Modelo;
using Kepler7.Core.Patrones.Comportamiento.Chain;

namespace Kepler7.Core.Patrones.Comportamiento.State
{
    public class Berserk : IEstadoPersonaje
    {
        public int TurnosRestantes { get; set; }

        public Berserk(int turnos)
        {
            TurnosRestantes = turnos;
        }

        public string Nombre
        {
            get { return "Berserk"; }
        }

        public EstadoVisual Visual
        {
            get { return EstadoVisual.Berserk; }
        }

        public ResultadoAccion Atacar(Personaje personaje)
        {
            int danio = personaje.AtaqueBase * 2;
            return new ResultadoAccion(true, personaje.Nombre + " ataca con furia y hace " + danio + " de daño", danio);
        }

        public ResultadoAccion Mover(Personaje personaje, int dx, int dy)
        {
            personaje.X += dx;
            personaje.Y += dy;
            return new ResultadoAccion(true, personaje.Nombre + " se mueve a (" + personaje.X + ", " + personaje.Y + ")", 1);
        }

        public ResultadoDanio RecibirDanio(Personaje personaje, Danio danio)
        {
            danio.Cantidad = danio.Cantidad * 3 / 2;
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
