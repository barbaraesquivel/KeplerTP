namespace Kepler7.Core.Patrones.Creacionales.Prototype
{
    public class LaboratorioClonacion
    {
        private Dictionary<string, TripulanteClonable> prototipos = new Dictionary<string, TripulanteClonable>();

        public int Recursos { get; set; }
        public int CostoClonacion { get; set; }

        public LaboratorioClonacion(int recursos, int costoClonacion)
        {
            Recursos = recursos;
            CostoClonacion = costoClonacion;
        }

        public void RegistrarPrototipo(string clave, TripulanteClonable prototipo)
        {
            prototipos[clave] = prototipo;
        }

        public List<string> ObtenerClaves()
        {
            return new List<string>(prototipos.Keys);
        }

        public TripulanteClonable Fabricar(string clave)
        {
            if (!prototipos.ContainsKey(clave) || Recursos < CostoClonacion)
            {
                return null;
            }
            Recursos -= CostoClonacion;
            return prototipos[clave].Clonar();
        }
    }
}
