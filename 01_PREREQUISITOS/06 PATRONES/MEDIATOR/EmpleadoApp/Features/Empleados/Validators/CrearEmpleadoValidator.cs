using EmpleadoApp.Features.Empleados.Commands;
using FluentValidation;

namespace EmpleadoApp.Features.Empleados.Validators
{
    public class CrearEmpleadoValidator : AbstractValidator<CrearEmpleadoCommand>
    {
        public CrearEmpleadoValidator()
        {
            RuleFor(e => e.Nombre)
                .NotEmpty().WithMessage("No deje el nombre vac{io")
                .MinimumLength(5);
            RuleFor(c => c.Cargo)
                .NotEmpty().WithMessage("Proporcione un cargo");
            RuleFor(s => s.Salario)
                .GreaterThan(0)
                .WithMessage("Salario debe ser mayor que cero (0)");
        }
    }
}
