using Kepler7.Core.Modelo;
using Kepler7.Core.Patrones.Comportamiento.Chain;

namespace Kepler7.Core.Patrones.Comportamiento.State
{
    public enum EstadoVisual
    {
        Normal,
        Envenenado,
        Aturdido,
        Berserk
    }

    public class ResultadoAccion
    {
        public bool Exito { get; set; }
        public string Mensaje { get; set; }
        public int Valor { get; set; }

        public ResultadoAccion(bool exito, string mensaje, int valor)
        {
            Exito = exito;
            Mensaje = mensaje;
            Valor = valor;
        }
    }

    public interface IEstadoPersonaje
    {
        string Nombre { get; }
        EstadoVisual Visual { get; }
        ResultadoAccion Atacar(Personaje personaje);
        ResultadoAccion Mover(Personaje personaje, int dx, int dy);
        ResultadoDanio RecibirDanio(Personaje personaje, Danio danio);
        void FinTurno(Personaje personaje);
    }
}
