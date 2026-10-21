namespace Kepler7.Core.Patrones.Estructurales.Facade.Subsistemas
{
    // Subsistema que mantiene el oxígeno y la temperatura
    internal class SoporteVital
    {
        public string Estabilizar()
        {
            return "Soporte vital: oxígeno y temperatura estables";
        }

        public string ModoReserva()
        {
            return "Soporte vital: modo reserva activado";
        }

        public string Apagar()
        {
            return "Soporte vital: sistemas en reposo";
        }
    }
}
