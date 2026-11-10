using System;
using System.IO;
using System.Text.Json;

namespace Kepler7.Core.Progreso
{
    // Sistema de progreso del jugador con XP, nivel y monedas
    public class Progreso : IProgreso
    {
        public const int XpPorNivel = 100;

        public int Xp { get; set; }
        public int Nivel { get; set; } = 1;
        public int Monedas { get; set; }

        public Progreso()
        {
            Xp = 0;
            Nivel = 1;
            Monedas = 0;
        }

        public Progreso(int xp, int nivel, int monedas)
        {
            Xp = xp;
            Nivel = nivel < 1 ? 1 : nivel;
            Monedas = monedas;
        }

        // Incrementa la experiencia y sube de nivel al alcanzar la cantidad requerida
        public void GanarXp(int cantidad)
        {
            if (cantidad <= 0) return;

            Xp += cantidad;

            // Cada 100 puntos de XP sube un nivel
            while (Xp >= XpPorNivel)
            {
                Xp -= XpPorNivel;
                Nivel++;
            }
        }

        // Incrementa la cantidad de monedas acumuladas
        public void GanarMonedas(int cantidad)
        {
            if (cantidad <= 0) return;
            Monedas += cantidad;
        }

        // Obtiene la ruta del archivo en %AppData%\Kepler7\progreso.json
        public static string ObtenerRutaArchivo()
        {
            string carpeta = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Kepler7"
            );
            return Path.Combine(carpeta, "progreso.json");
        }

        // Guarda el progreso en JSON con System.Text.Json
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

                string json = JsonSerializer.Serialize(this, opciones);
                File.WriteAllText(ruta, json);
            }
            catch
            {
                // Manejo seguro: si falla el guardado, no rompe el juego
            }
        }

        public static void Guardar(Progreso progreso)
        {
            if (progreso != null)
            {
                progreso.Guardar();
            }
        }

        // Carga el progreso desde JSON. Si no existe o está dañado, arranca con progreso nuevo.
        public static Progreso Cargar()
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
                    var progreso = JsonSerializer.Deserialize<Progreso>(json, opciones);
                    if (progreso != null)
                    {
                        if (progreso.Nivel < 1)
                        {
                            progreso.Nivel = 1;
                        }
                        return progreso;
                    }
                }
            }
            catch
            {
                // Si el archivo no existe o está dañado, arranca con progreso nuevo
            }

            return new Progreso();
        }

        // Reinicia los valores de progreso a los valores iniciales
        public void Reiniciar()
        {
            Xp = 0;
            Nivel = 1;
            Monedas = 0;
        }
    }
}
