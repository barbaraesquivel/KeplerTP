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
            return new ResultadoAccion(true, personaje.Nombre + " se mueve", 1);
        }

        public ResultadoDanio RecibirDanio(Personaje personaje, Danio danio)
        {
            ResultadoDanio resultado = personaje.Defensa.Procesar(danio);
            if (danio.Tipo == "Veneno" && resultado.DanioFinal > 0)
            {
                personaje.CambiarEstado(new Envenenado(5, 3));
            }
            else if (personaje.Vida > 0 && personaje.Vida <= personaje.VidaMax * 3 / 10)
            {
                personaje.CambiarEstado(new Berserk(3));
            }
            return resultado;
        }

        public void FinTurno(Personaje personaje)
        {
        }
    }
}
