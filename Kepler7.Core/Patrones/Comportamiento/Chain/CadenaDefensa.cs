namespace Kepler7.Core.Patrones.Comportamiento.Chain
{
    public class CadenaDefensa
    {
        private List<IManejadorDanio> eslabones = new List<IManejadorDanio>();

        public List<IManejadorDanio> Eslabones
        {
            get { return eslabones; }
        }

        public void Agregar(IManejadorDanio eslabon)
        {
            eslabones.Add(eslabon);
            Enlazar();
        }

        public void Quitar(IManejadorDanio eslabon)
        {
            eslabones.Remove(eslabon);
            Enlazar();
        }

        public void Mover(IManejadorDanio eslabon, int nuevaPosicion)
        {
            if (!eslabones.Contains(eslabon) || nuevaPosicion < 0 || nuevaPosicion >= eslabones.Count)
            {
                return;
            }
            eslabones.Remove(eslabon);
            eslabones.Insert(nuevaPosicion, eslabon);
            Enlazar();
        }

        public ResultadoDanio Procesar(Danio danio)
        {
            if (eslabones.Count > 0)
            {
                eslabones[0].Manejar(danio);
            }
            return danio.Resultado;
        }

        private void Enlazar()
        {
            for (int i = 0; i < eslabones.Count; i++)
            {
                if (i + 1 < eslabones.Count)
                {
                    eslabones[i].Siguiente = eslabones[i + 1];
                }
                else
                {
                    eslabones[i].Siguiente = null;
                }
            }
        }
    }
}
