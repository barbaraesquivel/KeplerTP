namespace Kepler7.Core.Modelo
{
    // Base del jugador: tiene recursos y las estructuras construidas
    public class Base
    {
        public int Recursos { get; set; }
        public List<string> Estructuras { get; } = new List<string>();
    }
}
