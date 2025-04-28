using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces.Entities;

namespace Core.Entities
{
    public class Objeto : IObjeto
    {
        public int id { get; set; }
        public string nombre { get; set; } = string.Empty;
        public string descripcion { get; set; } = string.Empty;
        public int tipoObjetoId { get; set; }
        public List<string> estadisticas { get; set; } = new List<string>();
        public virtual TipoObjeto? tipoObjeto { get; set; }
    }
}