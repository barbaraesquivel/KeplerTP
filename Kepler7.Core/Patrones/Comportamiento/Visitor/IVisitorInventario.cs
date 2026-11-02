using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kepler7.Core.Modelo;

namespace Kepler7.Core.Patrones.Comportamiento.Visitor
{
    public interface IVisitorInventario
    {
        void Visitar(Arma arma);
        void Visitar(Medicamento medicamento);
        void Visitar(Herramienta herramienta);
    }
}