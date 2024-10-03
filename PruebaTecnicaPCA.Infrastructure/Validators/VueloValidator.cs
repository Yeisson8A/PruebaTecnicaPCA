using FluentValidation;
using PruebaTecnicaPCA.Core.Entities;

namespace PruebaTecnicaPCA.Infrastructure.Validators
{
    public class VueloValidator : AbstractValidator<Vuelo>
    {
        public VueloValidator() {
            // Validación campo origen obligatorio
            RuleFor(vuelo => vuelo.Origen).NotNull().WithMessage("El origen del vuelo es obligatorio");
            // Validación campo destino obligatorio
            RuleFor(vuelo => vuelo.Destino).NotNull().WithMessage("El destino del vuelo es obligatorio");
            // Validación campo fecha salida obligatoria, mayor o igual a la fecha actual
            RuleFor(vuelo => vuelo.FechaSalida.Date).NotNull().WithMessage("La fecha de salida del vuelo es obligatoria")
                                                .GreaterThanOrEqualTo(DateTime.Now.Date).WithMessage("La fecha de salida del vuelo debe ser igual o posterior a la fecha actual");
            // Validación campo fecha salida obligatoria, mayor o igual a la fecha actual
            RuleFor(vuelo => vuelo.FechaLlegada.Date).NotNull().WithMessage("La fecha de llegada del vuelo es obligatoria")
                                                .GreaterThanOrEqualTo(DateTime.Now.Date).WithMessage("La fecha de llegada del vuelo debe ser igual o posterior a la fecha actual");
            // Validación campo aerolinea obligatorio
            RuleFor(vuelo => vuelo.Aerolinea).NotNull().WithMessage("La aerolínea del vuelo es obligatoria")
                                            .Length(1, 200).WithMessage("La aerolínea debe tener una longitud máxima de 200 caracteres");
            // Validación campo origen obligatorio
            RuleFor(vuelo => vuelo.Precio).NotNull().WithMessage("El precio del vuelo es obligatorio")
                                            .GreaterThan(0).WithMessage("El precio del vuelo debe ser mayor a 0");
        }
    }
}
