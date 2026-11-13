using Kepler7.Core.Modelo;
using Kepler7.Core.Patrones.Estructurales.Bridge;

namespace Kepler7.Game.Pantallas
{
    // Capítulo Comunicaciones (patrón Bridge): pedido de refuerzos cifrado
    public partial class PantallaComunicaciones : UserControl
    {
        private NavegadorPantallas navegador;
        private Mensaje mensajeActual;

        public PantallaComunicaciones(NavegadorPantallas navegador)
        {
            InitializeComponent();
            Tema.Preparar(this);
            this.navegador = navegador;
            lblHistoria.Text = Historia.TextoCapitulo(Capitulo.Comunicaciones);
            ConfigurarListas();
            txtMensaje.Text = "Kepler-7 pide refuerzos urgentes. K-7 tomó el control de la estación.";
            MostrarSaldo();
        }

        private void ConfigurarListas()
        {
            cmbTipoMensaje.Items.Add("Texto Estándar");
            cmbTipoMensaje.Items.Add("Alerta");
            cmbTipoMensaje.Items.Add("Emergencia");
            // El pedido de refuerzos tiene que ser de tipo Emergencia
            cmbTipoMensaje.SelectedIndex = 2;
            cmbTipoMensaje.Enabled = false;

            cmbCifrado.Items.Add("Sin Cifrado");
            cmbCifrado.Items.Add("AES-256");
            cmbCifrado.Items.Add("Cuántico");
            cmbCifrado.SelectedIndex = 0;
        }

        // Nombre del cifrado como lo guarda la campaña
        private string CifradoElegido()
        {
            string seleccion = cmbCifrado.SelectedItem.ToString();
            if (seleccion == "AES-256") return "AES";
            if (seleccion == "Cuántico") return "Cuántico";
            return "Sin cifrado";
        }

        // Muestra las monedas y si alcanzan para el cifrado elegido
        private void MostrarSaldo()
        {
            if (cmbCifrado.SelectedItem == null) return;

            int monedas = navegador.Progreso.Monedas;
            int precio = Campana.PrecioCifrado(CifradoElegido());
            string texto = "Monedas: " + monedas + "  |  AES cuesta " + Campana.PrecioAES + ", Cuántico " + Campana.PrecioCuantico + "\n";
            if (precio <= monedas)
            {
                texto += "El cifrado elegido cuesta " + precio + ": te alcanza.";
                lblSaldo.ForeColor = Tema.Exito;
            }
            else
            {
                texto += "El cifrado elegido cuesta " + precio + ": NO te alcanza.";
                lblSaldo.ForeColor = Tema.Peligro;
            }
            lblSaldo.Text = texto;
        }

        private void cmbCifrado_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarSaldo();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMensaje.Text))
            {
                MessageBox.Show("Ingresá un texto para enviar.");
                return;
            }

            // El cifrado se paga al enviar
            string cifrado = CifradoElegido();
            if (!navegador.Progreso.GastarMonedas(Campana.PrecioCifrado(cifrado)))
            {
                MessageBox.Show("No te alcanzan las monedas para ese cifrado.");
                return;
            }
            navegador.Progreso.Guardar();

            mensajeActual = new MensajeEmergencia(ObtenerCifradoSeleccionado(), txtMensaje.Text);
            ActualizarPantalla();

            // Se manda un solo pedido de refuerzos
            navegador.Campana.CifradoMensaje = cifrado;
            navegador.Campana.MensajeEnviado = true;
            btnEnviar.Enabled = false;
            cmbCifrado.Enabled = false;
            txtMensaje.ReadOnly = true;
            btnContinuar.Enabled = true;
            MostrarSaldo();
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

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            navegador.TerminarCapitulo(Capitulo.Comunicaciones);
        }
    }
}
