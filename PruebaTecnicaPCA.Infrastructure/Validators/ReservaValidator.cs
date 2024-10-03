using FluentValidation;
using PruebaTecnicaPCA.Core.Entities;

namespace PruebaTecnicaPCA.Infrastructure.Validators
{
    public class ReservaValidator : AbstractValidator<Reserva>
    {
        public ReservaValidator() {
            // Validación campo vuelo id obligatorio
            RuleFor(reserva => reserva.IdVuelo).NotNull().WithMessage("El id del vuelo es obligatorio");
            // Validación campo nombre usuario obligatorio
            RuleFor(reserva => reserva.NombreUsuario).NotNull().WithMessage("El nombre del usuario es obligatorio")
                                                    .Length(1, 200).WithMessage("El nombre del usuario debe tener una longitud máxima de 200 caracteres");
            // Validación campo apellido usuario obligatorio
            RuleFor(reserva => reserva.ApellidoUsuario).NotNull().WithMessage("El apellido del usuario es obligatorio")
                                                    .Length(1, 200).WithMessage("El apellido del usuario debe tener una longitud máxima de 200 caracteres");
            // Validación campo origen obligatorio
            RuleFor(reserva => reserva.CorreoUsuario).NotNull().WithMessage("El correo electrónico del usuario es obligatorio")
                                                    .Length(1, 1000).WithMessage("El correo electrónico del usuario debe tener una longitud máxima de 1000 caracteres");
        }
    }
}
