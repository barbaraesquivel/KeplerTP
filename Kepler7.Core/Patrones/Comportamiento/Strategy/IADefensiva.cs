using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepler7.Core.Patrones.Comportamiento.Strategy
{
    public class IADefensiva : IEstrategiaIA
    {
        public string DecidirAccion(Enemigo enemigo, Contexto contexto)
        {
            return $"[Defensiva] {enemigo.Nombre} levanta un escudo de energía y retrocede a una posición segura.";
        }
    }
}
