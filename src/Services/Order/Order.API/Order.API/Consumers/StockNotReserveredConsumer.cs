using MassTransit;
using MessagesAndEvents.Events;

namespace Order.API.Consumers
{
    public class StockNotReserveredConsumer : IConsumer<StockNotReserved>
    {
        private readonly ILogger<StockNotReserveredConsumer> _logger;
        public StockNotReserveredConsumer(ILogger<StockNotReserveredConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<StockNotReserved> context)
        {
            _logger.LogInformation($"Stock of {context.Message.OrderId} Not Reserved...");

            return Task.CompletedTask;
        }
    }
}
