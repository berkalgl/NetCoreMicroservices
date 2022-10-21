using MassTransit;
using MediatR;
using Order.API.Consumers;
using Order.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//adding mediatR to project
builder.Services.AddMediatR(typeof(Program));

//
builder.Services.AddScoped<FakeDataSourceService>();

//MassTransit configuration
builder.Services.AddMassTransit(configurator =>
{
    configurator.AddConsumer<PaymentCompletedConsumer>();
    configurator.AddConsumer<PaymentFailedConsumer>();
    configurator.AddConsumer<StockNotReserveredConsumer>();
    configurator.UsingRabbitMq((context, config) =>
    {
        config.Host("rabbitmq", "/", host =>
        {
            host.Username("guest");
            host.Password("guest");
        });

        //Handshake with RabbitMQ
        config.ConfigureEndpoints(context);
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
