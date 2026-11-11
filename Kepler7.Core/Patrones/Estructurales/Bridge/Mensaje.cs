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

        public void CambiarCifrado(ICifrado nuevoCifrado)
        {
            this.mecanismoCifrado = nuevoCifrado;
        }

        public abstract string Enviar();

    }
}
