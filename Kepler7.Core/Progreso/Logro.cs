namespace Kepler7.Core.Progreso
{
    // Representa un logro asociado a un patrón de diseño del juego
    public class Logro
    {
        public string Patron { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Desbloqueado { get; set; }

        public Logro()
        {
        }

        public Logro(string patron, string nombre, string descripcion)
        {
            Patron = patron;
            Nombre = nombre;
            Descripcion = descripcion;
            Desbloqueado = false;
        }
    }
}
