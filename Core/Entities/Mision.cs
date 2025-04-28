using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces.Entities;

namespace Core.Entities
{
    public class Mision : IMision
    {
        public int id { get; set; }
        public string nombre { get; set; } = string.Empty;
        public List<string> recompensas { get; set; } = new List<string>();
        public virtual List<Objetivo> objetivos { get; set; } = new();
        public virtual List<PersonajeMision> PersonajeMisiones { get; set; } = new();
    }
}