using System.Collections.Generic;

namespace Kepler7.Core.Patrones.Estructurales.Flyweight
{
    // Fábrica Flyweight: almacena y reutiliza las instancias compartidas de IEspecie
    public class FabricaEspecies
    {
        private Dictionary<string, IEspecie> _especies = new Dictionary<string, IEspecie>();

        // Devuelve la misma instancia si ya existe, o la crea y la almacena si no existe
        public IEspecie ObtenerEspecie(string nombre, string color, string planetaOrigen, string dieta)
        {
            if (!_especies.ContainsKey(nombre))
            {
                _especies[nombre] = new Especie(nombre, color, planetaOrigen, dieta);
            }
            return _especies[nombre];
        }

        public IEspecie ObtenerEspecie(string nombre)
        {
            if (_especies.ContainsKey(nombre))
            {
                return _especies[nombre];
            }
            return null;
        }

        public int CantidadEspeciesCreadas => _especies.Count;

        public void Reiniciar()
        {
            _especies.Clear();
        }
    }
}
