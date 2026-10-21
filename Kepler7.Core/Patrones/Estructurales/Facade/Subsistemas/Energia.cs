namespace Kepler7.Core.Patrones.Estructurales.Facade.Subsistemas
{
    // Subsistema de energía de la estación
    internal class Energia
    {
        public int Nivel { get; private set; } = 100;

        public string Encender()
        {
            return "Energía: reactor encendido (" + Nivel + "%)";
        }

        public string Consumir(int cantidad)
        {
            Nivel = Nivel - cantidad;
            if (Nivel < 0)
            {
                Nivel = 0;
            }
            return "Energía: se consumieron " + cantidad + " puntos (quedan " + Nivel + "%)";
        }

        public string Apagar()
        {
            return "Energía: reactor apagado";
        }
    }
}
