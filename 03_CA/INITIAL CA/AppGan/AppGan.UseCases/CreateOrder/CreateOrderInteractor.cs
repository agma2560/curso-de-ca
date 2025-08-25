using AppGan.Entities.Exceptions;
using AppGan.Entities.Interfaces;
using AppGan.Entities.POCOEntities;
using MediatR;

namespace AppGan.UseCases.CreateOrder
{
    public class CreateOrderInteractor : IRequestHandler<CreateOrderInputPort, int>
    {
        readonly IOrderRepository _orderRepository;
        readonly IOrderDetailRepository _orderDetailRepository;
        readonly IUnitOfWork _unitOfWork;

        public CreateOrderInteractor(
            IOrderRepository orderRepository,
            IOrderDetailRepository orderDetailRepository,
            IUnitOfWork unitOfWork) =>
            (_orderRepository, _orderDetailRepository, _unitOfWork) =
            (orderRepository, orderDetailRepository, unitOfWork);

        public async Task<int> Handle(CreateOrderInputPort request, 
            CancellationToken cancellationToken)
        {
            Order order = new Order
            {
                CustomerId = request.CustomerId,
                OrderDate = DateTime.Now,
                ShipAddress = request.ShipAddress,
                ShipCity = request.ShipCity,
                ShipCountry = request.ShipCountry,
                ShipPostalCode = request.ShipPostalCode,
                ShippingType = Entities.Enums.ShippingType.Road,
                DiscountType = Entities.Enums.DiscountType.Percentage,
                Discount = 10
            };

            _orderRepository.CreateOrder(order);

            foreach (var item in request.OrderDetails)
            {
                _orderDetailRepository.Create(
                    new OrderDetail
                    {
                        Order = order,
                        ProductId = item.ProductId,
                        UnitPrice = item.UnitPrice,
                        Quantity = item.Quantity
                    });
            }
            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new GeneralException("Error al crear la orden", ex.Message);
            }

            return order.Id;
        }
    }
}
