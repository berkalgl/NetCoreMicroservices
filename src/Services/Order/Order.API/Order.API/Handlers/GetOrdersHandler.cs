using MediatR;
using Order.API.Queries;
using Order.API.Services;

namespace Order.API.Handlers
{
    public class GetOrdersHandler : IRequestHandler<GetOrdersQuery, IEnumerable<Models.Order>>
    {
        private readonly FakeDataSourceService _fakeDataSource;
        public GetOrdersHandler(FakeDataSourceService fakeDataSource)
        {
            _fakeDataSource = fakeDataSource;
        }
        public async Task<IEnumerable<Models.Order>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            return await _fakeDataSource.GetOrdersAsync();
        }
    }
}
