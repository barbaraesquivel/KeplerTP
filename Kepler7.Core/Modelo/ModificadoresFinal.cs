namespace Kepler7.Core.Modelo
{
    // Bonus y penalidades ya resueltos para el combate final contra K-7
    public class ModificadoresFinal
    {
        // Comandante
        public int VidaExtra { get; set; }
        public int DanioExtra { get; set; }
        public int ArmaduraExtra { get; set; }
        public int EscudoInicial { get; set; }
        public int RecursosExtra { get; set; }
        public int DanioContraJefe { get; set; }
        public int CuracionesExtra { get; set; }
        public bool DisparoEspecial { get; set; }

        // K-7
        public int JefeAtaqueExtra { get; set; }
        public int JefeVidaExtra { get; set; }
        public bool PuedeHackearIA { get; set; }

        // Estrategia estudiada: sus ataques hacen la mitad de daño
        public string IaAnalizada { get; set; }

        // Una línea por decisión explicando su efecto
        public List<string> Resumen { get; set; } = new List<string>();

        // Las mismas decisiones con su puntaje y consejo (para el epílogo)
        public List<EfectoDecision> Efectos { get; set; } = new List<EfectoDecision>();

        // Las decisiones que más ayudaron, de mayor a menor
        public List<EfectoDecision> MejoresDecisiones(int cantidad)
        {
            List<EfectoDecision> ordenadas = new List<EfectoDecision>();
            foreach (EfectoDecision efecto in Efectos)
            {
                if (efecto.Puntos > 0)
                {
                    ordenadas.Add(efecto);
                }
            }
            ordenadas.Sort((a, b) => b.Puntos.CompareTo(a.Puntos));
            if (ordenadas.Count > cantidad)
            {
                ordenadas.RemoveRange(cantidad, ordenadas.Count - cantidad);
            }
            return ordenadas;
        }

        // Las decisiones que no ayudaron o perjudicaron (tienen consejo)
        public List<EfectoDecision> DecisionesAMejorar()
        {
            List<EfectoDecision> lista = new List<EfectoDecision>();
            foreach (EfectoDecision efecto in Efectos)
            {
                if (efecto.Consejo != "")
                {
                    lista.Add(efecto);
                }
            }
            return lista;
        }
    }
}
