using Kepler7.Core.Modelo;
using Kepler7.Core.Patrones.Comportamiento.Chain;

namespace Kepler7.Game.Pantallas
{
    public partial class PanelCadenaDefensa : UserControl
    {
        private Personaje jugador;
        private Random random;
        private PantallaCombate pantalla;

        public PanelCadenaDefensa(Personaje jugador, Random random, PantallaCombate pantalla)
        {
            InitializeComponent();
            BackColor = Tema.FondoPanel;
            Tema.Aplicar(this);
            this.jugador = jugador;
            this.random = random;
            this.pantalla = pantalla;
            cmbTipo.Items.Add("Esquiva");
            cmbTipo.Items.Add("Bloqueo");
            cmbTipo.Items.Add("Armadura");
            cmbTipo.Items.Add("Escudo");
            cmbTipo.Items.Add("Vida");
            cmbTipo.SelectedIndex = 0;
            ActualizarLista();
        }

        public void ActualizarLista()
        {
            int seleccionado = lstEslabones.SelectedIndex;
            lstEslabones.Items.Clear();
            foreach (IManejadorDanio eslabon in jugador.Defensa.Eslabones)
            {
                lstEslabones.Items.Add(Describir(eslabon));
            }
            if (seleccionado < lstEslabones.Items.Count)
            {
                lstEslabones.SelectedIndex = seleccionado;
            }
        }

        private string Describir(IManejadorDanio eslabon)
        {
            if (eslabon is Esquiva esquiva)
            {
                return "Esquiva (" + esquiva.Probabilidad + "%)";
            }
            if (eslabon is Bloqueo bloqueo)
            {
                return "Bloqueo (" + bloqueo.Porcentaje + "%)";
            }
            if (eslabon is Armadura armadura)
            {
                return "Armadura (-" + armadura.Reduccion + ")";
            }
            if (eslabon is Escudo escudo)
            {
                return "Escudo (" + escudo.Puntos + " pts)";
            }
            return "Vida";
        }

        private IManejadorDanio CrearEslabon(string tipo)
        {
            if (tipo == "Esquiva")
            {
                return new Esquiva(20, random);
            }
            if (tipo == "Bloqueo")
            {
                return new Bloqueo(25);
            }
            if (tipo == "Armadura")
            {
                return new Armadura(3);
            }
            if (tipo == "Escudo")
            {
                return new Escudo(30);
            }
            return new Vida(jugador);
        }

        public void MostrarRecorrido(string atacante, ResultadoDanio resultado)
        {
            lstRecorrido.Items.Add("Ataque de " + atacante + ":");
            foreach (string paso in resultado.Recorrido)
            {
                lstRecorrido.Items.Add("   " + paso);
            }
            lstRecorrido.Items.Add("   Daño final a la vida: " + resultado.DanioFinal);
            lstRecorrido.TopIndex = lstRecorrido.Items.Count - 1;
            ActualizarLista();
        }

        private void CambioEnCadena(int nuevaSeleccion)
        {
            ActualizarLista();
            if (nuevaSeleccion >= 0 && nuevaSeleccion < lstEslabones.Items.Count)
            {
                lstEslabones.SelectedIndex = nuevaSeleccion;
            }
            pantalla.Actualizar();
        }

        // En el combate final la cadena se muestra pero no se puede editar
        public void SoloLectura()
        {
            btnSubir.Enabled = false;
            btnBajar.Enabled = false;
            btnQuitar.Enabled = false;
            btnAgregar.Enabled = false;
            cmbTipo.Enabled = false;
        }

        private void btnSubir_Click(object sender, EventArgs e)
        {
            int indice = lstEslabones.SelectedIndex;
            if (indice <= 0)
            {
                return;
            }
            jugador.Defensa.Mover(jugador.Defensa.Eslabones[indice], indice - 1);
            CambioEnCadena(indice - 1);
        }

        private void btnBajar_Click(object sender, EventArgs e)
        {
            int indice = lstEslabones.SelectedIndex;
            if (indice < 0 || indice >= lstEslabones.Items.Count - 1)
            {
                return;
            }
            jugador.Defensa.Mover(jugador.Defensa.Eslabones[indice], indice + 1);
            CambioEnCadena(indice + 1);
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            int indice = lstEslabones.SelectedIndex;
            if (indice < 0)
            {
                return;
            }
            jugador.Defensa.Quitar(jugador.Defensa.Eslabones[indice]);
            CambioEnCadena(indice - 1);
        }

        private bool YaEstaEnLaCadena(string tipo)
        {
            foreach (IManejadorDanio eslabon in jugador.Defensa.Eslabones)
            {
                if (eslabon.GetType().Name == tipo)
                {
                    return true;
                }
            }
            return false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string tipo = cmbTipo.SelectedItem.ToString();
            if (YaEstaEnLaCadena(tipo))
            {
                pantalla.MostrarMensaje(tipo + " ya está en la cadena");
                return;
            }
            IManejadorDanio nuevo = CrearEslabon(tipo);
            jugador.Defensa.Agregar(nuevo);
            jugador.Defensa.Mover(nuevo, 0);
            pantalla.MostrarMensaje(tipo + " agregado al principio de la cadena");
            CambioEnCadena(0);
        }
    }
}
