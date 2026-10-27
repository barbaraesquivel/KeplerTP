using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepler7.Core.Patrones.Estructurales.Bridge
{
    public class MensajeAlerta : Mensaje
    {
        public MensajeAlerta(ICifrado cifrado, string contenido) : base(cifrado, contenido) { }

        public override string Enviar()
        {
            string textoCifrado = mecanismoCifrado.Cifrar(contenido);
            return $"[ALERTA] Prioridad media: {textoCifrado}";
        }
    }
}
