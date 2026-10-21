namespace Kepler7.Core.Progreso
{
    // Progreso del jugador: experiencia y monedas (lo implementa Lautaro)
    public interface IProgreso
    {
        void GanarXp(int cantidad);
        void GanarMonedas(int cantidad);
    }
}
