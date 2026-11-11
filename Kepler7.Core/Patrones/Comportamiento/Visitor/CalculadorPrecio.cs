namespace Kepler7.Core.Patrones.Comportamiento.Visitor
{
    // Visitante 1: Calcula el valor total en créditos sumando cada ítem
    public class CalculadorPrecio : IVisitor
    {
        public double PrecioTotal { get; private set; }
        public double TotalArmas { get; private set; }
        public double TotalPociones { get; private set; }
        public double TotalArmaduras { get; private set; }

        public void Visitar(Arma arma)
        {
            PrecioTotal += arma.Precio;
            TotalArmas += arma.Precio;
        }

        public void Visitar(Pocion pocion)
        {
            PrecioTotal += pocion.Precio;
            TotalPociones += pocion.Precio;
        }

        public void Visitar(Armadura armadura)
        {
            PrecioTotal += armadura.Precio;
            TotalArmaduras += armadura.Precio;
        }

        public string ObtenerResultado()
        {
            return "CÁLCULO DE VALOR TOTAL DEL INVENTARIO" + Environment.NewLine +
                   $"- Valor en Armas: {TotalArmas:N2} créditos" + Environment.NewLine +
                   $"- Valor en Pociones: {TotalPociones:N2} créditos" + Environment.NewLine +
                   $"- Valor en Armaduras: {TotalArmaduras:N2} créditos" + Environment.NewLine +
                   "--------------------------------------------" + Environment.NewLine +
                   $"VALOR TOTAL DEL INVENTARIO: {PrecioTotal:N2} créditos";
        }
    }
}
