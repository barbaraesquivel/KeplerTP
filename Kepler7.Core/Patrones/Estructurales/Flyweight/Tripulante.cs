namespace Kepler7.Core.Patrones.Estructurales.Flyweight
{
    // Contexto / Cliente del Flyweight: almacena el estado extrínseco (Id, Nombre, Rango)
    // y hace referencia a la IEspecie compartida (estado intrínseco).
    public class Tripulante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Rango { get; set; }
        public IEspecie Especie { get; set; }

        public Tripulante(int id, string nombre, string rango, IEspecie especie)
        {
            Id = id;
            Nombre = nombre;
            Rango = rango;
            Especie = especie;
        }

        // Sobrecarga de constructor con orden alternativo de parámetros
        public Tripulante(string nombre, int id, string rango, IEspecie especie)
            : this(id, nombre, rango, especie)
        {
        }

        public override string ToString()
        {
            return $"[ID {Id}] {Nombre} ({Rango}) - Especie: {Especie?.Nombre} ({Especie?.PlanetaOrigen})";
        }
    }
}
