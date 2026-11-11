namespace Kepler7.Core.Progreso
{
    // Progreso del jugador: experiencia, nivel y monedas
    public interface IProgreso
    {
        int Xp { get; }
        int Nivel { get; }
        int Monedas { get; }

        void GanarXp(int cantidad);
        void GanarMonedas(int cantidad);
    }
}
