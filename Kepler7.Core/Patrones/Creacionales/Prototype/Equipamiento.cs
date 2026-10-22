namespace Kepler7.Core.Patrones.Creacionales.Prototype
{
    public class Equipamiento : IPrototipo<Equipamiento>
    {
        public string Arma { get; set; }
        public string Traje { get; set; }
        public List<string> Objetos { get; set; } = new List<string>();

        public Equipamiento(string arma, string traje)
        {
            Arma = arma;
            Traje = traje;
        }

        public Equipamiento Clonar()
        {
            Equipamiento copia = new Equipamiento(Arma, Traje);
            foreach (string objeto in Objetos)
            {
                copia.Objetos.Add(objeto);
            }
            return copia;
        }

        public override string ToString()
        {
            return Arma + ", " + Traje + " - Objetos: " + string.Join(", ", Objetos);
        }
    }
}
