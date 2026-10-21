using Kepler7.Game.Pantallas;

namespace Kepler7.Game
{
    // Cambia la pantalla (UserControl) que se ve dentro del formulario principal
    public class NavegadorPantallas
    {
        private Control contenedor;

        public NavegadorPantallas(Control contenedor)
        {
            this.contenedor = contenedor;
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
    }
}
