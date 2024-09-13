using eshop.MessageBus;
using MassTransit;

namespace Basket.API.Consumers
{
    public class ProductPriceDiscountedConsumer(ILogger<ProductPriceDiscountedConsumer> logger) : IConsumer<PriceDiscountedEvent>
    {
        public Task Consume(ConsumeContext<PriceDiscountedEvent> context)
        {
            /*
             * Bu ms'in storage kısmında müşterilere ait sepet koleksiyonları içerisinde; ilgili ürün bulunarak (command.ProductId)
             * yeni fiyat güncellemesi yapılmalıdır.
             * mediator.Send()
             */
            var command = context.Message.DiscountPriceCommand;
            logger.LogInformation($"{command.ProductId} id'li ürünün fiyatı {command.OldPrice} TL'den, {command.NewPrice} TL'ye düştü!");
            return Task.CompletedTask;
        }
    }
}
