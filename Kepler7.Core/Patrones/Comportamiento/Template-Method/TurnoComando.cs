using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepler7.Core.Patrones.Comportamiento.Template_Method
{
    public class TurnoComando : TurnoUnidad
    {
        protected override string Decision()
        {
            return "[Comandante] Analiza el mapa táctico general de Kepler-7.";
        }

        protected override string Accion()
        {
            return "[Comandante] Emite una orden de reagrupamiento que potencia a los aliados.";
        }

        protected override string Finalizacion()
        {
            return "[Comandante] Cierra las comunicaciones y aguarda reportes.";
        }
    }
}
