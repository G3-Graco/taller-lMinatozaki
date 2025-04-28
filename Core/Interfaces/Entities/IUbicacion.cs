using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Interfaces.Entities
{
    public interface IUbicacion
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; } 
        public string clima { get; set; } 
    }
}