using Kepler7.Core.Patrones.Comportamiento.Visitor;

namespace Kepler7.Core.Modelo
{
    // Ítems que se pueden comprar en el capítulo Inventario
    public static class CatalogoTienda
    {
        public const string ArmaMasCara = "Rifle de Plasma";
        public const string ArmaduraMasCara = "Traje Espacial Blindado";

        public static List<IItem> CrearItems()
        {
            return new List<IItem>
            {
                new Arma("Rifle de Plasma", 350, 45),
                new Arma("Pistola Láser", 150, 20),
                new Arma("Cuchillo Táctico", 80, 15),
                new Pocion("Poción de Salud", 50, 40),
                new Pocion("Elixir de Regeneración", 120, 100),
                new Armadura("Traje Espacial Blindado", 300, 50),
                new Armadura("Escudo de Nanofibra", 200, 30)
            };
        }

        // Busca un ítem por nombre (null si no existe)
        public static IItem Buscar(string nombre)
        {
            foreach (IItem item in CrearItems())
            {
                if (item.Nombre == nombre)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
