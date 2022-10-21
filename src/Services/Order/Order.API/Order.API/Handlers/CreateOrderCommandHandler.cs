using MediatR;
using Order.API.Commands;
using Order.API.Services;

namespace Order.API.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Models.Order>
    {
        private readonly FakeDataSourceService _fakeDataSourceService;
        public CreateOrderCommandHandler(FakeDataSourceService fakeDataSourceService) 
        { 
            _fakeDataSourceService = fakeDataSourceService;
        }
        public async Task<Models.Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            await _fakeDataSourceService.AddOrder(request.Order);
            return request.Order;
        }
    }
}
