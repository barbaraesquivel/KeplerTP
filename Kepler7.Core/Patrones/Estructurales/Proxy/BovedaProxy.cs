using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepler7.Core.Patrones.Estructurales.Proxy
{
    public class BovedaProxy : IBoveda
    {
        private BovedaReal _bovedaReal;

        public string ObtenerDatosSensibles(string usuario, string rol)
        {
            // Normalizamos el rol a mayúsculas para evitar problemas de tipeo
            string rolLimpio = rol?.Trim().ToUpper() ?? "";

            // Validación de roles permitidos: Capitán u Oficial de Seguridad
            if (rolLimpio == "CAPITAN" || rolLimpio == "CAPITÁN" || rolLimpio == "OFICIAL DE SEGURIDAD")
            {
                // Lazy Initialization (creamos el objeto real solo si se necesita)
                if (_bovedaReal == null)
                {
                    _bovedaReal = new BovedaReal();
                }

                // Registrar acceso permitido
                RegistroAcceso.Registrar(usuario, rol, true, "Acceso concedido a la bóveda de datos.");

                // Delegar al objeto real
                return _bovedaReal.ObtenerDatosSensibles(usuario, rol);
            }
            else
            {
                // Registrar acceso denegado de forma PERSISTENTE
                RegistroAcceso.Registrar(usuario, rol, false, "INTENTO NO AUTORIZADO A LA BÓVEDA.");

                // Lanzar excepción o devolver mensaje de rechazo
                throw new UnauthorizedAccessException($"[ALERTA DE SEGURIDAD] El rol '{rol}' del usuario '{usuario}' no tiene permisos para acceder a la Bóveda.");
            }
        }
    }
}