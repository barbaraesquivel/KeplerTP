namespace Kepler7.Core.Patrones.Estructurales.Proxy
{
    // Sujeto Real: almacena y gestiona los archivos clasificados de la estación
    public class BovedaDatos : IBoveda
    {
        private Dictionary<string, string> _archivos = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        public BovedaDatos()
        {
            // Archivos confidenciales cargados inicialmente en la bóveda
            _archivos["coordenadas_salto.dat"] = "Coordenadas Hiperespaciales: Sector 7G (84.122 / -12.904) - Ruta segura.";
            _archivos["codigos_autodestruccion.enc"] = "Códigos Alfa de Seguridad: K7-9942-ALPHA-DELTA. Requiere doble confirmación.";
            _archivos["manifiesto_carga.log"] = "Contenedor Criogénico #04: Especímenes alienígenas en estasis criogénica Nivel 5.";
            _archivos["codigo_apagado_IA.dat"] = "Código de apagado de K-7: OMEGA-7-SILENCIO. Usar solo en el combate final.";
        }

        public string LeerArchivo(string nombreArchivo, string usuario = "Desconocido", string rol = "Tripulante")
        {
            if (_archivos.ContainsKey(nombreArchivo))
            {
                return _archivos[nombreArchivo];
            }
            return $"[AVISO] El archivo '{nombreArchivo}' no existe en la bóveda.";
        }

        public void EscribirArchivo(string nombreArchivo, string contenido, string usuario = "Desconocido", string rol = "Tripulante")
        {
            _archivos[nombreArchivo] = contenido;
        }
    }
}
