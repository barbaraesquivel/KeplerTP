namespace Kepler7.Core.Patrones.Estructurales.Proxy
{
    // Interfaz común para el Sujeto Real y el Proxy
    public interface IBoveda
    {
        string LeerArchivo(string nombreArchivo, string usuario = "Desconocido", string rol = "Tripulante");
        void EscribirArchivo(string nombreArchivo, string contenido, string usuario = "Desconocido", string rol = "Tripulante");
    }
}
