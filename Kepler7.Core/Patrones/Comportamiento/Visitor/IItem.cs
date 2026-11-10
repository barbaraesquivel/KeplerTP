namespace Kepler7.Core.Patrones.Comportamiento.Visitor
{
    // Interfaz Elemento: declara el método Aceptar para el Doble Dispatch
    public interface IItem
    {
        string Nombre { get; set; }
        double Precio { get; set; }
        void Aceptar(IVisitor visitor);
    }
}
