using MassTransit;
using MessagesAndEvents.Events;

namespace Stock.API.Consumers
{
    public class OrderCreatedConsumer : IConsumer<OrderCreated>
    {
        private readonly IPublishEndpoint _publishEndpoint;
        public OrderCreatedConsumer(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }
        public async Task Consume(ConsumeContext<OrderCreated> context)
        {
            // If it is in stock throw StockReserved
            // if not StockNotReserved

            if(CheckStock(context.Message.OrderItems))
            {
                await _publishEndpoint.Publish(new StockReserved
                {
                    CustomerId = context.Message.CustomerId,
                    OrderId = context.Message.OrderId,
                    TotalPrice = context.Message.TotalPrice,
                    OrderItems = context.Message.OrderItems
                });
            }
            else
            {
                await _publishEndpoint.Publish(new StockNotReserved
                {
                    CustomerId = context.Message.CustomerId,
                    OrderId = context.Message.OrderId,
                    Message = "Not Enough."
                });
            }
        }

        private bool CheckStock(List<OrderItemMessage>? orderItems)
        {
            return new Random().Next(0, 10) % 2 == 0;
        }
    }
}
