using MassTransit;
using MessagesAndEvents.Events;

namespace Shipment.API.Consumers
{
    public class PaymentCompletedConsumer : IConsumer<PaymentCompleted>
    {
        private readonly ILogger<PaymentCompletedConsumer> _logger;
        public PaymentCompletedConsumer(ILogger<PaymentCompletedConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<PaymentCompleted> context)
        {
            _logger.LogInformation($"Payment of {context.Message.OrderId} Completed In Shipment...");

            return Task.CompletedTask;
        }
    }
}
