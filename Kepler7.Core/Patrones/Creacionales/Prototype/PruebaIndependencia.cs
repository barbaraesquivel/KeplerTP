namespace Kepler7.Core.Patrones.Creacionales.Prototype
{
    public class PruebaIndependencia
    {
        public List<string> Ejecutar(TripulanteClonable original)
        {
            string originalAntes = original.ToString();
            TripulanteClonable clon = original.Clonar();
            clon.Nombre = original.Nombre + " (clon)";
            ModificarClon(clon);
            return Comparar(original, originalAntes, clon);
        }

        public void ModificarClon(TripulanteClonable clon)
        {
            clon.Nivel++;
            clon.Habilidades.Add("Habilidad nivel " + clon.Nivel);
            clon.Equipo.Arma = "Rifle de plasma";
            clon.Equipo.Objetos.Add("Botiquin");
        }

        public List<string> Comparar(TripulanteClonable original, string originalAntes, TripulanteClonable clon)
        {
            List<string> resultado = new List<string>();
            resultado.Add("¿Comparten la lista de habilidades? " + SiNo(ReferenceEquals(original.Habilidades, clon.Habilidades)));
            resultado.Add("¿Comparten el equipamiento? " + SiNo(ReferenceEquals(original.Equipo, clon.Equipo)));
            resultado.Add("¿El original sigue igual que al principio? " + SiNo(original.ToString() == originalAntes));
            return resultado;
        }

        private string SiNo(bool valor)
        {
            if (valor)
            {
                return "Sí";
            }
            return "No";
        }
    }
}
