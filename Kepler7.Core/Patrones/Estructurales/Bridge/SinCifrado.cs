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
