using System;
using System.Collections.Generic;
using Kepler7.Core.Modelo;

namespace Kepler7.Core.Patrones.Estructurales.Flyweight
{
    public class ResultadoComparacion
    {
        public long MemoriaConFlyweightBytes { get; set; }
        public long MemoriaSinFlyweightBytes { get; set; }
        public int ObjetosEspecieCreados { get; set; }
        public int TotalTripulantes { get; set; }

        public double MemoriaConMB => MemoriaConFlyweightBytes / (1024.0 * 1024.0);
        public double MemoriaSinMB => MemoriaSinFlyweightBytes / (1024.0 * 1024.0);
        public double AhorroPorcentaje => ((double)(MemoriaSinFlyweightBytes - MemoriaConFlyweightBytes) / MemoriaSinFlyweightBytes) * 100;
    }

    public static class DemostradorFlyweight
    {
        public static ResultadoComparacion EjecutarDemostracion(int cantidadTripulantes = 10000)
        {
            var datosEspecies = new (string Nombre, string Origen, string Habilidad)[]
            {
                ("Humano", "Tierra", "Adaptabilidad"),
                ("Zetiano", "Zeta Reticuli", "Telepatía"),
                ("Andromedano", "Andrómeda", "Camuflaje"),
                ("Martiano", "Marte", "Resistencia"),
                ("Cygnian", "Cygnus X-1", "Visión Nocturna")
            };

            // 1. Medición CON Flyweight
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            long memoriaInicialCon = GC.GetTotalMemory(true);

            List<Tripulante> tripulantesCon = new List<Tripulante>();
            for (int i = 0; i < cantidadTripulantes; i++)
            {
                var datos = datosEspecies[i % 5];
                EspecieFlyweight especie = EspecieFactory.ObtenerEspecie(datos.Nombre, datos.Origen, datos.Habilidad);

                // Parámetros: legajo, nombre, vidaMax, ataqueBase, especie
                tripulantesCon.Add(new Tripulante(i + 1, $"Tripulante_{i + 1}", 100, 10, especie));
            }

            long memoriaFinalCon = GC.GetTotalMemory(true);
            long bytesCon = memoriaFinalCon - memoriaInicialCon;

            // 2. Medición SIN Flyweight
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            long memoriaInicialSin = GC.GetTotalMemory(true);

            List<TripulanteSinPatron> tripulantesSin = new List<TripulanteSinPatron>();
            for (int i = 0; i < cantidadTripulantes; i++)
            {
                var datos = datosEspecies[i % 5];

                // Parámetros: legajo, nombre, vidaMax, ataqueBase, especie, origen, habilidad
                tripulantesSin.Add(new TripulanteSinPatron(
                    i + 1,
                    $"Tripulante_{i + 1}",
                    100,
                    10,
                    datos.Nombre,
                    datos.Origen,
                    datos.Habilidad
                ));
            }

            long memoriaFinalSin = GC.GetTotalMemory(true);
            long bytesSin = memoriaFinalSin - memoriaInicialSin;

            return new ResultadoComparacion
            {
                TotalTripulantes = cantidadTripulantes,
                ObjetosEspecieCreados = EspecieFactory.CantidadEspeciesEnMemoria,
                MemoriaConFlyweightBytes = Math.Max(bytesCon, 1),
                MemoriaSinFlyweightBytes = Math.Max(bytesSin, 1)
            };
        }
    }
}