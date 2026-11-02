using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kepler7.Core.Modelo;

namespace Kepler7.Core.Patrones.Comportamiento.Visitor
{
    public class VisitorValorTotal : IVisitorInventario
    {
        public double ValorTotalCreditos { get; private set; }
        public int CantidadTotalItems { get; private set; }
        public int TotalArmas { get; private set; }
        public int TotalMedicamentos { get; private set; }
        public int TotalHerramientas { get; private set; }

        public void Visitar(Arma arma)
        {
            CantidadTotalItems += arma.Cantidad;
            ValorTotalCreditos += arma.ValorCreditos * arma.Cantidad;
            TotalArmas += arma.Cantidad;
        }

        public void Visitar(Medicamento medicamento)
        {
            CantidadTotalItems += medicamento.Cantidad;
            // Si está vencido pierde el 50% de su valor comercial
            double valorReal = medicamento.EstaVencido ? medicamento.ValorCreditos * 0.5 : medicamento.ValorCreditos;
            ValorTotalCreditos += valorReal * medicamento.Cantidad;
            TotalMedicamentos += medicamento.Cantidad;
        }

        public void Visitar(Herramienta herramienta)
        {
            CantidadTotalItems += herramienta.Cantidad;
            ValorTotalCreditos += herramienta.ValorCreditos * herramienta.Cantidad;
            TotalHerramientas += herramienta.Cantidad;
        }
    }
}