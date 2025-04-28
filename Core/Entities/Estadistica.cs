using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Estadistica
    {
        public int id { get; set; }
        public int tipoEstadisticaId { get; set; }
        public int valor { get; set; }
        public TipoEstadistica? tipoEstadistica { get; set; }
    }
}
