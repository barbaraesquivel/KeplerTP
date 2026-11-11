namespace Kepler7.Core.Patrones.Estructurales.Bridge
{
    public class CifradoAES : ICifrado
    {
        public string Cifrar(string contenido)
        {
            return $"[AES-256] {Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(contenido))}";
        }
    }
}
