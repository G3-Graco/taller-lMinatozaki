using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class PersonajeMision
    {
        public int PersonajeId { get; set; }
        public int MisionId { get; set; }

        public virtual Personaje? Personaje { get; set; }

        public virtual Mision? Mision { get; set; }

        // Atributos adicionales
        public int Progreso { get; set; } // Porcentaje de la misión completado (0-100)
        public string Estado { get; set; } = string.Empty;  // Ejemplo: "Pendiente", "En curso", "Completada"
    }
}
