using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepler7.Core.Patrones.Estructurales.Proxy
{
    public class BovedaReal : IBoveda
    {
        public string ObtenerDatosSensibles(string usuario, string rol)
        {
            // Código que solo se ejecuta si pasó la validación del Proxy
            return "DATOS CONFIDENCIALES DE KEPLER-7:\n" +
                   "- Coordenadas de Salto: 84.122 / -12.904\n" +
                   "- Códigos de Autodestrucción: K7-9942-ALPHA\n" +
                   "- Manifiesto de Carga Secreta: Contenedor Criogénico #04";
        }
    }
}
