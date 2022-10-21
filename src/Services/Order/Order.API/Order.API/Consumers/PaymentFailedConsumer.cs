using MassTransit;
using MediatR;
using MessagesAndEvents.Events;
using Order.API.Commands;

namespace Order.API.Consumers
{
    public class PaymentFailedConsumer : IConsumer<PaymentFailed>
    {
        private readonly ILogger<PaymentFailedConsumer> _logger;
        private readonly IMediator _mediator;
        public PaymentFailedConsumer(ILogger<PaymentFailedConsumer> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public Task Consume(ConsumeContext<PaymentFailed> context)
        {
            _logger.LogInformation($"Payment of {context.Message.OrderId} Failed...");
            _mediator.Send(new UpdateOrderStateCommand { OrderId = context.Message.OrderId, OrderState = Models.OrderState.Failed});
            return Task.CompletedTask;
        }
    }
}
