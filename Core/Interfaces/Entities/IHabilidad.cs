using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Interfaces.Entities
{
    public interface IHabilidad
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int ataqueBase { get; set; }
        public int nivelRequerido { get; set; }
        public int costoMana { get; set; }
        public int costoEnergia { get; set; }
        public int costoSalud { get; set; }
        public double tiempoEnfriamiento { get; set; }
    }
}