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

        public EstadoVisual EstadoVisual
        {
            get { return Estado.Visual; }
        }

        public ResultadoAccion Atacar(Personaje objetivo)
        {
            ResultadoAccion resultado = Estado.Atacar(this);
            if (resultado.Exito)
            {
                objetivo.RecibirDanio(new Danio(resultado.Valor, "Fisico", this));
            }
            return resultado;
        }

        public ResultadoAccion Mover(int dx, int dy)
        {
            return Estado.Mover(this, dx, dy);
        }

        public ResultadoDanio RecibirDanio(Danio danio)
        {
            return Estado.RecibirDanio(this, danio);
        }

        public void FinTurno()
        {
            Estado.FinTurno(this);
        }
    }
}
