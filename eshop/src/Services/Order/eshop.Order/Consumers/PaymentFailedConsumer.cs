using eshop.MessageBus;
using MassTransit;

namespace eshop.Order.Consumers
{
    public class PaymentFailedConsumer(ILogger<PaymentFailedConsumer> logger) : IConsumer<PaymentFailedEvent>
    {
        public Task Consume(ConsumeContext<PaymentFailedEvent> context)
        {
            var orderId = context.Message.PaymentFailedCommand.OrderId;
            //db'den order'ı bul ve IsApproved değerine false ata:
            Order order = new Order { IsApproved = false };
            logger.LogInformation($"Sipariş tamamlanamadı. sebebi: {context.Message.PaymentFailedCommand.Reason}");
            return Task.CompletedTask;
        }

    }

}
