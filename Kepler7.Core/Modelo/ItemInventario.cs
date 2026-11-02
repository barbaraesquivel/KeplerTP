using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kepler7.Core.Patrones.Comportamiento.Visitor;

namespace Kepler7.Core.Modelo
{
    // Clase Base abstracta para los Ítems
    public abstract class ItemInventario
    {
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public double ValorCreditos { get; set; }

        protected ItemInventario(string nombre, int cantidad, double valorCreditos)
        {
            Nombre = nombre;
            Cantidad = cantidad;
            ValorCreditos = valorCreditos;
        }

        // Método clave del patrón: Aceptar al Visitor
        public abstract void Aceptar(IVisitorInventario visitor);
    }

    public class Arma : ItemInventario
    {
        public int Danio { get; set; }
        public double Calibre { get; set; }

        public Arma(string nombre, int cantidad, double valorCreditos, int danio, double calibre)
            : base(nombre, cantidad, valorCreditos)
        {
            Danio = danio;
            Calibre = calibre;
        }

        public override void Aceptar(IVisitorInventario visitor)
        {
            visitor.Visitar(this); // Doble Dispatch
        }
    }

    public class Medicamento : ItemInventario
    {
        public int PuntosCuracion { get; set; }
        public bool EstaVencido { get; set; }

        public Medicamento(string nombre, int cantidad, double valorCreditos, int puntosCuracion, bool estaVencido)
            : base(nombre, cantidad, valorCreditos)
        {
            PuntosCuracion = puntosCuracion;
            EstaVencido = estaVencido;
        }

        public override void Aceptar(IVisitorInventario visitor)
        {
            visitor.Visitar(this);
        }
    }

    public class Herramienta : ItemInventario
    {
        public int NivelDurabilidad { get; set; } // 0 a 100

        public Herramienta(string nombre, int cantidad, double valorCreditos, int nivelDurabilidad)
            : base(nombre, cantidad, valorCreditos)
        {
            NivelDurabilidad = nivelDurabilidad;
        }

        public override void Aceptar(IVisitorInventario visitor)
        {
            visitor.Visitar(this);
        }
    }
}