using Kepler7.Core.Patrones.Creacionales.Builder;

namespace Kepler7.Core.Modelo
{
    // Datos de la partida actual, compartidos por todas las pantallas
    public class Partida
    {
        public Nave NaveElegida { get; set; }
        public int MisionesGanadas { get; set; }
        public int MisionesPerdidas { get; set; }
        public int DanioTotal { get; set; }
        public int ComandosUsados { get; set; }
        public int XpGanada { get; set; }
        public int MonedasGanadas { get; set; }
    }
}
