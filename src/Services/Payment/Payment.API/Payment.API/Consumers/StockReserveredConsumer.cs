using MassTransit;
using MessagesAndEvents.Events;

namespace Payment.API.Consumers
{
    public class StockReserveredConsumer : IConsumer<StockReserved>
    {
        private readonly IPublishEndpoint _publishEndpoint;
        public StockReserveredConsumer(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task Consume(ConsumeContext<StockReserved> context)
        {
            // Get The Payment
            // Success --> PaymentCompleted
            // Fail --> PaymentFailed events

            if(PaymentSuccess(context.Message))
            {
                await _publishEndpoint.Publish(new PaymentCompleted
                {
                    OrderId = context.Message.OrderId,

                });
            }
            else
            {
                await _publishEndpoint.Publish(new PaymentFailed
                {
                    OrderId = context.Message.OrderId,
                    Message = "Failed..."
                });
            }
        }

        private static bool PaymentSuccess(StockReserved message)
        {
            return new Random().Next(0, 10) % 2 == 0;
        }
    }
}
