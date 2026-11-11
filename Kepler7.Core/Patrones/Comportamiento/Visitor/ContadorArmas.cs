namespace Kepler7.Core.Patrones.Comportamiento.Visitor
{
    // Visitante 2: Cuenta y clasifica exclusivamente las armas del inventario
    public class ContadorArmas : IVisitor
    {
        public int CantidadArmas { get; private set; }
        public int DanioTotal { get; private set; }
        private List<string> _detalleArmas = new List<string>();

        public void Visitar(Arma arma)
        {
            CantidadArmas++;
            DanioTotal += arma.Danio;
            _detalleArmas.Add($"- {arma.Nombre} (Daño: {arma.Danio}, Precio: {arma.Precio} cr.)");
        }

        public void Visitar(Pocion pocion)
        {
            // Las pociones se ignoran en el recuento de armas
        }

        public void Visitar(Armadura armadura)
        {
            // Las armaduras se ignoran en el recuento de armas
        }

        public string ObtenerResultado()
        {
            string detalle = _detalleArmas.Count > 0 ? string.Join(Environment.NewLine, _detalleArmas) : "(No se encontraron armas)";

            return "RECUENTO Y ANÁLISIS DE ARMAS" + Environment.NewLine +
                   $"Total de armas encontradas: {CantidadArmas}" + Environment.NewLine +
                   $"Daño de ataque acumulado: {DanioTotal} pts" + Environment.NewLine +
                   Environment.NewLine +
                   "Detalle del arsenal:" + Environment.NewLine +
                   detalle;
        }
    }
}
