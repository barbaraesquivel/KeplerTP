using Kepler7.Core.Patrones.Estructurales.Facade.Subsistemas;

namespace Kepler7.Core.Patrones.Estructurales.Facade
{
    // Fachada: el formulario solo habla con ControlCentral,
    // y ControlCentral coordina los 6 subsistemas (que son internal)
    public class ControlCentral
    {
        private Energia energia = new Energia();
        private SoporteVital soporteVital = new SoporteVital();
        private Navegacion navegacion = new Navegacion();
        private Comunicaciones comunicaciones = new Comunicaciones();
        private Seguridad seguridad = new Seguridad();
        private Defensa defensa = new Defensa();

        private List<string> secuencia = new List<string>();

        public EstadoEstacion Estado { get; private set; } = EstadoEstacion.Apagada;

        // Pasos que hizo la última operación, en orden, para mostrar en la UI
        public IReadOnlyList<string> Secuencia
        {
            get { return secuencia; }
        }

        public int NivelEnergia
        {
            get { return energia.Nivel; }
        }

        // Arranca un turno normal: gasta un poco de energía
        public void IniciarTurno()
        {
            secuencia.Clear();
            secuencia.Add(energia.Encender());
            secuencia.Add(energia.Consumir(10));
            secuencia.Add(soporteVital.Estabilizar());
            secuencia.Add(navegacion.Calibrar());
            secuencia.Add(comunicaciones.AbrirCanal());
            secuencia.Add(seguridad.RevisarSectores());
            Estado = EstadoEstacion.Normal;
        }

        // Emergencia: activa las defensas y gasta más energía
        public void EntrarEnEmergencia()
        {
            secuencia.Clear();
            secuencia.Add(seguridad.ActivarAlarma());
            secuencia.Add(defensa.Activar());
            secuencia.Add(energia.Consumir(25));
            secuencia.Add(soporteVital.ModoReserva());
            secuencia.Add(comunicaciones.EnviarAlerta());
            Estado = EstadoEstacion.Emergencia;
        }

        // Apaga todo y deja la estación inactiva
        public void ApagarEstacion()
        {
            secuencia.Clear();
            secuencia.Add(defensa.Desactivar());
            secuencia.Add(comunicaciones.Cerrar());
            secuencia.Add(navegacion.Detener());
            secuencia.Add(seguridad.Bloquear());
            secuencia.Add(soporteVital.Apagar());
            secuencia.Add(energia.Apagar());
            Estado = EstadoEstacion.Apagada;
        }
    }
}
