using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kepler7.Core.Patrones.Estructurales.Flyweight;

namespace Kepler7.Core.Modelo
{
    public class Tripulante : Personaje
    {
        public int Legajo { get; set; }

        // Referencia compartida al Flyweight (Estado Intrínseco)
        public EspecieFlyweight Especie { get; set; }

        public Tripulante(int legajo, string nombre, int vidaMax, int ataqueBase, EspecieFlyweight especie)
            : base(nombre, vidaMax, ataqueBase)
        {
            Legajo = legajo;
            Especie = especie;
        }
    }

    // Para la comparación SIN patrón en la prueba numérica
    public class TripulanteSinPatron : Personaje
    {
        public int Legajo { get; set; }
        public string NombreEspecie { get; set; }
        public string PlanetaOrigen { get; set; }
        public string HabilidadEspecial { get; set; }
        public byte[] TexturaSkin { get; set; } = new byte[100 * 1024];

        public TripulanteSinPatron(int legajo, string nombre, int vidaMax, int ataqueBase, string especie, string origen, string habilidad)
            : base(nombre, vidaMax, ataqueBase)
        {
            Legajo = legajo;
            NombreEspecie = especie;
            PlanetaOrigen = origen;
            HabilidadEspecial = habilidad;
        }
    }
}