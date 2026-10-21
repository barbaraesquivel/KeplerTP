namespace Kepler7.Core.Patrones.Creacionales.Builder
{
    // Concrete Builder ("receta"): nave rápida que consigue más recursos en la misión
    public class RecetaExploradora : INaveBuilder
    {
        private Nave nave;

        public RecetaExploradora()
        {
            Reiniciar();
        }

        public void Reiniciar()
        {
            nave = new Nave();
            nave.Tipo = "Exploradora";
        }

        public void ConstruirCasco()
        {
            nave.Casco = "Casco ligero";
            nave.Defensa += 5;
        }

        public void ConstruirMotor()
        {
            nave.Motor = "Motor iónico";
            nave.Velocidad += 30;
        }

        public void ConstruirEscudo()
        {
            nave.Escudo = "Escudo básico";
            nave.Defensa += 10;
        }

        public void ConstruirArmas()
        {
            nave.Armas = "Láser ligero";
            nave.Ataque += 5;
        }

        public void ConstruirRadar()
        {
            nave.Radar = "Radar de largo alcance";
            nave.BonusRecursos += 30;
        }

        public void ConstruirIA()
        {
            nave.IA = "IA de exploración";
            nave.BonusRecursos += 10;
        }

        public void ConstruirCombustible()
        {
            nave.Combustible = "Tanques extra";
            nave.Autonomia += 50;
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
