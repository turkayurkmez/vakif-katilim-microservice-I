using eshop.MessageBus;
using MassTransit;

namespace eshop.Order.Consumers
{
    public class PriceDiscountedEventConsumer(ILogger<PriceDiscountedEventConsumer> logger) : IConsumer<PriceDiscountedEvent>
    {
        public Task Consume(ConsumeContext<PriceDiscountedEvent> context)
        {
            logger.LogInformation($" Burası Order servisi: {context.Message.DiscountPriceCommand.ProductId} isimli ürünün yeni fiyatı: {context.Message.DiscountPriceCommand.NewPrice}");

            return Task.CompletedTask;
        }
    }
}
