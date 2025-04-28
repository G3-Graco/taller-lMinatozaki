using Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Services.Validators
{
    public class MisionValidators : AbstractValidator<Mision>
    {
        public MisionValidators()
        {
            RuleFor(x => x.nombre)
                .NotEmpty()
                .MaximumLength(255);

            //RuleFor(x => x.estado)
            //    .Must(x => x == 'P' || x == 'C' || x == 'F') // P: pendiente, C: en curso y F: finalizada
            //    .WithMessage("El estado debe ser 'P', 'C' o 'F'");

            RuleFor(x => x.objetivos)
                .NotNull()
                .Must(x => x.Count > 0)
                .WithMessage("Debe haber al menos un objetivo");

            RuleFor(x => x.recompensas)
                .NotNull()
                .Must(x => x.Count > 0)
                .WithMessage("Debe haber al menos una recompensa");
        }
    }
}