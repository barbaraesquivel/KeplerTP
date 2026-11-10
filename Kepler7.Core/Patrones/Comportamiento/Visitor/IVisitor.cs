namespace Kepler7.Core.Patrones.Comportamiento.Visitor
{
    // Interfaz Visitor: declara un método de visita para cada clase concreta de ítem
    public interface IVisitor
    {
        void Visitar(Arma arma);
        void Visitar(Pocion pocion);
        void Visitar(Armadura armadura);
        string ObtenerResultado();
    }
}
