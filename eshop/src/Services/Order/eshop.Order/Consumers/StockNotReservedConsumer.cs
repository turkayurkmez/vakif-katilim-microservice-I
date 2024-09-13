using eshop.MessageBus;
using MassTransit;

namespace eshop.Order.Consumers
{
    public class StockNotReservedConsumer(ILogger<StockNotReservedConsumer> logger) : IConsumer<StockNotReservedEvent>
    {
        public Task Consume(ConsumeContext<StockNotReservedEvent> context)
        {
            var orderId = context.Message.StockNotReservedCommand.OrderId;
            //db'den order'ı bul ve IsApproved değerine false ata:
            Order order = new Order { IsApproved = false };
            logger.LogInformation($"Sipariş tamamlanamadı. sebebi: Ürün stoğu yetersiz!");
            return Task.CompletedTask;
        }

    }

}
