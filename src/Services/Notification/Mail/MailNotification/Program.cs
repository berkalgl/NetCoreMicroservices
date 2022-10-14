// See https://aka.ms/new-console-template for more information
using MailNotification;
using MailNotification.Consumer;
using MassTransit;

var b = new B(1, 2);
b.Writea();
var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
{
    cfg.Host("localhost", "/", host =>
    {
        host.Username("guest");
        host.Password("guest");
    });

    cfg.ReceiveEndpoint("AddBookToBasketRequest", e =>
    {
        e.Consumer<AddBookToBasketConsumer>();
    });
});


Console.WriteLine("Hello, World!");
busControl.Start();
Console.ReadLine();