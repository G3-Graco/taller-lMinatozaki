using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTO;
using Core.Entities;
using FluentValidation;

namespace Services.Validators
{
    public class PersonajeValidators : AbstractValidator<Personaje>
    {
        public PersonajeValidators()
        {

            RuleFor(x => x.experiencia)
                .LessThanOrEqualTo(Personaje => Personaje.nivel * 10)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.nivel)
                .LessThanOrEqualTo(99)
                .GreaterThanOrEqualTo(Personaje => Personaje.nivel)
                .WithMessage("nivel incorrecto");

            RuleFor(x => x.nombre)
                .NotEmpty()
                .MaximumLength(255);

            //RuleFor(personaje => personaje.salud.valor)
            //    .GreaterThanOrEqualTo(10);



        }

    }

    public class PersonajeDTOValidators : AbstractValidator<PersonajeDTO>
    {
        public PersonajeDTOValidators()
        {

            RuleFor(x => x.experiencia)
                .LessThanOrEqualTo(Personaje => Personaje.nivel * 10)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.nivel)
                .LessThanOrEqualTo(99)
                .GreaterThanOrEqualTo(Personaje => Personaje.nivel)
                .WithMessage("nivel incorrecto");

            RuleFor(x => x.nombre)
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(personaje => personaje.salud)
                .GreaterThanOrEqualTo(10);



        }

    }
}