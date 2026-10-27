using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepler7.Core.Patrones.Comportamiento.Strategy
{
    public interface IEstrategiaIA
    {
        string DecidirAccion(Enemigo enemigo, Contexto contexto);

    }
}
