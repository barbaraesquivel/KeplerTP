namespace Kepler7.Core.Patrones.Comportamiento.Visitor
{
    // Elemento Concreto: Poción
    public class Pocion : IItem
    {
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int PuntosCuracion { get; set; }
        public bool EsVenenosa { get; set; }

        public Pocion(string nombre, double precio, int puntosCuracion)
        {
            Nombre = nombre;
            Precio = precio;
            PuntosCuracion = puntosCuracion;
            EsVenenosa = false;
        }

        public void Aceptar(IVisitor visitor)
        {
            visitor.Visitar(this); // Doble Dispatch
        }

        public override string ToString()
        {
            string estado = EsVenenosa ? " [¡VENENO LETAL!]" : $" [Cura: +{PuntosCuracion} HP]";
            return $"{Nombre} |{estado} | Precio: {Precio} cr.";
        }
    }
}
