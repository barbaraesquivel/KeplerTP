namespace Kepler7.Core.Patrones.Estructurales.Flyweight
{
    public class ResultadoComparacion
    {
        public int TotalTripulantes { get; set; }
        public int EspeciesConFlyweight { get; set; }
        public int EspeciesSinFlyweight { get; set; }
        public long MemoriaConFlyweightBytes { get; set; }
        public long MemoriaSinFlyweightBytes { get; set; }

        public double MemoriaConMB => MemoriaConFlyweightBytes / (1024.0 * 1024.0);
        public double MemoriaSinMB => MemoriaSinFlyweightBytes / (1024.0 * 1024.0);
        public double AhorroPorcentaje => MemoriaSinFlyweightBytes > 0
            ? ((double)(MemoriaSinFlyweightBytes - MemoriaConFlyweightBytes) / MemoriaSinFlyweightBytes) * 100
            : 0;
    }

    public static class DemostradorFlyweight
    {
        // 5 especies exactas según la consigna
        public static readonly (string Nombre, string Color, string Planeta, string Dieta)[] EspeciesDisponibles = new[]
        {
            ("Humano", "Cálido", "Tierra", "Omnívoro"),
            ("Zetiano", "Gris", "Zeta Reticuli", "Autótrofo"),
            ("Andromedano", "Azul", "Andrómeda", "Herbívoro"),
            ("Martiano", "Rojo", "Marte", "Carnívoro"),
            ("Cygnian", "Dorado", "Cygnus X-1", "Sintético")
        };

        public static ResultadoComparacion EjecutarComparacion(FabricaEspecies fabrica, int cantidad = 10000)
        {
            string[] rangos = { "Capitán", "Teniente", "Oficial", "Científico", "Ingeniero", "Médico" };

            // 1. CON Flyweight (compartiendo instancias de IEspecie mediante la fábrica)
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            long memInicioCon = GC.GetTotalMemory(true);

            List<Tripulante> tripulantesCon = new List<Tripulante>(cantidad);
            for (int i = 0; i < cantidad; i++)
            {
                var espData = EspeciesDisponibles[i % EspeciesDisponibles.Length];
                IEspecie especie = fabrica.ObtenerEspecie(espData.Nombre, espData.Color, espData.Planeta, espData.Dieta);
                string rango = rangos[i % rangos.Length];
                tripulantesCon.Add(new Tripulante(i + 1, $"Tripulante_{i + 1}", rango, especie));
            }

            long memFinCon = GC.GetTotalMemory(true);
            long bytesCon = Math.Max(memFinCon - memInicioCon, 1);

            // 2. SIN Flyweight (creando un objeto Especie nuevo por cada tripulante)
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            long memInicioSin = GC.GetTotalMemory(true);

            List<Tripulante> tripulantesSin = new List<Tripulante>(cantidad);
            for (int i = 0; i < cantidad; i++)
            {
                var espData = EspeciesDisponibles[i % EspeciesDisponibles.Length];
                // SIN patrón: se instancia una especie nueva para cada uno (10.000 objetos)
                IEspecie especieDuplicada = new Especie(espData.Nombre, espData.Color, espData.Planeta, espData.Dieta);
                string rango = rangos[i % rangos.Length];
                tripulantesSin.Add(new Tripulante(i + 1, $"Tripulante_{i + 1}", rango, especieDuplicada));
            }

            long memFinSin = GC.GetTotalMemory(true);
            long bytesSin = Math.Max(memFinSin - memInicioSin, 1);

            return new ResultadoComparacion
            {
                TotalTripulantes = cantidad,
                EspeciesConFlyweight = fabrica.CantidadEspeciesCreadas, // 5 especies
                EspeciesSinFlyweight = cantidad,                        // 10.000 especies duplicadas
                MemoriaConFlyweightBytes = bytesCon,
                MemoriaSinFlyweightBytes = bytesSin
            };
        }
    }
}
