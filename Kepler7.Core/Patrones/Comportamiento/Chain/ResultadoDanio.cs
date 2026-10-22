namespace Kepler7.Core.Patrones.Comportamiento.Chain
{
    public class ResultadoDanio
    {
        public List<string> Recorrido { get; set; } = new List<string>();
        public int DanioFinal { get; set; }

        public void AgregarPaso(string eslabon, int recibido, int absorbido)
        {
            Recorrido.Add(eslabon + ": recibió " + recibido + ", absorbió " + absorbido);
        }
    }
}
