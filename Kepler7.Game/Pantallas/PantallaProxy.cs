using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System;
using System.Windows.Forms;
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
            this.navegador = navegador;
            _bovedaProxy = new BovedaProxy();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            navegador.IrAHub();
        }

        private void PantallaProxy_Load(object sender, EventArgs e)
        {
            if (cmbRol.Items.Count == 0)
            {
                cmbRol.Items.Add("Capitán");
                cmbRol.Items.Add("Oficial de Seguridad");
                cmbRol.Items.Add("Ingeniero");
                cmbRol.Items.Add("Tripulante");
                cmbRol.SelectedIndex = 0;
            }
            ActualizarListaLogs();
        }


        private void ActualizarListaLogs()
        {
            lstLogs.Items.Clear();
            foreach (var log in RegistroAcceso.HistorialLogs)
            {
                lstLogs.Items.Add(log.ToString());
            }
        }

        private void btnAcceder_Click_1(object sender, EventArgs e)
        {
            string usuario = string.IsNullOrWhiteSpace(txtUsuario.Text) ? "Desconocido" : txtUsuario.Text;
            string rol = cmbRol.SelectedItem?.ToString() ?? "Tripulante";

            try
            {
                // El cliente siempre interactúa a través de la interfaz / Proxy
                string contenidoBoveda = _bovedaProxy.ObtenerDatosSensibles(usuario, rol);
                txtResultado.Text = "=== ACCESO AUTORIZADO ===\r\n" + contenidoBoveda;
            }
            catch (UnauthorizedAccessException ex)
            {
                txtResultado.Text = "=== RECHAZADO ===\r\n" + ex.Message;
            }
            finally
            {
                ActualizarListaLogs();
            }
        }


    }
}