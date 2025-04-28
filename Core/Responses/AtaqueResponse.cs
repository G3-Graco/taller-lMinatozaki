using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Responses
{
    public class AtaqueResponse
    {
        public Personaje personaje {get;set;}
        public Enemigo enemigo {get;set;}
        public string mensaje {get; set;}
    }
}