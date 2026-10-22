using Kepler7.Core.Modelo;

namespace Kepler7.Core.Patrones.Comportamiento.Chain
{
    public class Danio
    {
        public int Cantidad { get; set; }
        public string Tipo { get; set; }
        public Unidad Atacante { get; set; }
        public ResultadoDanio Resultado { get; set; } = new ResultadoDanio();

        public Danio(int cantidad, string tipo, Unidad atacante)
        {
            Cantidad = cantidad;
            Tipo = tipo;
            Atacante = atacante;
        }
    }
}
