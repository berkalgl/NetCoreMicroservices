using MassTransit;
using MessagesAndEvents.Requests;

namespace Basket.API.Consumer
{
    public class AddBookToBasketRequestConsumer : IConsumer<AddBookToBasketRequest>
    {
        private readonly ILogger _logger;
        public AddBookToBasketRequestConsumer(ILogger<AddBookToBasketRequestConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<AddBookToBasketRequest> context)
        {
            _logger.LogInformation($"{context.Message.UserId} nolu kullanıcı; {context.Message.Name} isimli kitabı sepete ekledi");
            //Here we can manage our db process for this consumer
            return Task.CompletedTask;
        }
    }
}
