namespace Kepler7.Core.Patrones.Creacionales.Builder
{
    // Director: decide el orden de los pasos, sin saber qué receta usa
    public class IngenieroJefe
    {
        private INaveBuilder builder;

        public IngenieroJefe(INaveBuilder builder)
        {
            this.builder = builder;
        }

        // Permite usar el mismo director con otra receta
        public void CambiarBuilder(INaveBuilder builder)
        {
            this.builder = builder;
        }

        // Nave con todos los componentes
        public Nave ConstruirNaveCompleta()
        {
            builder.Reiniciar();
            builder.ConstruirCasco();
            builder.ConstruirMotor();
            builder.ConstruirEscudo();
            builder.ConstruirArmas();
            builder.ConstruirRadar();
            builder.ConstruirIA();
            builder.ConstruirCombustible();
            return builder.ObtenerNave();
        }

        // Nave solo con lo mínimo para volar
        public Nave ConstruirNaveBasica()
        {
            builder.Reiniciar();
            builder.ConstruirCasco();
            builder.ConstruirMotor();
            builder.ConstruirCombustible();
            return builder.ObtenerNave();
        }
    }
}
