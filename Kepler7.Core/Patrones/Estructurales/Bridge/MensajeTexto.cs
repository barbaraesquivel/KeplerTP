namespace Kepler7.Core.Patrones.Estructurales.Bridge
{
    public class MensajeTexto : Mensaje
    {
        public MensajeTexto(ICifrado cifrado, string contenido) : base(cifrado, contenido) { }

        public override string Enviar()
        {
            string textoCifrado = mecanismoCifrado.Cifrar(contenido);
            return $"[TEXTO ESTANDAR] Transmitiendo a la Tierra: {textoCifrado}";
        }
    }
}
