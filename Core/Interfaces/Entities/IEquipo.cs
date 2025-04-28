using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Interfaces.Entities
{
    public interface IEquipo
    {
        public int id { get; set; }
        public Ranura casco { get; set; }
        public Ranura armadura { get; set; }
        public Ranura arma1 { get; set; }
        public Ranura arma2 { get; set; }
        public Ranura guanteletes { get; set; }
        public Ranura grebas { get; set; }
    }
}