using Kepler7.Core.Modelo;

namespace Kepler7.Core.Patrones.Comportamiento.Command
{
    // Mueve una unidad y recuerda dónde estaba
    public class MoverComando : IComando
    {
        private Unidad unidad;
        private int nuevaX;
        private int nuevaY;
        private int xAnterior;
        private int yAnterior;

        public string Descripcion { get; }

        public MoverComando(Unidad unidad, int nuevaX, int nuevaY)
        {
            this.unidad = unidad;
            this.nuevaX = nuevaX;
            this.nuevaY = nuevaY;
            Descripcion = "Mover " + unidad.Nombre + " a (" + nuevaX + ", " + nuevaY + ")";
        }

        public void Ejecutar()
        {
            // Guardamos la posición actual antes de mover
            xAnterior = unidad.X;
            yAnterior = unidad.Y;
            unidad.X = nuevaX;
            unidad.Y = nuevaY;
        }

        public void Deshacer()
        {
            unidad.X = xAnterior;
            unidad.Y = yAnterior;
        }
    }
}
