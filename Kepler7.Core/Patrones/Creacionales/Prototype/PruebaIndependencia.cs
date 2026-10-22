namespace Kepler7.Core.Patrones.Creacionales.Prototype
{
    public class PruebaIndependencia
    {
        public List<string> Ejecutar(TripulanteClonable original)
        {
            TripulanteClonable clon = original.Clonar();
            clon.Nombre = original.Nombre + " (clon)";
            clon.Nivel = original.Nivel + 5;
            clon.Habilidades.Add("Telepatia");
            clon.Equipo.Arma = "Rifle de plasma";
            clon.Equipo.Objetos.Add("Botiquin");

            List<string> resultado = new List<string>();
            resultado.Add("Original: " + original);
            resultado.Add("Clon: " + clon);
            resultado.Add("Misma lista de habilidades: " + ReferenceEquals(original.Habilidades, clon.Habilidades));
            resultado.Add("Mismo equipamiento: " + ReferenceEquals(original.Equipo, clon.Equipo));
            resultado.Add("Original tiene Telepatia: " + original.Habilidades.Contains("Telepatia"));
            resultado.Add("Original tiene Botiquin: " + original.Equipo.Objetos.Contains("Botiquin"));
            return resultado;
        }
    }
}
