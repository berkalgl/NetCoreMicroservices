using MassTransit;
using MessagesAndEvents.Requests;
using Microsoft.Extensions.Logging;

namespace MailNotification.Consumer
{
    public class AddBookToBasketConsumer : IConsumer<AddBookToBasketRequest>
    {
        public Task Consume(ConsumeContext<AddBookToBasketRequest> context)
        {
            Console.WriteLine($"Sepete {context.Message.Name} isimli kitap eklendiğine dair mail gönderildi! ");
            return Task.CompletedTask;
        }
    }
}
