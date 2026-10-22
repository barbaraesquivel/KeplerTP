namespace Kepler7.Core.Patrones.Creacionales.Prototype
{
    public class TripulanteClonable : IPrototipo<TripulanteClonable>
    {
        public string Nombre { get; set; }
        public string Especie { get; set; }
        public int Nivel { get; set; }
        public List<string> Habilidades { get; set; } = new List<string>();

        public TripulanteClonable(string nombre, string especie, int nivel)
        {
            Nombre = nombre;
            Especie = especie;
            Nivel = nivel;
        }

        public TripulanteClonable Clonar()
        {
            TripulanteClonable clon = new TripulanteClonable(Nombre, Especie, Nivel);
            foreach (string habilidad in Habilidades)
            {
                clon.Habilidades.Add(habilidad);
            }
            return clon;
        }

        public override string ToString()
        {
            return Nombre + " (" + Especie + ") Nivel " + Nivel + " - Habilidades: " + string.Join(", ", Habilidades);
        }
    }
}
