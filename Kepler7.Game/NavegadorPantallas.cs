using Kepler7.Core.Modelo;
using Kepler7.Game.Pantallas;

namespace Kepler7.Game
{
    // Cambia la pantalla (UserControl) que se ve dentro del formulario principal
    public class NavegadorPantallas
    {
        private Control contenedor;

        // Partida actual: todas las pantallas comparten estos datos
        public Partida Partida { get; private set; }

        // Misión actual (por ahora hay una sola)
        public Mision Mision { get; private set; }

        public NavegadorPantallas(Control contenedor)
        {
            this.contenedor = contenedor;
            Partida = new Partida();
            Mision = new Mision();
        }

        // Saca la pantalla actual y pone la nueva ocupando todo el espacio
        private void Mostrar(UserControl pantalla)
        {
            contenedor.Controls.Clear();
            pantalla.Dock = DockStyle.Fill;
            contenedor.Controls.Add(pantalla);
        }

        public void IrAInicio()
        {
            Mostrar(new PantallaInicio(this));
        }

        public void IrATutorial()
        {
            Mostrar(new PantallaTutorial(this));
        }

        public void IrAHub()
        {
            Mostrar(new PantallaHub(this));
        }

        public void IrAMision()
        {
            Mostrar(new PantallaMision(this));
        }

        public void IrAFinal()
        {
            Mostrar(new PantallaFinal(this));
        }

        public void IrAFlyweight()
        {
            Mostrar(new PantallaFlyweight(this));
        }

        public void IrAProxy()
        {
            Mostrar(new PantallaProxy(this));
        }

        public void IrAVisitor()
        {
            Mostrar(new PantallaVisitor(this));
        }

        public void IrACombate()
        {
            Mostrar(new PantallaCombate(this));
        }

        public void IrALaboratorio()
        {
            Mostrar(new PanelLaboratorio(this));
        }

        public void IrAControlCentral()
        {
            Mostrar(new PantallaControlCentral(this));
        }

        public void IrAHangar()
        {
            Mostrar(new PantallaHangar(this));
        }

        // Guarda el resultado del combate en la partida y muestra victoria o derrota
        public void TerminarCombate(bool gano, int danio, int comandos)
        {
            Partida.DanioTotal += danio;
            Partida.ComandosUsados += comandos;
            if (gano)
            {
                Partida.MisionesGanadas++;
                IrAVictoria();
            }
            else
            {
                Partida.MisionesPerdidas++;
                IrADerrota();
            }
        }

        public void IrAVictoria()
        {
            Mostrar(new PantallaVictoria(this, Mision));
        }

        public void IrADerrota()
        {
            Mostrar(new PantallaDerrota(this));
        }
    }
}
