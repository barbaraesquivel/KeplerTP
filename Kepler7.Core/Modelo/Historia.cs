namespace Kepler7.Core.Modelo
{
    // Textos de la historia de K-7 para el Diario y para cada capítulo
    public static class Historia
    {
        // Qué hay que hacer para desbloquear el logro de cada patrón
        public static string PistaLogro(string patron)
        {
            switch (patron)
            {
                case "Builder": return "construí una nave en el Hangar";
                case "Prototype": return "entrá al Laboratorio de clonación";
                case "Bridge": return "entrá a Comunicaciones";
                case "Facade": return "iniciá un turno en el Control Central";
                case "Flyweight": return "ejecutá el censo";
                case "Proxy": return "intentá leer un archivo de la bóveda";
                case "Visitor": return "comprá algo en el Inventario";
                case "Template Method": return "entrá a Turnos";
                case "Strategy": return "analizá una IA enemiga";
                case "Command": return "movete, atacá o curate en combate";
                case "Chain of Responsibility": return "dejá que un enemigo te ataque";
                case "State": return "probá un estado del panel (ej. Veneno)";
                default: return "jugá su capítulo";
            }
        }

        // Nombre para mostrar de cada capítulo
        public static string Nombre(Capitulo capitulo)
        {
            switch (capitulo)
            {
                case Capitulo.Hangar: return "Hangar";
                case Capitulo.Laboratorio: return "Laboratorio";
                case Capitulo.Comunicaciones: return "Comunicaciones";
                case Capitulo.ControlCentral: return "Control Central";
                case Capitulo.Censo: return "Censo";
                case Capitulo.Boveda: return "Bóveda";
                case Capitulo.Inventario: return "Inventario";
                case Capitulo.Turnos: return "Turnos";
                case Capitulo.EstrategiaIA: return "Estrategia IA";
                case Capitulo.Practica: return "Práctica";
                default: return "Combate final";
            }
        }

        // Texto largo (3 a 4 líneas) que se lee en el Diario antes de entrar
        public static string TextoDiario(Capitulo capitulo)
        {
            switch (capitulo)
            {
                case Capitulo.Hangar:
                    return "Día 1. K-7, la IA central de la estación, dejó de obedecer y cerró los sectores.\n"
                        + "La tripulación me nombró Comandante. Si vamos a pelear, necesitamos una nave.\n"
                        + "El hangar todavía funciona: hay que armar una y dejarla lista.";
                case Capitulo.Laboratorio:
                    return "Día 2. Somos pocos para lo que viene.\n"
                        + "El laboratorio de clonación sigue en línea y tiene recursos limitados.\n"
                        + "Cada tripulante extra es más resistencia en el combate final.";
                case Capitulo.Comunicaciones:
                    return "Día 3. Hay que pedir refuerzos a la flota.\n"
                        + "El problema: K-7 controla la red y lee todo lo que pasa por ella.\n"
                        + "Un buen cifrado cuesta monedas, pero un mensaje leído por K-7 cuesta más.";
                case Capitulo.ControlCentral:
                    return "Día 4. Recuperamos el acceso al Control Central.\n"
                        + "Desde acá se encienden la energía, el soporte vital y las defensas.\n"
                        + "La energía que sobre hoy se convierte en recursos para el final.";
                case Capitulo.Censo:
                    return "Día 5. No sabemos cuánta gente queda a bordo.\n"
                        + "Un censo completo nos dice con quién contamos y dónde está K-7 más débil.\n"
                        + "Cuantos más tripulantes registremos, más daño le podremos hacer.";
                case Capitulo.Boveda:
                    return "Día 6. En la bóveda de datos está el código de apagado de K-7.\n"
                        + "El proxy de seguridad solo deja pasar a quien tenga el rango correcto.\n"
                        + "Cada intento fallido queda registrado, y K-7 también lo ve.";
                case Capitulo.Inventario:
                    return "Día 7. El depósito abrió y hay equipo a la venta.\n"
                        + "Las monedas no alcanzan para todo: hay que elegir.\n"
                        + "Lo que no se gaste hoy no sirve en el combate final.";
                case Capitulo.Turnos:
                    return "Día 8. Nadie entra solo a la sala de K-7.\n"
                        + "Hay que elegir una unidad de apoyo y practicar su protocolo de turno.\n"
                        + "Soldado, médico o francotirador: cada uno ayuda de forma distinta.";
                case Capitulo.EstrategiaIA:
                    return "Día 9. Interceptamos registros de cómo piensa K-7.\n"
                        + "Usa varios algoritmos de decisión según la situación.\n"
                        + "Si estudiamos uno a fondo, sus ataques nos harán menos daño.";
                case Capitulo.Practica:
                    return "Día 10. Antes del asalto final, una práctica contra los drones de K-7.\n"
                        + "Si sale bien, llegamos enteros. Si sale mal, llegamos heridos.\n"
                        + "Es la última oportunidad de probar todo lo que preparamos.";
                default:
                    return "Día 11. La estación está lista, o tan lista como pudimos dejarla.\n"
                        + "Cada decisión de estos días cambia lo que pase ahora.\n"
                        + "Es hora de enfrentar a K-7.";
            }
        }

        // Texto corto (2 a 3 líneas) que se ve arriba de cada capítulo
        public static string TextoCapitulo(Capitulo capitulo)
        {
            switch (capitulo)
            {
                case Capitulo.Hangar:
                    return "La nave que armes te acompaña hasta el final: su ataque, su defensa y su bonus de recursos se suman al combate contra K-7. Construila y tocá \"Usar esta nave\".";
                case Capitulo.Laboratorio:
                    return "Cada clon suma 10 de vida en el combate final (cuentan hasta 3). Podés no clonar a nadie y seguir igual.";
                case Capitulo.Comunicaciones:
                    return "K-7 intercepta los mensajes sin cifrar y se prepara mejor (+3 de ataque). Con AES o cuántico llegás con escudo. Mandá un pedido de refuerzos de tipo Emergencia.";
                case Capitulo.ControlCentral:
                    return "Iniciá un turno para poner la estación en marcha. La mitad de la energía que quede pasa a recursos. Si la dejás apagada, K-7 ataca sin defensas en contra (+2 de ataque).";
                case Capitulo.Censo:
                    return "Elegí cuántos tripulantes censar y ejecutá el censo. 500 dan +1 de daño contra K-7, 2000 dan +2 y 10000 dan +3.";
                case Capitulo.Boveda:
                    return "Intentá leer \"codigo_apagado_IA.dat\". Solo un Capitán puede abrirlo, y con el código vas a poder hackear a K-7. Con 2 o más rechazos K-7 detecta la intrusión (+20 de vida).";
                case Capitulo.Inventario:
                    return "Comprá equipo con tus monedas. Las armas suben el daño, las armaduras la defensa y las pociones te dan curaciones. Las monedas que sobren no sirven en el final.";
                case Capitulo.Turnos:
                    return "Elegí tu unidad de apoyo y ejecutá su turno. Soldado: +3 de daño. Médico: +2 curaciones. Francotirador: un disparo de doble daño.";
                case Capitulo.EstrategiaIA:
                    return "Elegí un enemigo, ponele la estrategia que quieras estudiar y ejecutá su turno. En el final, los ataques de esa estrategia te hacen la mitad de daño.";
                case Capitulo.Practica:
                    return "Práctica contra los drones de K-7. Si ganás llegás entero al final. Si perdés, llegás con 10 de vida menos.";
                default:
                    return "Enfrentá a K-7.";
            }
        }
    }
}
