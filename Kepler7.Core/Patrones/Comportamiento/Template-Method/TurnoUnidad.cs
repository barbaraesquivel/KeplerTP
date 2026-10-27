using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepler7.Core.Patrones.Comportamiento.Template_Method
{
    public abstract class TurnoUnidad
    {
        public List<string> EjecutarTurno()
        {
            List<string> historialTurno = new List<string>();

            historialTurno.Add(Inicio());
            historialTurno.Add(Decision());
            historialTurno.Add(Accion());
            historialTurno.Add(Finalizacion());

            return historialTurno;
        }

        protected virtual string Inicio()
        {
            return "Unidad iniciando su turno estándar.";
        }

        protected abstract string Decision();

        protected abstract string Accion();

        protected virtual string Finalizacion()
        {
            return "Unidad finalizando su turno y pasando a espera.";
        }
    }
}
