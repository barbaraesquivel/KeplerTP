namespace Kepler7.Core.Patrones.Comportamiento.Visitor
{
    // Elemento Concreto: Armadura
    public class Armadura : IItem
    {
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int Defensa { get; set; }
        public bool ResistenteAlVeneno { get; set; }

        public Armadura(string nombre, double precio, int defensa)
        {
            Nombre = nombre;
            Precio = precio;
            Defensa = defensa;
            ResistenteAlVeneno = false;
        }

        public void Aceptar(IVisitor visitor)
        {
            visitor.Visitar(this); // Doble Dispatch
        }

        public override string ToString()
        {
            string proteccion = ResistenteAlVeneno ? " [Sellado Anticorrosivo]" : "";
            return $"{Nombre} | Defensa: {Defensa} | Precio: {Precio} cr.{proteccion}";
        }
    }
}
