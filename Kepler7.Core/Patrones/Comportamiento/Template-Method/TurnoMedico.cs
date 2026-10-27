using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepler7.Core.Patrones.Comportamiento.Template_Method
{
    public class TurnoMedico : TurnoUnidad
    {
        protected override string Decision()
        {
            return "[Médico] Busca aliados heridos con salud crítica en el sector.";
        }

        protected override string Accion()
        {
            return "[Médico] Aplica un medikit y restaura puntos de vida.";
        }
    }
}
