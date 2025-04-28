using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Objetivo
    {
        public int id { get; set; }
        public int misionId { get; set; }
        public string descripcion { get; set; } = string.Empty;
        public int valorObjetivo { get; set; }
        public int valorActual { get; set; }
        public bool completado { get; set; }
        
    }
}
