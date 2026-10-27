using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepler7.Core.Patrones.Comportamiento.Template_Method
{
    public class TurnoFrancotirador : TurnoUnidad
    {
        protected override string Inicio()
        {
            return "[Francotirador] Se camufla y activa la mira telescópica.";
        }

        protected override string Decision()
        {
            return "[Francotirador] Calcula la distancia y el viento hacia el objetivo más lejano.";
        }

        protected override string Accion()
        {
            return "[Francotirador] Ejecuta un disparo de precisión certero.";
        }
    }
}
