using Core.Entities;
using FluentValidation;

namespace Services.Validators
{
    public class UbicacionValidators : AbstractValidator<Ubicacion>
    {
        public UbicacionValidators()
        {
            RuleFor(x => x.nombre)
                .NotEmpty()
                .MaximumLength(255)
                .WithMessage("El nombre es obligatorio y no debe exceder los 255 caracteres");

            RuleFor(x => x.descripcion)
                .NotEmpty()
                .MaximumLength(255)
                .WithMessage("La descripción es obligatoria y no debe exceder los 255 caracteres");

            RuleFor(x => x.clima)
                .NotEmpty()
                .MaximumLength(255)
                .WithMessage("El clima es obligatorio y no debe exceder los 255 caracteres");
        }
    }
}