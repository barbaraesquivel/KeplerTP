using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepler7.Core.Patrones.Estructurales.Proxy
{
    public interface IBoveda
    {
        string ObtenerDatosSensibles(string usuario, string rol);
    }
}