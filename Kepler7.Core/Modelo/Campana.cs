using Kepler7.Core.Patrones.Comportamiento.Visitor;
using Kepler7.Core.Patrones.Creacionales.Builder;
using Kepler7.Core.Patrones.Estructurales.Facade;

namespace Kepler7.Core.Modelo
{
    // Campaña lineal contra K-7: guarda el capítulo actual y las decisiones del Comandante
    public class Campana
    {
        public const int MonedasIniciales = 300;
        public const int MonedasPorCapitulo = 25;
        public const int PrecioAES = 20;
        public const int PrecioCuantico = 40;
        public const int MaxClones = 3;

        private Partida partida;
        private int clonesCreados;

        public Capitulo Actual { get; private set; }

        // Hangar (Builder): la nave se guarda en Partida
        public Nave NaveElegida
        {
            get { return partida.NaveElegida; }
            set { partida.NaveElegida = value; }
        }

        // Laboratorio (Prototype)
        public int ClonesCreados
        {
            get { return clonesCreados; }
            set { clonesCreados = Math.Clamp(value, 0, MaxClones); }
        }

        // Comunicaciones (Bridge)
        public string CifradoMensaje { get; set; }
        public bool MensajeEnviado { get; set; }

        // Control Central (Facade)
        public int EnergiaRestante { get; set; }
        public EstadoEstacion EstadoEstacion { get; set; }

        // Censo (Flyweight)
        public int TripulantesCensados { get; set; }

        // Bóveda (Proxy)
        public bool TieneCodigoApagado { get; set; }
        public int AccesosRechazados { get; set; }

        // Inventario (Visitor)
        public List<string> ItemsComprados { get; private set; }
        public int MonedasGastadas { get; set; }

        // Turnos (Template Method)
        public string UnidadDeApoyo { get; set; }

        // Estrategia IA (Strategy)
        public string IaAnalizada { get; set; }

        // Práctica
        public bool PracticaGanada { get; set; }

        // Combate final contra K-7
        public bool FinalJugado { get; set; }
        public bool FinalGanado { get; set; }

        public Campana(Partida partida)
        {
            this.partida = partida;
            Reiniciar();
        }

        // Pasa al siguiente capítulo (en Final se queda ahí)
        public void Avanzar()
        {
            if (Actual != Capitulo.Final)
            {
                Actual = Actual + 1;
            }
        }

        // Deja la campaña como nueva
        public void Reiniciar()
        {
            Actual = Capitulo.Hangar;
            NaveElegida = null;
            ClonesCreados = 0;
            CifradoMensaje = "Sin cifrado";
            MensajeEnviado = false;
            EnergiaRestante = 0;
            EstadoEstacion = EstadoEstacion.Apagada;
            TripulantesCensados = 0;
            TieneCodigoApagado = false;
            AccesosRechazados = 0;
            ItemsComprados = new List<string>();
            MonedasGastadas = 0;
            UnidadDeApoyo = "";
            IaAnalizada = "";
            PracticaGanada = false;
            FinalJugado = false;
            FinalGanado = false;
        }

        // ---------- Dinero ----------

        public static int PrecioCifrado(string cifrado)
        {
            if (cifrado == "AES") return PrecioAES;
            if (cifrado == "Cuántico") return PrecioCuantico;
            return 0;
        }

        // Suma el carrito con el Visitor CalculadorPrecio
        public static int PrecioCarrito(List<IItem> carrito)
        {
            CalculadorPrecio calculador = new CalculadorPrecio();
            foreach (IItem item in carrito)
            {
                item.Aceptar(calculador);
            }
            return (int)calculador.PrecioTotal;
        }

        // Compra el carrito si alcanzan las monedas
        public bool ComprarCarrito(List<IItem> carrito, Progreso.Progreso progreso)
        {
            int precio = PrecioCarrito(carrito);
            if (!progreso.GastarMonedas(precio))
            {
                return false;
            }

            foreach (IItem item in carrito)
            {
                ItemsComprados.Add(item.Nombre);
            }
            MonedasGastadas += precio;
            return true;
        }

        // ---------- Efectos en el combate final ----------

