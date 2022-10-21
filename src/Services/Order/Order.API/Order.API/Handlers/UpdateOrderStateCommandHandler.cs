using MediatR;
using Order.API.Commands;
using Order.API.Services;

namespace Order.API.Handlers
{
    public class UpdateOrderStateCommandHandler : IRequestHandler<UpdateOrderStateCommand, Models.Order>
    {
        private readonly FakeDataSourceService _fakeDateSourceService;
        public UpdateOrderStateCommandHandler(FakeDataSourceService fakeDateSourceService)
        {
            _fakeDateSourceService = fakeDateSourceService;
        }

        public async Task<Models.Order> Handle(UpdateOrderStateCommand request, CancellationToken cancellationToken)
        {
            return await _fakeDateSourceService.UpdateOrderState(request.OrderId, request.OrderState);
        }
    }
}
