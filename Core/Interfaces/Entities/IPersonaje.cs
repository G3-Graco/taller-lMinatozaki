using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.Entities
{
    public interface IPersonaje
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int saludId { get; set; }
        public int energiaId { get; set; }
        public int fuerzaId { get; set; }
        public int inteligenciaId { get; set; }
        public int agilidadId { get; set; }
        public int nivel { get; set; }
        public List<Habilidad> habilidades { get; set; }
    }
}