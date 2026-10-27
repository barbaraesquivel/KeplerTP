using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepler7.Core.Patrones.Comportamiento.Strategy
{
    public class IACalculadora
    {
        public string DecidirAccion(Enemigo enemigo, Contexto contexto)
        {
            if (enemigo.Salud < 20)
            {
                return $"[Calculadora] {enemigo.Nombre} detecta salud crítica y huye para repararse.";
            }
            if (contexto.DistanciaAlJugador > 10)
            {
                return $"[Calculadora] {enemigo.Nombre} calcula la parábola perfecta y dispara un misil de largo alcance.";
            }

            return $"[Calculadora] {enemigo.Nombre} analiza la proximidad e inicia protocolo de combate cuerpo a cuerpo.";
        }
    }
}
