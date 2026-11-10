namespace Kepler7.Core.Patrones.Estructurales.Flyweight
{
    // Interfaz Flyweight: define el estado intrínseco compartido de una especie
    public interface IEspecie
    {
        string Nombre { get; }
        string Color { get; }
        string PlanetaOrigen { get; }
        string Dieta { get; }
    }
}
