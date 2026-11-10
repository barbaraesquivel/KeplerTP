using System;
using System.Collections.Generic;

namespace Kepler7.Core.Patrones.Comportamiento.Visitor
{
    // Visitante 3: Aplica toxina alienígena modificando el estado de cada ítem según su tipo
    public class AplicadorVeneno : IVisitor
    {
        private List<string> _acciones = new List<string>();

        public void Visitar(Arma arma)
        {
            arma.TieneVeneno = true;
            arma.Danio += 15; // El veneno aumenta el poder letal del arma
            _acciones.Add($"[ARMA] {arma.Nombre}: Filo/munición untado en veneno (+15 pts daño).");
        }

        public void Visitar(Pocion pocion)
        {
            pocion.EsVenenosa = true;
            pocion.PuntosCuracion = 0; // Se convierte en veneno letal
            _acciones.Add($"[POCIÓN] {pocion.Nombre}: Contaminada con toxina. Ahora es veneno.");
        }

        public void Visitar(Armadura armadura)
        {
            armadura.ResistenteAlVeneno = true; // La armadura reacciona sellando sus placas
            _acciones.Add($"[ARMADURA] {armadura.Nombre}: Se aplicó recubrimiento anticorrosivo (Inmune al veneno).");
        }

        public string ObtenerResultado()
        {
            return "=== APLICADOR DE VENENO Y TOXINAS ===" + Environment.NewLine +
                   string.Join(Environment.NewLine, _acciones) + Environment.NewLine +
                   Environment.NewLine +
                   "¡Cada tipo de ítem reaccionó de manera distinta mediante Doble Dispatch!";
        }
    }
}
