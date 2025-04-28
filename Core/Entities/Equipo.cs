using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces.Entities;

namespace Core.Entities
{
    public class Equipo : IEquipo
    {
        public int id { get; set; }
        public int cascoId { get; set; } //1
        public int armaduraId { get; set; }//2
        public int arma1Id { get; set; }//3
        public int arma2Id { get; set; } //3
        public int guanteletesId { get; set; }//4
        public int grebasId { get; set; }//5
        public virtual Ranura? casco { get; set; } = new(); //1
        public virtual Ranura? armadura { get; set; } = new();//2
        public virtual Ranura? arma1 { get; set; } = new();//3
        public virtual Ranura? arma2 { get; set; } = new(); //3
        public virtual Ranura? guanteletes { get; set; } = new();//4
        public virtual Ranura? grebas { get; set; } = new();//5
    }
}