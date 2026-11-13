namespace Kepler7.Core.Modelo
{
    // Datos de la misión. Por ahora hay una sola misión fija
    public class Mision
    {
        public string Nombre { get; set; } = "Práctica contra los drones de K-7";
        public string Objetivo { get; set; } = "Eliminá a los drones de entrenamiento de K-7 en el sector 4";
        public int RecompensaXp { get; set; } = 100;
        public int RecompensaMonedas { get; set; } = 50;
    }
}
