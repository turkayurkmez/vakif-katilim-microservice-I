using eshop.MessageBus;
using MassTransit;

namespace eshop.Stock.API.Consumer
{
    public class PaymentFailedConsumer(ILogger<PaymentFailedConsumer> logger) : IConsumer<PaymentFailedEvent>
    {
        public Task Consume(ConsumeContext<PaymentFailedEvent> context)
        {
            context.Message.PaymentFailedCommand.OrderItems.ForEach(item => logger.LogInformation($"{item.ProductId} idli ürünün stoğuna {item.Quantity} iade edildi"));
            return Task.CompletedTask;
        }
    }
}
