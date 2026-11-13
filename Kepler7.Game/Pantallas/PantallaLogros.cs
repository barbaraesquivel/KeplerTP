using Kepler7.Core.Progreso;

namespace Kepler7.Game.Pantallas
{
    // Pantalla de solo lectura que muestra los 12 logros de patrones de diseño (desbloqueados en color y bloqueados en gris)
    public partial class PantallaLogros : UserControl
    {
        private NavegadorPantallas navegador;
        private ServicioLogros servicioLogros;

        public PantallaLogros(NavegadorPantallas navegador)
        {
            InitializeComponent();
            Tema.Preparar(this);
            this.navegador = navegador;
            this.servicioLogros = navegador.ServicioLogros;

            MostrarLogros();
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
                    lblLogro.ForeColor = Tema.Exito;
                    lblLogro.Text = "[DESBLOQUEADO] " + logro.Nombre + " (" + logro.Patron + ") - " + logro.Descripcion;
                    cantidadDesbloqueados++;
                }
                else
                {
                    lblLogro.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                    lblLogro.ForeColor = Color.DarkGray;
                    lblLogro.Text = "[BLOQUEADO] " + logro.Nombre + " (" + logro.Patron + ") - " + logro.Descripcion;
                }

                pnlLogros.Controls.Add(lblLogro);
                posicionY += 29;
            }

            lblContador.Text = "Logros desbloqueados: " + cantidadDesbloqueados + " / " + servicioLogros.Logros.Count;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            navegador.IrADiario();
        }
    }
}
