using System;
using System.Collections.Generic;
using System.IO;

namespace Kepler7.Core.Patrones.Estructurales.Proxy
{
    // Maneja el registro persistente de accesos en %AppData%\Kepler7\registro_boveda.log
    public static class RegistroAcceso
    {
        private static readonly string CarpetaLog = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "Kepler7"
        );

        private static readonly string RutaArchivoLog = Path.Combine(CarpetaLog, "registro_boveda.log");

        private static List<string> _historialLogs = new List<string>();

        public static List<string> HistorialLogs => _historialLogs;

        public static string RutaLog => RutaArchivoLog;

        static RegistroAcceso()
        {
            CargarLogs();
        }

        // Carga los registros persistentes al iniciar. No se rompe si el archivo no existe.
        public static void CargarLogs()
        {
            _historialLogs.Clear();
            try
            {
                if (File.Exists(RutaArchivoLog))
                {
                    string[] lineas = File.ReadAllLines(RutaArchivoLog);
                    _historialLogs.AddRange(lineas);
                }
            }
            catch
            {
                // Manejo seguro: si no existe el archivo o hay algún error, no se rompe
            }
        }

        // Registra de forma persistente cada intento (permitido o denegado)
        public static void Registrar(string usuario, string rol, string accion, bool autorizado)
        {
            string estado = autorizado ? "ACCESO PERMITIDO" : "ACCESO DENEGADO";
            string log = $"[{DateTime.Now:dd/MM/yyyy HH:mm:ss}] [{estado}] Usuario: {usuario} ({rol}) - {accion}";

            _historialLogs.Add(log);

            try
            {
                if (!Directory.Exists(CarpetaLog))
                {
                    Directory.CreateDirectory(CarpetaLog);
                }

                File.AppendAllText(RutaArchivoLog, log + Environment.NewLine);
            }
            catch
            {
                // No se rompe si ocurre algún error de escritura
            }
        }

        public static void LimpiarHistorial()
        {
            _historialLogs.Clear();
            try
            {
                if (File.Exists(RutaArchivoLog))
                {
                    File.Delete(RutaArchivoLog);
                }
            }
            catch
            {
            }
        }
    }
}
