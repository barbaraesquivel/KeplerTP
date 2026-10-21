namespace Kepler7.Core.Patrones.Comportamiento.Command
{
    // Interfaz común de todos los comandos
    public interface IComando
    {
        string Descripcion { get; }
        void Ejecutar();
        void Deshacer();
    }
}
