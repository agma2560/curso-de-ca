using FluentValidation;

namespace AppGan.UseCases.CreateOrder
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderInputPort>
    {
        public CreateOrderValidator()
        {
            RuleFor(c => c.CustomerId).NotEmpty()
                .WithMessage("El ID del cliente debe ser proporcionado");
            RuleFor(c => c.ShipAddress).NotEmpty()
                .WithMessage("Debe proporcionar una dirección");
            RuleFor(c => c.ShipCity).NotEmpty()
                .MinimumLength(5)
                .WithMessage("Debe proporcionar un nombre de ciudad,    ");
            RuleFor(c => c.ShipCountry).NotEmpty()
                .MinimumLength(5)
                .WithMessage("Debe proporcionar un nombre de país, mínimo 5 caracteres");
            RuleFor(c => c.OrderDetails)
                .Must(d => d != null && d.Any())
                .WithMessage("Registre los productos de la orden");
        }
    }
}
