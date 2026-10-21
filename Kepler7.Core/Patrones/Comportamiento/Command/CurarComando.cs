using Kepler7.Core.Modelo;

namespace Kepler7.Core.Patrones.Comportamiento.Command
{
    // Cura a una unidad sin pasarse de su vida máxima
    public class CurarComando : IComando
    {
        private Unidad unidad;
        private int cantidad;
        private int vidaPrevia;

        public string Descripcion { get; }

        public CurarComando(Unidad unidad, int cantidad)
        {
            this.unidad = unidad;
            this.cantidad = cantidad;
            Descripcion = "Curar a " + unidad.Nombre + " (+" + cantidad + " de vida)";
        }

        public void Ejecutar()
        {
            vidaPrevia = unidad.Vida;
            unidad.Vida = unidad.Vida + cantidad;
            if (unidad.Vida > unidad.VidaMax)
            {
                unidad.Vida = unidad.VidaMax;
            }
        }

        public void Deshacer()
        {
            unidad.Vida = vidaPrevia;
        }
    }
}
