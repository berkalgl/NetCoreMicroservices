using Order.API.Models;

namespace Order.API.Services
{
    public class FakeDataSourceService
    {
        private static List<Models.Order> Orders { get; set; } = new List<Models.Order>();
        public FakeDataSourceService()
        {
            Orders = new List<Order.API.Models.Order>
            {
                new Models.Order(){CustomerId = 1, TotalPrice=5000},
                new Models.Order(){CustomerId = 2, TotalPrice=6000},
                new Models.Order(){CustomerId = 3, TotalPrice=7000}
            };
        }
        public async Task<IEnumerable<Models.Order>> GetOrdersAsync() => await Task.FromResult(Orders);
        public async Task AddOrder(Models.Order order)
        {
            Orders.Add(order);
            await Task.CompletedTask;
        }
        public async Task<Models.Order> UpdateOrderState(int orderId, OrderState state)
        {
            var order = Orders.Find(x => x.Id == orderId);

            if (order == null)
                throw new Exception("Order Could not be found ! ");

            order.OrderState = state;
            await Task.CompletedTask;
            return order;

        }
    }
}
