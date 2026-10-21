namespace Kepler7.Core.Patrones.Creacionales.Builder
{
    // Interfaz Builder: los pasos para armar una nave
    public interface INaveBuilder
    {
        void Reiniciar();
        void ConstruirCasco();
        void ConstruirMotor();
        void ConstruirEscudo();
        void ConstruirArmas();
        void ConstruirRadar();
        void ConstruirIA();
        void ConstruirCombustible();
        Nave ObtenerNave();
    }
}
