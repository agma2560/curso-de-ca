using AppGan.UseCasesDTOs.CreateOrder;
using MediatR;

namespace AppGan.UseCases.CreateOrder
{
    public class CreateOrderInputPort : CreateOrderParams, IRequest<int>
    {
    }
}
