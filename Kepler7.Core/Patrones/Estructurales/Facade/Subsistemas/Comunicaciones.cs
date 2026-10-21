namespace Kepler7.Core.Patrones.Estructurales.Facade.Subsistemas
{
    // Subsistema de comunicaciones con la base
    internal class Comunicaciones
    {
        public string AbrirCanal()
        {
            return "Comunicaciones: canal con la base abierto";
        }

        public string EnviarAlerta()
        {
            return "Comunicaciones: alerta de emergencia enviada";
        }

        public string Cerrar()
        {
            return "Comunicaciones: canal cerrado";
        }
    }
}
