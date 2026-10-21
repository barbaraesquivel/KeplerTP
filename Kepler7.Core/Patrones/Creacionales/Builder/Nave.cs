namespace Kepler7.Core.Patrones.Creacionales.Builder
{
    // Producto del Builder: la nave que se arma por partes
    public class Nave
    {
        public string Tipo { get; set; }

        // Componentes (todos opcionales: null = no instalado)
        public string Casco { get; set; }
        public string Motor { get; set; }
        public string Escudo { get; set; }
        public string Armas { get; set; }
        public string Radar { get; set; }
        public string IA { get; set; }
        public string Combustible { get; set; }

        // Estadísticas que suman los componentes al instalarse
        public int Ataque { get; set; }
        public int Defensa { get; set; }
        public int Velocidad { get; set; }
        public int Autonomia { get; set; }

        // Bonus que la nave le da a la misión
        public int BonusRecursos { get; set; }
        public int Capacidad { get; set; }

        // Devuelve el detalle de la nave para mostrar en pantalla
        public string Describir()
        {
            string texto = "Nave " + Tipo + Environment.NewLine;
            texto += Linea("Casco", Casco);
            texto += Linea("Motor", Motor);
            texto += Linea("Escudo", Escudo);
            texto += Linea("Armas", Armas);
            texto += Linea("Radar", Radar);
            texto += Linea("IA", IA);
            texto += Linea("Combustible", Combustible);
            texto += "Ataque: " + Ataque + " | Defensa: " + Defensa + " | Velocidad: " + Velocidad + " | Autonomía: " + Autonomia + Environment.NewLine;
            texto += "Bonus recursos: +" + BonusRecursos + "% | Capacidad: " + Capacidad;
            return texto;
        }

        // Arma una línea solo si el componente está instalado
        private string Linea(string nombre, string valor)
        {
            if (valor == null)
            {
                return "";
            }
            return "- " + nombre + ": " + valor + Environment.NewLine;
        }
    }
}
