using Kepler7.Core.Modelo;
using Kepler7.Core.Progreso;
using Kepler7.Game.Pantallas;

namespace Kepler7.Game
{
    // Cambia la pantalla (UserControl) que se ve dentro del formulario principal
    public class NavegadorPantallas
    {
        public const int XpPorCapitulo = 50;

        private Control contenedor;

        // Partida actual: todas las pantallas comparten estos datos
        public Partida Partida { get; private set; }

        // Campaña contra K-7: capítulo actual y decisiones tomadas
        public Campana Campana { get; private set; }

        // Misión actual (por ahora hay una sola)
        public Mision Mision { get; private set; }

        // Progreso persistente del jugador (guardado en JSON)
        public Progreso Progreso { get; private set; }

        // Servicio de logros por uso de patrones (guardado en JSON)
        public ServicioLogros ServicioLogros { get; private set; }

        public NavegadorPantallas(Control contenedor)
        {
            this.contenedor = contenedor;
            Partida = new Partida();
            Campana = new Campana(Partida);
            Mision = new Mision();
            Progreso = Progreso.Cargar();
            ServicioLogros = new ServicioLogros();
        }

        // Saca la pantalla actual y pone la nueva ocupando todo el espacio
        private void Mostrar(UserControl pantalla)
        {
            contenedor.Controls.Clear();
            pantalla.Dock = DockStyle.Fill;
            contenedor.Controls.Add(pantalla);
        }

        // Arranca una campaña nueva desde cero y va al primer capítulo
        public void IniciarCampana()
        {
            Partida = new Partida();
            Campana = new Campana(Partida);

            Progreso.Reiniciar();
            Progreso.GanarMonedas(Campana.MonedasIniciales);
            Progreso.Guardar();
            ServicioLogros.Reiniciar();

            IrAHangar();
        }

        public void IrAInicio()
        {
            Mostrar(new PantallaInicio(this));
        }

        public void IrATutorial()
        {
            Mostrar(new PantallaTutorial(this));
        }

        // El hub ahora es el Diario de misión
        public void IrADiario()
        {
            Mostrar(new PantallaHub(this));
        }

        public void IrAMision()
        {
            Mostrar(new PantallaMision(this));
        }

        public void IrAFinal()
        {
            Mostrar(new PantallaFinal(this));
        }

        public void IrAFlyweight()
        {
            Mostrar(new PantallaFlyweight(this));
        }

        public void IrAProxy()
        {
            Mostrar(new PantallaProxy(this));
        }

        public void IrAVisitor()
        {
            Mostrar(new PantallaVisitor(this));
        }

        public void IrALogros()
        {
            Mostrar(new PantallaLogros(this));
        }

        public void IrACombate(ModoCombate modo)
        {
            Mostrar(new PantallaCombate(this, modo));
        }

        public void IrALaboratorio()
        {
            Mostrar(new PanelLaboratorio(this));
        }

        public void IrAControlCentral()
        {
            Mostrar(new PantallaControlCentral(this));
        }

        public void IrAHangar()
        {
            Mostrar(new PantallaHangar(this));
        }

        // Abre la pantalla del capítulo en el que está la campaña
        public void IrACapituloActual()
        {
            switch (Campana.Actual)
            {
                case Capitulo.Hangar: IrAHangar(); break;
                case Capitulo.Laboratorio: IrALaboratorio(); break;
                case Capitulo.Comunicaciones: IrAComunicaciones(); break;
                case Capitulo.ControlCentral: IrAControlCentral(); break;
                case Capitulo.Censo: IrAFlyweight(); break;
                case Capitulo.Boveda: IrAProxy(); break;
                case Capitulo.Inventario: IrAVisitor(); break;
                case Capitulo.Turnos: IrATurnos(); break;
                case Capitulo.EstrategiaIA: IrAEstrategiaIA(); break;
                case Capitulo.Practica: IrAMision(); break;
                case Capitulo.Final: IrAFinalSiSePuede(); break;
                default: IrADiario(); break;
            }
        }

        // El Final solo se abre con los 12 logros. Si falta alguno, se entrena.
        private void IrAFinalSiSePuede()
        {
            if (ServicioLogros.TodosDesbloqueados())
            {
                IrACombate(ModoCombate.Final);
            }
            else
            {
                IrACombate(ModoCombate.Entrenamiento);
            }
        }

        // Cierra el capítulo: avanza la campaña, da XP y monedas y vuelve al Diario.
        // Solo avanza si el capítulo es el actual (así no se puede saltear ni repetir).
        public void TerminarCapitulo(Capitulo capitulo)
        {
            if (Campana.Actual == capitulo)
            {
                Campana.Avanzar();
                Progreso.GanarXp(XpPorCapitulo);
                Partida.XpGanada += XpPorCapitulo;
                Progreso.GanarMonedas(Campana.MonedasPorCapitulo);
                Partida.MonedasGanadas += Campana.MonedasPorCapitulo;
                Progreso.Guardar();
            }
            IrADiario();
        }

        // Guarda el resultado del combate en la partida y muestra victoria o derrota
        public void TerminarCombate(ModoCombate modo, bool gano, int danio, int comandos)
        {
            // El entrenamiento no cambia nada de la campaña
            if (modo == ModoCombate.Entrenamiento)
            {
                IrADiario();
                return;
            }

            Partida.DanioTotal += danio;
            Partida.ComandosUsados += comandos;
            if (modo == ModoCombate.Final)
            {
                TerminarCampana(gano);
                return;
            }

            if (gano)
            {
                Partida.MisionesGanadas++;
                IrAVictoria();
            }
            else
            {
                Partida.MisionesPerdidas++;
                IrADerrota();
            }
        }

        // Fin de la campaña: se guarda el resultado contra K-7 y se muestra el resumen (sin reintento)
        public void TerminarCampana(bool gano)
        {
            Campana.FinalJugado = true;
            Campana.FinalGanado = gano;
            if (gano)
            {
                Partida.MisionesGanadas++;
            }
            else
            {
                Partida.MisionesPerdidas++;
            }
            IrAFinal();
        }

        public void IrAVictoria()
        {
            Mostrar(new PantallaVictoria(this, Mision));
        }

        public void IrADerrota()
        {
            Mostrar(new PantallaDerrota(this));
        }

        public void IrAComunicaciones()
        {
            ServicioLogros.RegistrarUsoPatron("Bridge");
            Mostrar(new PantallaComunicaciones(this));
        }

        public void IrAEstrategiaIA()
        {
            ServicioLogros.RegistrarUsoPatron("Strategy");
            Mostrar(new PantallaEstrategiaIA(this));
        }

        public void IrATurnos()
        {
            ServicioLogros.RegistrarUsoPatron("Template Method");
            Mostrar(new PantallaTurnos(this));
        }
    }
}
