namespace Kepler7.Core.Modelo
{
    // Una decisión de la campaña con cuánto ayudó en el final y qué habría convenido
    public class EfectoDecision
    {
        public string Texto { get; set; }

        // Positivo = ayudó, negativo = perjudicó, 0 = no sumó nada
        public int Puntos { get; set; }

        // Vacío si la decisión fue buena
        public string Consejo { get; set; }

        public EfectoDecision(string texto, int puntos, string consejo)
        {
            Texto = texto;
            Puntos = puntos;
            Consejo = consejo;
        }
    }
}
