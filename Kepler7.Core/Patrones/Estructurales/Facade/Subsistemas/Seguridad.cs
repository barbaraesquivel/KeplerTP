namespace Kepler7.Core.Patrones.Estructurales.Facade.Subsistemas
{
    // Subsistema de seguridad interna
    internal class Seguridad
    {
        public string RevisarSectores()
        {
            return "Seguridad: sectores revisados, sin novedades";
        }

        public string ActivarAlarma()
        {
            return "Seguridad: alarma activada y compuertas selladas";
        }

        public string Bloquear()
        {
            return "Seguridad: accesos bloqueados";
        }
    }
}
