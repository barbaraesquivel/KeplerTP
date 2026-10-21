namespace Kepler7.Core.Modelo
{
    // Unidad del juego (soldado, robot, etc.)
    public class Unidad
    {
        public string Nombre { get; set; }
        public int Vida { get; set; }
        public int VidaMax { get; set; }
        public int Energia { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
