using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.IO;

namespace Kepler7.Core.Patrones.Estructurales.Proxy
{
    public class LogEntrada
    {
        public DateTime FechaHora { get; set; }
        public string Usuario { get; set; }
        public string Rol { get; set; }
        public bool Autorizado { get; set; }
        public string Detalle { get; set; }

        public override string ToString()
        {
            string estado = Autorizado ? "ACCESO PERMITIDO" : "ACCESO DENEGADO";
            return $"[{FechaHora:dd/MM/yyyy HH:mm:ss}] - [{estado}] Usuario: {Usuario} ({Rol}) - {Detalle}";
        }
    }

    public static class RegistroAcceso
    {
        public static List<LogEntrada> HistorialLogs { get; } = new List<LogEntrada>();
        private static readonly string RutaArchivoLog = "registro_boveda.log";

        public static void Registrar(string usuario, string rol, bool autorizado, string detalle)
        {
            var log = new LogEntrada
            {
                FechaHora = DateTime.Now,
                Usuario = usuario,
                Rol = rol,
                Autorizado = autorizado,
                Detalle = detalle
            };

            HistorialLogs.Add(log);

            // Registro persistente en archivo físico .log / .txt
            try
            {
                File.AppendAllText(RutaArchivoLog, log.ToString() + Environment.NewLine);
            }
            catch
            {
                // Manejo silencioso en caso de permisos de escritura
            }
        }
    }
}
