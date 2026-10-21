using Kepler7.Core.Modelo;

namespace Kepler7.Core.Patrones.Comportamiento.Command
{
    // Gasta recursos de la base para construir una estructura
    public class ConstruirComando : IComando
    {
        private Base baseJugador;
        private string estructura;
        private int costo;
        private bool construido;

        public string Descripcion { get; }

        public ConstruirComando(Base baseJugador, string estructura, int costo)
        {
            this.baseJugador = baseJugador;
            this.estructura = estructura;
            this.costo = costo;
            Descripcion = "Construir " + estructura + " (cuesta " + costo + ")";
        }

        public void Ejecutar()
        {
            // Solo construye si alcanzan los recursos
            construido = baseJugador.Recursos >= costo;
            if (construido)
            {
                baseJugador.Recursos = baseJugador.Recursos - costo;
                baseJugador.Estructuras.Add(estructura);
            }
        }

        public void Deshacer()
        {
            // Si se había construido, devolvemos los recursos y sacamos la estructura
            if (construido)
            {
                baseJugador.Recursos = baseJugador.Recursos + costo;
                baseJugador.Estructuras.Remove(estructura);
                construido = false;
            }
        }
    }
}
