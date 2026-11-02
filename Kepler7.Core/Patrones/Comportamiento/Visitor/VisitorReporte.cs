using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kepler7.Core.Modelo;

namespace Kepler7.Core.Patrones.Comportamiento.Visitor
{
    public class VisitorReporte : IVisitorInventario
    {
        private readonly StringBuilder _sb = new StringBuilder();

        public string ObtenerReporte() => _sb.ToString();

        public void Visitar(Arma arma)
        {
            _sb.AppendLine($"[ARMA] {arma.Nombre} x{arma.Cantidad} | Daño: {arma.Danio} | Val: {arma.ValorCreditos * arma.Cantidad} cr.");
        }

        public void Visitar(Medicamento medicamento)
        {
            string estado = medicamento.EstaVencido ? "VENCIDO" : "OK";
            _sb.AppendLine($"[MEDICAMENTO] {medicamento.Nombre} x{medicamento.Cantidad} | Cura: +{medicamento.PuntosCuracion} HP | Estado: {estado}");
        }

        public void Visitar(Herramienta herramienta)
        {
            _sb.AppendLine($"[HERRAMIENTA] {herramienta.Nombre} x{herramienta.Cantidad} | Durabilidad: {herramienta.NivelDurabilidad}%");
        }
    }
}