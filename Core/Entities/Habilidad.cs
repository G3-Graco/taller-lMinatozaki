using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Core.Interfaces.Entities;

namespace Core.Entities
{
    public class Habilidad : IHabilidad
    {
        public int id { get; set; }
        public string nombre { get; set; } = string.Empty;
        public int ataqueBase { get; set; }
        public int nivelRequerido { get; set; }
        public int costoMana { get; set; }
        public int costoEnergia { get; set; }
        public int costoSalud { get; set; }
        public double tiempoEnfriamiento { get; set; }
        [JsonIgnore]
        public List<Personaje> personajes { get; set; } = [];

    }
}