using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepler7.Core.Patrones.Estructurales.Bridge
{
    public class SinCifrado : ICifrado
    {
        public string Cifrar(string contenido)
        {
            return contenido;
        }
    }
}
