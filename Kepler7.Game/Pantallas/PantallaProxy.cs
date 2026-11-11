using Kepler7.Core.Patrones.Estructurales.Proxy;

namespace Kepler7.Game.Pantallas
{
    public partial class PantallaProxy : UserControl
    {
        private IBoveda _bovedaProxy;
        private NavegadorPantallas navegador;

        public PantallaProxy(NavegadorPantallas navegador)
        {
            InitializeComponent();
            Tema.Preparar(this);
            this.navegador = navegador;
            _bovedaProxy = new ProxyBoveda();
        }

        private void PantallaProxy_Load(object sender, EventArgs e)
        {
            if (cmbRol.Items.Count > 0 && cmbRol.SelectedIndex < 0)
            {
                cmbRol.SelectedIndex = 0;
            }
            if (cmbArchivo.Items.Count > 0 && cmbArchivo.SelectedIndex < 0)
            {
                cmbArchivo.SelectedIndex = 0;
            }

            // Muestra la ruta real en %AppData%\Kepler7\
            lblRutaLog.Text = $"Registro persistente: {RegistroAcceso.RutaLog}";

            // Carga los registros persistentes desde el archivo al iniciar
            ActualizarListaLogs();
        }

        private void ActualizarListaLogs()
        {
            lstLogs.Items.Clear();
            foreach (var log in RegistroAcceso.HistorialLogs)
            {
                lstLogs.Items.Add(log);
            }
            if (lstLogs.Items.Count > 0)
            {
                lstLogs.TopIndex = lstLogs.Items.Count - 1;
            }
        }

        private void btnLeer_Click(object sender, EventArgs e)
        {
            string usuario = string.IsNullOrWhiteSpace(txtUsuario.Text) ? "Desconocido" : txtUsuario.Text.Trim();
            string rol = cmbRol.SelectedItem != null ? cmbRol.SelectedItem.ToString() : "Tripulante";
            string archivo = cmbArchivo.SelectedItem != null ? cmbArchivo.SelectedItem.ToString() : "coordenadas_salto.dat";

            try
            {
                // El cliente siempre interactúa a través de la interfaz IBoveda / ProxyBoveda
                string contenido = _bovedaProxy.LeerArchivo(archivo, usuario, rol);
                txtResultado.ForeColor = Tema.Exito;
                txtResultado.Text = $"[ACCESO AUTORIZADO]\r\nArchivo: {archivo}\r\nContenido: {contenido}";
            }
            catch (UnauthorizedAccessException ex)
            {
                txtResultado.ForeColor = Tema.Peligro;
                txtResultado.Text = $"[ACCESO RECHAZADO]\r\n{ex.Message}";
            }
            finally
            {
                navegador.ServicioLogros.RegistrarUsoPatron("Proxy");
                ActualizarListaLogs();
            }
        }

        private void btnEscribir_Click(object sender, EventArgs e)
        {
            string usuario = string.IsNullOrWhiteSpace(txtUsuario.Text) ? "Desconocido" : txtUsuario.Text.Trim();
            string rol = cmbRol.SelectedItem != null ? cmbRol.SelectedItem.ToString() : "Tripulante";
            string archivo = cmbArchivo.SelectedItem != null ? cmbArchivo.SelectedItem.ToString() : "coordenadas_salto.dat";
            string nuevoContenido = txtResultado.Text;

            try
            {
                _bovedaProxy.EscribirArchivo(archivo, nuevoContenido, usuario, rol);
                txtResultado.ForeColor = Tema.Acento;
                txtResultado.Text = $"[ESCRITURA EXITOSA]\r\nEl archivo '{archivo}' fue modificado en la bóveda por {usuario} ({rol}).";
            }
            catch (UnauthorizedAccessException ex)
            {
                txtResultado.ForeColor = Tema.Peligro;
                txtResultado.Text = $"[ESCRITURA RECHAZADA]\r\n{ex.Message}";
            }
            finally
            {
                navegador.ServicioLogros.RegistrarUsoPatron("Proxy");
                ActualizarListaLogs();
            }
        }

        private void btnRecargarLogs_Click(object sender, EventArgs e)
        {
            RegistroAcceso.CargarLogs();
            ActualizarListaLogs();
        }

        private void btnLimpiarLogs_Click(object sender, EventArgs e)
        {
            RegistroAcceso.LimpiarHistorial();
            ActualizarListaLogs();
            txtResultado.Text = "Registro de auditoría borrado.";
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            navegador.IrAHub();
        }
    }
}