        // Solo cuentan los capítulos ya terminados (en el Final están todos)
        public ModificadoresFinal CalcularModificadores()
        {
            ModificadoresFinal mod = new ModificadoresFinal();
            if (Terminado(Capitulo.Hangar)) AplicarNave(mod);
            if (Terminado(Capitulo.Laboratorio)) AplicarClones(mod);
            if (Terminado(Capitulo.Comunicaciones)) AplicarMensaje(mod);
            if (Terminado(Capitulo.ControlCentral)) AplicarEstacion(mod);
            if (Terminado(Capitulo.Censo)) AplicarCenso(mod);
            if (Terminado(Capitulo.Boveda)) AplicarBoveda(mod);
            if (Terminado(Capitulo.Inventario)) AplicarInventario(mod);
            if (Terminado(Capitulo.Turnos)) AplicarUnidad(mod);
            if (Terminado(Capitulo.EstrategiaIA)) AplicarEstrategia(mod);
            if (Terminado(Capitulo.Practica)) AplicarPractica(mod);
            return mod;
        }

        public bool Terminado(Capitulo capitulo)
        {
            return Actual > capitulo;
        }

        // Anota una decisión en el resumen. Puntos: cuánto ayudó, en "vida equivalente".
        // Referencia: 1 de daño = 8 (se ataca unas 9 veces), 1 de armadura = 6 (K-7 pega unas 6 veces),
        // 1 de ataque de K-7 = -6, vida y escudo 1 a 1, una curación = 20, 3 de recursos = 1.
        // El consejo se completa cuando la decisión no ayudó: dice qué habría convenido.
        private void Anotar(ModificadoresFinal mod, string texto, int puntos, string consejo)
        {
            mod.Resumen.Add(texto);
            mod.Efectos.Add(new EfectoDecision(texto, puntos, consejo));
        }

        private void AplicarNave(ModificadoresFinal mod)
        {
            if (NaveElegida == null)
            {
                Anotar(mod, "No elegiste nave: sin bonus de nave", 0, "Elegir una nave en el Hangar sumaba daño, armadura y recursos.");
                return;
            }

            int danio = NaveElegida.Ataque / 10;
            int armadura = NaveElegida.Defensa / 10;
            int recursos = NaveElegida.BonusRecursos;
            mod.DanioExtra += danio;
            mod.ArmaduraExtra += armadura;
            mod.RecursosExtra += recursos;
            int puntos = danio * 8 + armadura * 6 + recursos / 3;
            string consejo = puntos == 0 ? "Construir la nave completa (la de Combate suma más daño y armadura) daba ventaja en el final." : "";
            Anotar(mod, "Nave " + NaveElegida.Tipo + ": +" + danio + " de daño, +" + armadura + " de armadura, +" + recursos + " de recursos", puntos, consejo);
        }

        private void AplicarClones(ModificadoresFinal mod)
        {
            int vida = ClonesCreados * 10;
            mod.VidaExtra += vida;
            string consejo = ClonesCreados == 0 ? "Clonar 3 tripulantes en el Laboratorio te habría dado +30 de vida." : "";
            Anotar(mod, "Clonaste " + ClonesCreados + " tripulantes: +" + vida + " de vida", vida, consejo);
        }

        private void AplicarMensaje(ModificadoresFinal mod)
        {
            if (!MensajeEnviado || CifradoMensaje == "Sin cifrado")
            {
                mod.JefeAtaqueExtra += 3;
                Anotar(mod, "Mensaje sin cifrar (o sin enviar): K-7 lo interceptó y empieza con +3 de ataque", -18,
                    "Cifrar el pedido de refuerzos (AES o Cuántico) evitaba que K-7 sume +3 de ataque y te daba escudo.");
            }
            else if (CifradoMensaje == "AES")
            {
                mod.EscudoInicial += 10;
                Anotar(mod, "Enviaste el mensaje con AES: empezás con 10 de escudo", 10, "");
            }
            else if (CifradoMensaje == "Cuántico")
            {
                mod.EscudoInicial += 20;
                Anotar(mod, "Enviaste el mensaje con cifrado cuántico: empezás con 20 de escudo", 20, "");
            }
        }

        private void AplicarEstacion(ModificadoresFinal mod)
        {
            int recursos = EnergiaRestante / 2;
            mod.RecursosExtra += recursos;
            string consejo = recursos == 0 ? "Guardar energía en el Control Central se convertía en recursos para torretas." : "";
            Anotar(mod, "La estación quedó con " + EnergiaRestante + " de energía: +" + recursos + " de recursos", recursos / 3, consejo);

            if (EstadoEstacion == EstadoEstacion.Apagada)
            {
                mod.JefeAtaqueExtra += 2;
                Anotar(mod, "La estación quedó apagada y sin defensas: K-7 tiene +2 de ataque", -12,
                    "Dejar la estación encendida en el Control Central evitaba que K-7 sume +2 de ataque.");
            }
        }

