using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Ranura
    {
        public int id { get; set; }
        public int tipoObjetoId { get; set; }
        public int? objetoId { get; set; }
        public virtual TipoObjeto? tipoObjeto { get; set; }
        public virtual Objeto? objeto { get; set; }
    }
}
