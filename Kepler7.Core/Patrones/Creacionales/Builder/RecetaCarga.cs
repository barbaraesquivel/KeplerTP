namespace Kepler7.Core.Patrones.Creacionales.Builder
{
    // Concrete Builder ("receta"): nave lenta que lleva más carga en la misión
    public class RecetaCarga : INaveBuilder
    {
        private Nave nave;

        public RecetaCarga()
        {
            Reiniciar();
        }

        public void Reiniciar()
        {
            nave = new Nave();
            nave.Tipo = "Carga";
        }

        public void ConstruirCasco()
        {
            nave.Casco = "Casco con bodega";
            nave.Defensa += 15;
            nave.Capacidad += 50;
        }

        public void ConstruirMotor()
        {
            nave.Motor = "Motor de carga";
            nave.Velocidad += 10;
        }

        public void ConstruirEscudo()
        {
            nave.Escudo = "Escudo medio";
            nave.Defensa += 15;
        }

        public void ConstruirArmas()
        {
            nave.Armas = "Torreta defensiva";
            nave.Ataque += 10;
        }

        public void ConstruirRadar()
        {
            nave.Radar = "Radar estándar";
            nave.BonusRecursos += 5;
        }

        public void ConstruirIA()
        {
            nave.IA = "IA logística";
            nave.Capacidad += 30;
        }

        public void ConstruirCombustible()
        {
            nave.Combustible = "Gran tanque";
            nave.Autonomia += 40;
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
