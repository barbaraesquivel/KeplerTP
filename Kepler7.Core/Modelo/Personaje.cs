using Kepler7.Core.Patrones.Comportamiento.Chain;
using Kepler7.Core.Patrones.Comportamiento.State;

namespace Kepler7.Core.Modelo
{
    public class Personaje : Unidad
    {
        public IEstadoPersonaje Estado { get; private set; }
        public int AtaqueBase { get; set; }
        public CadenaDefensa Defensa { get; set; }

        public Personaje(string nombre, int vidaMax, int ataqueBase)
        {
            Nombre = nombre;
            VidaMax = vidaMax;
            Vida = vidaMax;
            AtaqueBase = ataqueBase;
            Estado = new Normal();
            Defensa = new CadenaDefensa();
            Defensa.Agregar(new Patrones.Comportamiento.Chain.Vida(this));
        }

        public void CambiarEstado(IEstadoPersonaje nuevoEstado)
        {
            Estado = nuevoEstado;
        }
    }
}
