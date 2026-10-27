using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepler7.Core.Patrones.Estructurales.Bridge
{
    public class MensajeEmergencia : Mensaje
    {
        public MensajeEmergencia(ICifrado cifrado, string contenido) : base(cifrado, contenido) { }

        public override string Enviar()
        {
            string textoCifrado = mecanismoCifrado.Cifrar(contenido);
            return $"[EMERGENCIA ROJA] ¡Peligro crítico en Kepler-7!: {textoCifrado}";
        }
    }
}
