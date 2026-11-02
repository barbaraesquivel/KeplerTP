using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Kepler7.Core.Patrones.Estructurales.Flyweight
{
    public static class EspecieFactory
    {
        private static readonly Dictionary<string, EspecieFlyweight> _especies = new Dictionary<string, EspecieFlyweight>();

        public static EspecieFlyweight ObtenerEspecie(string nombreEspecie, string planetaOrigen, string habilidadEspecial)
        {
            if (!_especies.ContainsKey(nombreEspecie))
            {
                _especies[nombreEspecie] = new EspecieFlyweight(nombreEspecie, planetaOrigen, habilidadEspecial);
            }
            return _especies[nombreEspecie];
        }

        public static int CantidadEspeciesEnMemoria => _especies.Count;
    }
}