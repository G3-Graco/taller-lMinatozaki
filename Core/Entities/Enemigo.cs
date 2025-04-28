using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces.Entities;

namespace Core.Entities
{
    public class Enemigo : IEnemigo
    {
        public int id { get; set; }
        public string nombre { get; set; } = string.Empty;
        public int nivelAmenaza { get; set; }
        public List<string> recompensas { get; set; } = new List<string>();
        public List<Habilidad> habilidades { get; set; } = new List<Habilidad>();
        public int salud { get; set; }
        public int energia { get; set; }
        public int fuerza { get; set; }
        public int defensa { get; set; }
        public int inteligencia { get; set; }
        public int agilidad { get; set; }
    }
}