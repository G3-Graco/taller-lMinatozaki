using Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validators
{
    public class PersonajeActualizarValidators : AbstractValidator<Personaje>
    {
        public PersonajeActualizarValidators()
        {


            RuleFor(x => x.nombre)
                .NotEmpty()
                .MaximumLength(255);

        }
    }
}
