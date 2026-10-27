using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepler7.Core.Patrones.Comportamiento.Strategy
{
    public class IAAleatoria
    {
        private Random numRandom = new Random();
        public string DecidirAccion(Enemigo enemigo, Contexto contexto)
        {
            int accion = numRandom.Next(0, 3);
            if (accion == 0) return $"[Aleatoria] {enemigo.Nombre} dispara al techo por error.";
            if (accion == 1) return $"[Aleatoria] {enemigo.Nombre} da vueltas sobre su propio eje.";
            return $"[Aleatoria] {enemigo.Nombre} emite un sonido estático y no hace nada.";
        }
    }
}
