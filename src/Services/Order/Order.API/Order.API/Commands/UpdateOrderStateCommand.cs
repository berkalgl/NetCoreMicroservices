using MediatR;

namespace Order.API.Commands
{
    public class UpdateOrderStateCommand : IRequest<Models.Order>
    {
        public int OrderId { get; set; }
        public Models.OrderState OrderState { get; set; }
    }
}
