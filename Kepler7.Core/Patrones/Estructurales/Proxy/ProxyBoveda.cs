using System;

namespace Kepler7.Core.Patrones.Estructurales.Proxy
{
    // Proxy de Protección: controla el acceso según el rol del usuario y registra cada intento
    public class ProxyBoveda : IBoveda
    {
        private BovedaDatos _bovedaReal;

        private BovedaDatos ObtenerBovedaReal()
        {
            if (_bovedaReal == null)
            {
                _bovedaReal = new BovedaDatos();
            }
            return _bovedaReal;
        }

        // Verifica si el rol tiene privilegios de acceso a la bóveda
        private bool TieneAcceso(string rol)
        {
            if (rol == null) return false;
            string rolLimpio = rol.Trim().ToUpper();
            return rolLimpio == "CAPITAN" ||
                   rolLimpio == "CAPITÁN" ||
                   rolLimpio == "OFICIAL DE SEGURIDAD";
        }

        public string LeerArchivo(string nombreArchivo, string usuario = "Desconocido", string rol = "Tripulante")
        {
            if (TieneAcceso(rol))
            {
                // Registrar acceso permitido
                RegistroAcceso.Registrar(usuario, rol, $"Lectura de '{nombreArchivo}'", true);

                // Delegar al sujeto real
                return ObtenerBovedaReal().LeerArchivo(nombreArchivo, usuario, rol);
            }
            else
            {
                // Registrar intento no autorizado de forma persistente
                RegistroAcceso.Registrar(usuario, rol, $"Intento de lectura no autorizado: '{nombreArchivo}'", false);

                // Rechazar acceso
                throw new UnauthorizedAccessException($"[ACCESO DENEGADO] El rol '{rol}' del usuario '{usuario}' no tiene permisos para acceder a la bóveda.");
            }
        }

        public void EscribirArchivo(string nombreArchivo, string contenido, string usuario = "Desconocido", string rol = "Tripulante")
        {
            if (TieneAcceso(rol))
            {
                // Registrar acceso permitido
                RegistroAcceso.Registrar(usuario, rol, $"Escritura en '{nombreArchivo}'", true);

                // Delegar al sujeto real
                ObtenerBovedaReal().EscribirArchivo(nombreArchivo, contenido, usuario, rol);
            }
            else
            {
                // Registrar intento no autorizado de forma persistente
                RegistroAcceso.Registrar(usuario, rol, $"Intento de escritura no autorizado: '{nombreArchivo}'", false);

                // Rechazar acceso
                throw new UnauthorizedAccessException($"[ACCESO DENEGADO] El rol '{rol}' del usuario '{usuario}' no tiene permisos para modificar la bóveda.");
            }
        }
    }
}
