using System;
using System.Drawing;
using System.Windows.Forms;
using Kepler7.Core.Progreso;

namespace Kepler7.Game.Pantallas
{
    // Pantalla que muestra los 12 logros de patrones de diseño (desbloqueados en color y bloqueados en gris)
    public partial class PantallaLogros : UserControl
    {
        private NavegadorPantallas navegador;
        private ServicioLogros servicioLogros;

        public PantallaLogros(NavegadorPantallas navegador)
        {
            InitializeComponent();
            this.navegador = navegador;
            this.servicioLogros = navegador.ServicioLogros;

            CargarComboPatrones();
            MostrarLogros();
        }

        private void CargarComboPatrones()
        {
            cmbPatron.Items.Clear();
            foreach (Logro logro in servicioLogros.Logros)
            {
                cmbPatron.Items.Add(logro.Patron);
            }

            if (cmbPatron.Items.Count > 0)
            {
                cmbPatron.SelectedIndex = 0;
            }
        }

        // Dibuja la lista de logros con los desbloqueados en color y los bloqueados en gris
        private void MostrarLogros()
        {
            pnlLogros.Controls.Clear();
            int posicionY = 10;
            int cantidadDesbloqueados = 0;

            foreach (Logro logro in servicioLogros.Logros)
            {
                Label lblLogro = new Label();
                lblLogro.AutoSize = true;
                lblLogro.Location = new Point(12, posicionY);

                if (logro.Desbloqueado)
                {
                    lblLogro.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                    lblLogro.ForeColor = Color.Green;
                    lblLogro.Text = "[DESBLOQUEADO] " + logro.Nombre + " (" + logro.Patron + ") - " + logro.Descripcion;
                    cantidadDesbloqueados++;
                }
                else
                {
                    lblLogro.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                    lblLogro.ForeColor = Color.Gray;
                    lblLogro.Text = "[BLOQUEADO] " + logro.Nombre + " (" + logro.Patron + ") - " + logro.Descripcion;
                }

                pnlLogros.Controls.Add(lblLogro);
                posicionY += 29;
            }

            lblContador.Text = "Logros desbloqueados: " + cantidadDesbloqueados + " / " + servicioLogros.Logros.Count;
        }

        private void btnDesbloquear_Click(object sender, EventArgs e)
        {
            if (cmbPatron.SelectedItem != null)
            {
                string patron = cmbPatron.SelectedItem.ToString();
                servicioLogros.RegistrarUsoPatron(patron);
                MostrarLogros();
            }
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            servicioLogros.Reiniciar();
            MostrarLogros();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            navegador.IrAHub();
        }
    }
}
