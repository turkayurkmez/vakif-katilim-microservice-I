using eshop.MessageBus;
using MassTransit;

namespace eshop.Stock.API.Consumer
{
    public class OrderCreatedConsumer(IPublishEndpoint publishEndpoint, ILogger<OrderCreatedConsumer> logger) : IConsumer<OrderCreatedEvent>
    {
        public Task Consume(ConsumeContext<OrderCreatedEvent> context)
        {
            logger.LogInformation("Sipariş oluştu olayı dinleniyor!");
            if (stockIsAvailable(context.Message.OrderCreatedCommand.OrderItems))
            {
                var @event = new StockReservedEvent
                {
                    StockReservedCommand = new()
                    {
                        CreditCardInfo = context.Message.OrderCreatedCommand.CreditCardInfo,
                        CustomerId = context.Message.OrderCreatedCommand.CustomerId,
                        OrderId = context.Message.OrderCreatedCommand.OrderId,
                        OrderItems = context.Message.OrderCreatedCommand.OrderItems,

                    }
                };

                 publishEndpoint.Publish(@event);
            }
            else
            {
                var @event = new StockNotReservedEvent()
                {
                    StockNotReservedCommand = new()
                    {
                        CustomerId = context.Message.OrderCreatedCommand.CustomerId,
                        OrderId = context.Message.OrderCreatedCommand.OrderId
                    }
                };
                 publishEndpoint.Publish(@event);

            }

            return Task.CompletedTask; 

        }

        private bool stockIsAvailable(List<OrderItem> orderItems)
        {
            return new Random().Next(0, 100) % 2 == 0;
        }
    }
}
