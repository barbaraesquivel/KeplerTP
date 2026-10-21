namespace Kepler7.Core.Patrones.Creacionales.Builder
{
    // Concrete Builder ("receta"): nave blindada que hace más daño en la misión
    public class RecetaCombate : INaveBuilder
    {
        private Nave nave;

        public RecetaCombate()
        {
            Reiniciar();
        }

        public void Reiniciar()
        {
            nave = new Nave();
            nave.Tipo = "Combate";
        }

        public void ConstruirCasco()
        {
            nave.Casco = "Casco blindado";
            nave.Defensa += 25;
        }

        public void ConstruirMotor()
        {
            nave.Motor = "Motor de combate";
            nave.Velocidad += 15;
        }

        public void ConstruirEscudo()
        {
            nave.Escudo = "Escudo pesado";
            nave.Defensa += 30;
        }

        public void ConstruirArmas()
        {
            nave.Armas = "Cañones de plasma";
            nave.Ataque += 40;
        }

        public void ConstruirRadar()
        {
            nave.Radar = "Radar táctico";
            nave.Ataque += 5;
        }

        public void ConstruirIA()
        {
            nave.IA = "IA de combate";
            nave.Ataque += 10;
        }

        public void ConstruirCombustible()
        {
            nave.Combustible = "Tanque estándar";
            nave.Autonomia += 20;
        }

        // Devuelve la nave terminada y deja la receta lista para otra
        public Nave ObtenerNave()
        {
            Nave resultado = nave;
            Reiniciar();
            return resultado;
        }
    }
}
