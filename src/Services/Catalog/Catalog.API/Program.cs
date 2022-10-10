using Catalog.Application.BookService;
using Catalog.DataAccess.Data;
using Catalog.DataAccess.Repositories.Implementation;
using Catalog.DataAccess.Repositories.Interfaces;
using MassTransit;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Services dependency injection
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();

//Default Hosts
var defaultHost = builder.Configuration.GetValue<string>("DefaultHost");

//Db Settings
var connectionString = builder.Configuration.GetConnectionString("db");
connectionString = connectionString.Replace("[HOST]", defaultHost);
Console.WriteLine("Connection String with Docker: " + connectionString);
builder.Services.AddDbContext<CatalogDbContext>(opt => opt.UseSqlServer(connectionString, b => b.MigrationsAssembly("Catalog.DataAccess")));

//MassTransit configuration
builder.Services.AddMassTransit(configurator =>
{
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

// Run db context seeds in run time with scope
var dbInstance = app.Services.CreateScope().ServiceProvider.GetRequiredService<CatalogDbContext>();
PrepareDb.Initialize(dbInstance);



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
