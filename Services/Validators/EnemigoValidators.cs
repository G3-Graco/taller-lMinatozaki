using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using FluentValidation;

namespace Services.Validators
{
    public class EnemigoValidators : AbstractValidator<Enemigo>
    {
        public EnemigoValidators(){
            RuleFor(x => x.salud)
                .LessThanOrEqualTo(100)
                .GreaterThanOrEqualTo(Enemigo => Enemigo.salud);

            RuleFor(x => x.energia)
                .LessThanOrEqualTo(100)
                .GreaterThanOrEqualTo(Enemigo => Enemigo.energia);
            
            RuleFor(x => x.fuerza)
                .LessThanOrEqualTo(100)
                .GreaterThanOrEqualTo(Enemigo => Enemigo.fuerza);
            
            RuleFor(x => x.inteligencia)
                .LessThanOrEqualTo(100)
                .GreaterThanOrEqualTo(Enemigo => Enemigo.inteligencia);

            RuleFor(x => x.agilidad)
                .LessThanOrEqualTo(100)
                .GreaterThanOrEqualTo(Enemigo => Enemigo.agilidad)
                .WithMessage("El valor de la agilidad esta mal, por favor vovler a ingresar");

           
            RuleFor(x => x.nivelAmenaza)
                .LessThanOrEqualTo(99)
                .GreaterThanOrEqualTo(Enemigo => Enemigo.nivelAmenaza)
                .WithMessage("nivel incorrecto");
                
            RuleFor(x => x.nombre)
                .NotEmpty()
                .MaximumLength(255);


        }
    }
}