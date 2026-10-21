using Kepler7.Core.Modelo;

namespace Kepler7.Core.Patrones.Comportamiento.Command
{
    // Le aplica daño a una unidad y recuerda la vida que tenía
    public class AtacarComando : IComando
    {
        private Unidad objetivo;
        private int danio;
        private int vidaPrevia;

        public string Descripcion { get; }

        public AtacarComando(Unidad objetivo, int danio)
        {
            this.objetivo = objetivo;
            this.danio = danio;
            Descripcion = "Atacar a " + objetivo.Nombre + " (" + danio + " de daño)";
        }

        public void Ejecutar()
        {
            vidaPrevia = objetivo.Vida;
            objetivo.Vida = objetivo.Vida - danio;
            if (objetivo.Vida < 0)
            {
                objetivo.Vida = 0;
            }
        }

        public void Deshacer()
        {
            objetivo.Vida = vidaPrevia;
        }
    }
}
