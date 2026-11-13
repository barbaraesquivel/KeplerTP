using Kepler7.Core.Patrones.Comportamiento.Strategy;

namespace Kepler7.Core.Modelo
{
    // K-7, el jefe final: un Personaje (cuerpo en el mapa) con un Enemigo (cerebro con Strategy)
    public class JefeK7
    {
        public const int VidaBase = 200;
        public const int AtaqueBase = 18;
        public const int TurnosHackeo = 2;

        public Personaje Cuerpo { get; private set; }
        public Enemigo Cerebro { get; private set; }

        // Si se defendió en su último turno, recibe la mitad de daño hasta su próximo turno
        public bool Defendiendo { get; set; }

        public bool HackUsado { get; private set; }
        public int TurnosHackeado { get; private set; }

        public JefeK7(int vidaExtra, int ataqueExtra, int x, int y)
        {
            Cuerpo = new Personaje("K-7", VidaBase + vidaExtra, AtaqueBase + ataqueExtra);
            Cuerpo.X = x;
            Cuerpo.Y = y;
            Cerebro = new Enemigo("K-7", Cuerpo.Vida, new IAAgresiva());
        }

        public string EstrategiaActual
        {
            get { return Cerebro.NombreEstrategiaActual; }
        }

        // Más de 66% de vida: Agresiva. Entre 33% y 66%: Calculadora. Menos de 33%: Defensiva.
        public IEstrategiaIA EstrategiaPorFase()
        {
            int porcentaje = Cuerpo.Vida * 100 / Cuerpo.VidaMax;
            if (porcentaje > 66)
            {
                return new IAAgresiva();
            }
            if (porcentaje >= 33)
            {
                return new IACalculadora();
            }
            return new IADefensiva();
        }

        // Pone la estrategia de la fase (salvo que esté hackeada). Devuelve un aviso si cambió.
        public string ActualizarFase()
        {
            if (TurnosHackeado > 0)
            {
                return "";
            }
            IEstrategiaIA nueva = EstrategiaPorFase();
            if (nueva.GetType().Name == EstrategiaActual)
            {
                return "";
            }
            Cerebro.SetEstrategia(nueva);
            return "K-7 cambia de estrategia: ahora usa " + EstrategiaActual + ". ";
        }

        // Una sola vez: K-7 pasa a IAAleatoria durante 2 turnos
        public bool Hackear()
        {
            if (HackUsado)
            {
                return false;
            }
            HackUsado = true;
            TurnosHackeado = TurnosHackeo;
            Cerebro.SetEstrategia(new IAAleatoria());
            return true;
        }

        public DecisionIA Decidir(int distancia, int saludJugador)
        {
            Cerebro.Salud = Cuerpo.Vida;
            Contexto contexto = new Contexto { DistanciaAlJugador = distancia, SaludDelJugador = saludJugador };
            return Cerebro.EjecutarAccion(contexto);
        }

        // Al terminar su turno se descuenta el hackeo
        public void FinDeTurno()
        {
            if (TurnosHackeado > 0)
            {
                TurnosHackeado--;
            }
        }
    }
}
