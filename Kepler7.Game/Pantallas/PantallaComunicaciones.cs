using Kepler7.Core.Patrones.Estructurales.Bridge;

namespace Kepler7.Game.Pantallas
{
    public partial class PantallaComunicaciones : UserControl
    {
        private NavegadorPantallas navegador;
        private Mensaje mensajeActual;

        public PantallaComunicaciones(NavegadorPantallas navegador)
        {
            InitializeComponent();
            Tema.Preparar(this);
            this.navegador = navegador;
            ConfigurarListas();
        }

        private void ConfigurarListas()
        {
            cmbTipoMensaje.Items.Add("Texto Estándar");
            cmbTipoMensaje.Items.Add("Alerta");
            cmbTipoMensaje.Items.Add("Emergencia");
            cmbTipoMensaje.SelectedIndex = 0;

            cmbCifrado.Items.Add("Sin Cifrado");
            cmbCifrado.Items.Add("AES-256");
            cmbCifrado.Items.Add("Cuántico");
            cmbCifrado.SelectedIndex = 0;
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMensaje.Text))
            {
                MessageBox.Show("Ingresá un texto para enviar.");
                return;
            }

            ICifrado cifradoSeleccionado = ObtenerCifradoSeleccionado();
            string texto = txtMensaje.Text;

            string tipo = cmbTipoMensaje.SelectedItem.ToString();
            if (tipo == "Texto Estándar")
                mensajeActual = new MensajeTexto(cifradoSeleccionado, texto);
            else if (tipo == "Alerta")
                mensajeActual = new MensajeAlerta(cifradoSeleccionado, texto);
            else if (tipo == "Emergencia")
                mensajeActual = new MensajeEmergencia(cifradoSeleccionado, texto);

            ActualizarPantalla();
        }

        private ICifrado ObtenerCifradoSeleccionado()
        {
            string seleccion = cmbCifrado.SelectedItem.ToString();
            if (seleccion == "AES-256") return new CifradoAES();
            if (seleccion == "Cuántico") return new CifradoCuantico();

            return new SinCifrado();
        }

        private void ActualizarPantalla()
        {
            txtMensajeOriginalMuestra.Text = mensajeActual.contenido;
            txtMensajeCifradoMuestra.Text = mensajeActual.Enviar();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            navegador.IrAHub();
        }
    }
}
