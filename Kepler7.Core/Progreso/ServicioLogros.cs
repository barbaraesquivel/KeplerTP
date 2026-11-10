using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Kepler7.Core.Progreso
{
    // Administra los 12 logros (uno por cada patrón de diseño) y los guarda en JSON
    public class ServicioLogros : IServicioLogros
    {
        public List<Logro> Logros { get; set; }

        public ServicioLogros()
        {
            InicializarLogros();
            Cargar();
        }

        // Crea la lista con los 12 logros correspondientes a los patrones del juego
        private void InicializarLogros()
        {
            Logros = new List<Logro>
            {
                new Logro("Builder", "Constructor Espacial", "Construir una nave en el Hangar usando el patrón Builder."),
                new Logro("Prototype", "Clonación Genética", "Clonar un tripulante en el Laboratorio usando el patrón Prototype."),
                new Logro("Facade", "Control Centralizado", "Operar los subsistemas desde el Control Central con el patrón Facade."),
                new Logro("Flyweight", "Censo Optimizado", "Registrar tripulantes reutilizando especies con el patrón Flyweight."),
                new Logro("Proxy", "Guardián de la Bóveda", "Controlar el acceso a los archivos secretos mediante el patrón Proxy."),
                new Logro("Bridge", "Enlace Cifrado", "Transmitir mensajes desde Comunicaciones usando el patrón Bridge."),
                new Logro("Visitor", "Analista de Inventario", "Aplicar operaciones sobre los ítems usando el patrón Visitor."),
                new Logro("Command", "Comandante Táctico", "Ejecutar, deshacer y rehacer órdenes de combate con el patrón Command."),
                new Logro("Chain of Responsibility", "Defensa Escalonada", "Procesar el daño recibido a través de la cadena de defensa."),
                new Logro("State", "Alteración de Estado", "Cambiar el comportamiento del personaje según su estado con el patrón State."),
                new Logro("Strategy", "Mente Táctica", "Cambiar el algoritmo de decisión de la IA enemiga con el patrón Strategy."),
                new Logro("Template Method", "Protocolo de Turno", "Ejecutar el esqueleto de turno de las unidades con Template Method.")
            };
        }

        // Desbloquea el logro correspondiente al patrón recibido y guarda en JSON
        public void RegistrarUsoPatron(string patron)
        {
            if (string.IsNullOrWhiteSpace(patron)) return;

            string clave = NormalizarNombrePatron(patron);

            foreach (Logro logro in Logros)
            {
                if (string.Equals(logro.Patron, clave, StringComparison.OrdinalIgnoreCase))
                {
                    if (!logro.Desbloqueado)
                    {
                        logro.Desbloqueado = true;
                        Guardar();
                    }
                    break;
                }
            }
        }

        // Permite reconocer variantes del nombre de un patrón (ej: "Chain" o "Template-Method")
        private string NormalizarNombrePatron(string patron)
        {
            string limpio = patron.Trim();

            if (string.Equals(limpio, "Chain", StringComparison.OrdinalIgnoreCase))
                return "Chain of Responsibility";

            if (string.Equals(limpio, "Template-Method", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(limpio, "TemplateMethod", StringComparison.OrdinalIgnoreCase))
                return "Template Method";

            return limpio;
        }

        // Ruta del archivo en %AppData%\Kepler7\logros.json
        public static string ObtenerRutaArchivo()
        {
            string carpeta = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Kepler7"
            );
            return Path.Combine(carpeta, "logros.json");
        }

        // Guarda la lista de logros y su estado en formato JSON
        public void Guardar()
        {
            try
            {
                string ruta = ObtenerRutaArchivo();
                string carpeta = Path.GetDirectoryName(ruta);
                if (!string.IsNullOrEmpty(carpeta) && !Directory.Exists(carpeta))
                {
                    Directory.CreateDirectory(carpeta);
                }

                var opciones = new JsonSerializerOptions
                {
                    WriteIndented = true
                };

                string json = JsonSerializer.Serialize(Logros, opciones);
                File.WriteAllText(ruta, json);
            }
            catch
            {
                // Si ocurre algún error de escritura, no rompe el juego
            }
        }

        // Carga el estado de los logros desde el archivo JSON
        public void Cargar()
        {
            try
            {
                string ruta = ObtenerRutaArchivo();
                if (File.Exists(ruta))
                {
                    string json = File.ReadAllText(ruta);
                    var opciones = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    var guardados = JsonSerializer.Deserialize<List<Logro>>(json, opciones);
                    if (guardados != null)
                    {
                        foreach (Logro guardado in guardados)
                        {
                            if (guardado != null && guardado.Desbloqueado)
                            {
                                foreach (Logro actual in Logros)
                                {
                                    if (string.Equals(actual.Patron, guardado.Patron, StringComparison.OrdinalIgnoreCase))
                                    {
                                        actual.Desbloqueado = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                // Si el archivo no existe o está dañado, arranca con los logros bloqueados por defecto
            }
        }

        // Reinicia todos los logros a estado bloqueado y guarda
        public void Reiniciar()
        {
            foreach (Logro logro in Logros)
            {
                logro.Desbloqueado = false;
            }
            Guardar();
        }
    }
}
