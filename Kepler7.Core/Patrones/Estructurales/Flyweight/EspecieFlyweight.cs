using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepler7.Core.Patrones.Estructurales.Flyweight
{
    // Estado Intrínseco: Se comparte entre miles de tripulantes.
    public class EspecieFlyweight
    {
        public string NombreEspecie { get; }
        public string PlanetaOrigen { get; }
        public string HabilidadEspecial { get; }
        public byte[] TexturaSkin { get; } // Simula carga/peso en memoria

        public EspecieFlyweight(string nombreEspecie, string planetaOrigen, string habilidadEspecial)
        {
            NombreEspecie = nombreEspecie;
            PlanetaOrigen = planetaOrigen;
            HabilidadEspecial = habilidadEspecial;
            // Simulamos datos pesados (ej. 100 KB por especie)
            TexturaSkin = new byte[100 * 1024];
        }

        public void MostrarInformacion(string nombreTripulante, int legajo)
        {
            // Combina estado intrínseco (Especie) con extrínseco (Tripulante)
            System.Console.WriteLine($"[Legajo {legajo}] {nombreTripulante} | Especie: {NombreEspecie} | Origen: {PlanetaOrigen}");
        }
    }
}