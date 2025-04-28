using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces.Entities;

namespace Core.Entities
{
    public class Personaje : IPersonaje
    {
        public int id { get; set; }
        public string nombre { get; set; } = string.Empty;
        public int saludId { get; set; }
        public int energiaId { get; set; }
        public int fuerzaId { get; set; }
        public int inteligenciaId { get; set; }
        public int agilidadId { get; set; }
        public int nivel { get; set; }
        public int defensaId { get; set; }
        public List<Habilidad> habilidades { get; set; } = new List<Habilidad>();
        public int experiencia { get; set; }
        public int? tipoId { get; set; }
        public int? equipoId { get; set; }
        public int? ubicacionId { get; set; }
        public virtual TipoPersonaje? tipo { get; set; } 
        public virtual Equipo? equipo { get; set; } 
        public virtual Ubicacion? ubicacion { get; set; }

        public virtual Estadistica? salud { get; set; } = new();
        public virtual Estadistica? energia { get; set; } = new();
        public virtual Estadistica? fuerza { get; set; } = new();
        public virtual Estadistica? inteligencia { get; set; } = new();
        public virtual Estadistica? defensa { get; set; } = new();
        public virtual Estadistica? agilidad { get; set; } = new();
        public virtual List<PersonajeMision> PersonajeMisiones { get; set; } = new();

    }
}