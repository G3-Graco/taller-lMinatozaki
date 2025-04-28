using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Interfaces.Entities
{
    public interface IEnemigo
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int nivelAmenaza { get; set; }
        public List<string> recompensas { get; set; }
        public List<Habilidad> habilidades { get; set; }
        public int salud { get; set; }
        public int energia { get; set; }
        public int fuerza { get; set; }
        public int defensa { get; set; }
        public int inteligencia { get; set; }
        public int agilidad { get; set; }
    }
}