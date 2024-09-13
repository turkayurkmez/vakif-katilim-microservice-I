using eshop.MessageBus;
using eshop.Order.Consumers;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(configure =>
{
    configure.AddConsumer<StockNotReservedConsumer>();
    configure.AddConsumer<PaymentCompletedConsumer>();
    configure.AddConsumer<PaymentFailedConsumer>();


    configure.UsingRabbitMq((context, configurator) =>
    {
        configurator.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");

        });

        configurator.ConfigureEndpoints(context);
    });

});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/createOrder", async (IPublishEndpoint publish, CreateOrderRequest request) =>
{

    var orderItems = request.Items.Select(item => new OrderItem
    {
        ProductId = item.ProductId,
        Price = item.Price,
        Quantity = item.Quantity
    }).ToList();


    var @event = new OrderCreatedEvent
    {
        OrderCreatedCommand = new OrderCreatedCommand
        {
            CreditCardInfo = request.CreditCardId,
            CustomerId = request.CustomerId,
            OrderItems = orderItems
        }
    };

   await publish.Publish(@event);

});
app.Run();


public record CreateOrderRequest(int CustomerId, string? CreditCardId, List<OrderItemRequest> Items);
public record OrderItemRequest(int ProductId, decimal? Price, int Quantity);
