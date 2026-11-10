namespace Kepler7.Core.Patrones.Estructurales.Flyweight
{
    // Flyweight Concreto: almacena el estado intrínseco compartido
    public class Especie : IEspecie
    {
        public string Nombre { get; }
        public string Color { get; }
        public string PlanetaOrigen { get; }
        public string Dieta { get; }

        // Simula la textura/modelo pesado en memoria (100 KB por especie)
        public byte[] TexturaSkin { get; }

        public Especie(string nombre, string color, string planetaOrigen, string dieta)
        {
            Nombre = nombre;
            Color = color;
            PlanetaOrigen = planetaOrigen;
            Dieta = dieta;
            TexturaSkin = new byte[100 * 1024];
        }

        public override string ToString()
        {
            return $"{Nombre} (Color: {Color}, Origen: {PlanetaOrigen}, Dieta: {Dieta})";
        }
    }
}
