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

        private string TipoElegido()
        {
            return cmbTipoMensaje.SelectedItem.ToString();
        }

        private Mensaje CrearMensaje()
        {
            ICifrado cifrado = ObtenerCifradoSeleccionado();
            string tipo = TipoElegido();
            if (tipo == "Texto Estándar") return new MensajeTexto(cifrado, txtMensaje.Text);
            if (tipo == "Alerta") return new MensajeAlerta(cifrado, txtMensaje.Text);
            return new MensajeEmergencia(cifrado, txtMensaje.Text);
        }

        private string TextoEfecto(string tipo, string cifrado)
        {
            if (tipo != "Emergencia")
            {
                return "Sin prioridad: no cuenta como pedido de refuerzos (sin escudo y K-7 suma +3 de ataque).";
            }
            if (cifrado == "AES")
            {
                return "AES: +10 de escudo inicial en el combate final. Cuesta " + Campana.PrecioAES + " monedas.";
            }
            if (cifrado == "Cuántico")
            {
                return "Cuántico: +20 de escudo inicial en el combate final. Cuesta " + Campana.PrecioCuantico + " monedas.";
            }
            return "Sin cifrado: K-7 intercepta el mensaje y suma +3 de ataque. No cuesta monedas.";
        }

        private bool HayTexto()
        {
            if (string.IsNullOrWhiteSpace(txtMensaje.Text))
            {
                MessageBox.Show("Ingresá un texto para enviar.");
                return false;
            }
            return true;
        }

        private void btnProbar_Click(object sender, EventArgs e)
        {
            if (!HayTexto()) return;

            mensajeActual = CrearMensaje();
            ActualizarPantalla();
            lblEfecto.Text = "Prueba (" + TipoElegido() + " + " + CifradoElegido() + "): " + TextoEfecto(TipoElegido(), CifradoElegido());
            navegador.ServicioLogros.RegistrarUsoPatron("Bridge");
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (!HayTexto()) return;

            string tipo = TipoElegido();
            string cifrado = CifradoElegido();
            int precio = Campana.PrecioCifrado(cifrado);
            string pregunta = "¿Enviar el pedido definitivo como " + tipo + " con " + cifrado + "? Cuesta " + precio + " monedas.";
            if (tipo != "Emergencia")
            {
                pregunta += "\n\nAtención: el pedido no es de Emergencia, así que no tendrá prioridad (sin bonus de escudo).";
            }
            if (MessageBox.Show(pregunta, "Enviar definitivo", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }

            // El cifrado se paga al enviar
            if (!navegador.Progreso.GastarMonedas(precio))
            {
                MessageBox.Show("No te alcanzan las monedas para ese cifrado.");
                return;
            }
            navegador.Progreso.Guardar();

            mensajeActual = CrearMensaje();
            ActualizarPantalla();
            navegador.ServicioLogros.RegistrarUsoPatron("Bridge");

            // Se manda un solo pedido de refuerzos
            navegador.Campana.CifradoMensaje = cifrado;
            navegador.Campana.MensajeEnviado = tipo == "Emergencia";
            lblEfecto.Text = "Enviado (" + tipo + " + " + cifrado + "): " + TextoEfecto(tipo, cifrado);
            BloquearDespuesDeEnviar();
            MostrarSaldo();
        }

        private void BloquearDespuesDeEnviar()
        {
            btnEnviar.Enabled = false;
            btnProbar.Enabled = false;
            cmbCifrado.Enabled = false;
            cmbTipoMensaje.Enabled = false;
            txtMensaje.ReadOnly = true;
            btnContinuar.Enabled = true;
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
