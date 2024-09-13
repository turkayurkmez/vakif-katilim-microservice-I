using eshop.MessageBus;
using MassTransit;

namespace eshop.Order.Consumers
{
    public class PaymentCompletedConsumer(ILogger<PaymentCompletedConsumer> logger) : IConsumer<PaymentCompletedEvent>
    {
        public Task Consume(ConsumeContext<PaymentCompletedEvent> context)
        {
            var orderId = context.Message.PaymentCompletedCommand.OrderId;
            //db'den order'ı bul ve IsApproved değerine true ata:
            Order order = new Order {  IsApproved = true };
            logger.LogInformation("Sipariş başarıyla tamamlandı");
            return Task.CompletedTask;
        }
 
    }

}
