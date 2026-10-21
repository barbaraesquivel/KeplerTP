namespace Kepler7.Game
{
    internal static class Program
    {
        // Punto de entrada de la aplicación
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FormPrincipal());
        }
    }
}
