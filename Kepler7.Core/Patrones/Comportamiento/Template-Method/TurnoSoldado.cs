using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepler7.Core.Patrones.Comportamiento.Template_Method
{
    public class TurnoSoldado : TurnoUnidad
    {
        protected override string Inicio()
        {
            return "[Soldado] Verifica su munición y toma posición.";
        }

        protected override string Decision()
        {
            return "[Soldado] Evalúa avanzar hacia la cobertura más cercana.";
        }

        protected override string Accion()
        {
            return "[Soldado] Dispara una ráfaga de supresión con su rifle.";
        }

        protected override string Finalizacion()
        {
            return "[Soldado] Asegura el perímetro y termina el turno.";
        }
    }
}
