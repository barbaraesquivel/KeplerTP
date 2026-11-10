namespace Kepler7.Core.Patrones.Comportamiento.Visitor
{
    // Elemento Concreto: Arma
    public class Arma : IItem
    {
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int Danio { get; set; }
        public bool TieneVeneno { get; set; }

        public Arma(string nombre, double precio, int danio)
        {
            Nombre = nombre;
            Precio = precio;
            Danio = danio;
            TieneVeneno = false;
        }

        public void Aceptar(IVisitor visitor)
        {
            visitor.Visitar(this); // Doble Dispatch
        }

        public override string ToString()
        {
            string veneno = TieneVeneno ? " [¡ENVENENADA!]" : "";
            return $"{Nombre} | Daño: {Danio} | Precio: {Precio} cr.{veneno}";
        }
    }
}
