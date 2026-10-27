using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepler7.Core.Patrones.Estructurales.Bridge
{
    public abstract class Mensaje
    {
        protected ICifrado mecanismoCifrado;
        public string contenido { get; set; }

        public Mensaje(ICifrado cifrado, string contenido)
        {
            this.mecanismoCifrado = cifrado;
            this.contenido = contenido;
        }
        public abstract string Enviar();

    }
}
