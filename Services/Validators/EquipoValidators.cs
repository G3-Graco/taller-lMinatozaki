using Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Services.Validators
{
    public class EquipoValidators : AbstractValidator<Equipo>
    {
        public EquipoValidators()
        {
            //RuleFor(x => x.casco)
            //    .NotEmpty()
            //    .MaximumLength(255)
            //    .WithMessage("El casco es obligatorio y no debe exceder los 255 caracteres");

            //RuleFor(x => x.armadura)
            //    .NotEmpty()
            //    .MaximumLength(255)
            //    .WithMessage("La armadura es obligatoria y no debe exceder los 255 caracteres");

            //RuleFor(x => x.arma1)
            //    .MaximumLength(255)
            //    .WithMessage("El arma 1 no debe exceder los 255 caracteres");

            //RuleFor(x => x.arma2)
            //    .MaximumLength(255)
            //    .WithMessage("El arma 2 no debe exceder los 255 caracteres");

            //RuleFor(x => x.guanteletes)
            //    .MaximumLength(255)
            //    .WithMessage("Los guanteletes no deben exceder los 255 caracteres");

            //RuleFor(x => x.grebas)
            //    .MaximumLength(255)
            //    .WithMessage("Las grebas no deben exceder los 255 caracteres");
        }
    }
}