        private void AplicarCenso(ModificadoresFinal mod)
        {
            int danio = 0;
            if (TripulantesCensados >= 10000) danio = 3;
            else if (TripulantesCensados >= 2000) danio = 2;
            else if (TripulantesCensados >= 500) danio = 1;

            mod.DanioContraJefe += danio;
            string consejo = danio == 0 ? "Hacer el censo daba hasta +3 de daño contra K-7." : "";
            Anotar(mod, "Censaste " + TripulantesCensados + " tripulantes: +" + danio + " de daño contra K-7", danio * 8, consejo);
        }

        private void AplicarBoveda(ModificadoresFinal mod)
        {
            if (TieneCodigoApagado)
            {
                mod.PuedeHackearIA = true;
                Anotar(mod, "Conseguiste el código de apagado: podés hackear a K-7", 25, "");
            }
            else
            {
                Anotar(mod, "No conseguiste el código de apagado: no podés hackear a K-7", 0,
                    "Leer el código de la bóveda con rol Capitán te dejaba hackear a K-7 durante 2 turnos.");
            }

            if (AccesosRechazados >= 2)
            {
                mod.JefeVidaExtra += 20;
                Anotar(mod, "La bóveda rechazó " + AccesosRechazados + " accesos: K-7 detectó la intrusión y tiene +20 de vida", -20,
                    "Entrar a la bóveda con menos de 2 rechazos evitaba que K-7 sume +20 de vida.");
            }
        }

        private void AplicarInventario(ModificadoresFinal mod)
        {
            foreach (string nombre in ItemsComprados)
            {
                IItem item = CatalogoTienda.Buscar(nombre);
                if (item is Arma)
                {
                    int danio = nombre == CatalogoTienda.ArmaMasCara ? 8 : 4;
                    mod.DanioExtra += danio;
                    Anotar(mod, "Compraste " + nombre + ": +" + danio + " de daño", danio * 8, "");
                }
                else if (item is Armadura)
                {
                    int armadura = nombre == CatalogoTienda.ArmaduraMasCara ? 5 : 3;
                    mod.ArmaduraExtra += armadura;
                    Anotar(mod, "Compraste " + nombre + ": +" + armadura + " de armadura", armadura * 6, "");
                }
                else if (item is Pocion)
                {
                    mod.CuracionesExtra += 1;
                    Anotar(mod, "Compraste " + nombre + ": +1 curación", 20, "");
                }
            }

            if (ItemsComprados.Count == 0)
            {
                Anotar(mod, "No compraste nada en el inventario", 0, "Comprar un arma o una armadura en el Inventario sumaba daño o defensa.");
            }
        }

        private void AplicarUnidad(ModificadoresFinal mod)
        {
            if (UnidadDeApoyo == "Soldado")
            {
                mod.DanioExtra += 3;
                Anotar(mod, "Te acompaña un Soldado: +3 de daño", 24, "");
            }
            else if (UnidadDeApoyo == "Médico")
            {
                mod.CuracionesExtra += 2;
                Anotar(mod, "Te acompaña un Médico: +2 curaciones", 40, "");
            }
            else if (UnidadDeApoyo == "Francotirador")
            {
                mod.DisparoEspecial = true;
                Anotar(mod, "Te acompaña un Francotirador: un disparo especial de doble daño", 20, "");
            }
            else
            {
                Anotar(mod, "No elegiste unidad de apoyo", 0, "Elegir una unidad de apoyo en Turnos sumaba daño o curaciones.");
            }
        }

        private void AplicarEstrategia(ModificadoresFinal mod)
        {
            mod.IaAnalizada = IaAnalizada;
            if (IaAnalizada == "")
            {
                Anotar(mod, "No analizaste ninguna estrategia de K-7", 0, "Estudiar una IA en Estrategia IA te cortaba a la mitad el daño de esa fase.");
            }
            else if (IaAnalizada == "IAAleatoria")
            {
                // K-7 solo usa IAAleatoria si la hackeás
                Anotar(mod, "Analizaste IAAleatoria: K-7 solo la usa si la hackeás", 0,
                    "K-7 pelea con IAAgresiva, IACalculadora e IADefensiva: estudiar una de esas te cortaba su daño a la mitad.");
            }
            else
            {
                Anotar(mod, "Analizaste " + IaAnalizada + ": sus ataques te hacen la mitad de daño", 20, "");
            }
        }

        private void AplicarPractica(ModificadoresFinal mod)
        {
            if (PracticaGanada)
            {
                Anotar(mod, "Ganaste la práctica: llegás entero al final", 0, "");
            }
            else
            {
                mod.VidaExtra -= 10;
                Anotar(mod, "Perdiste la práctica: llegás herido al final (-10 de vida)", -10,
                    "Ganar la práctica te hacía llegar al final con 10 de vida más.");
            }
        }
    }
}
