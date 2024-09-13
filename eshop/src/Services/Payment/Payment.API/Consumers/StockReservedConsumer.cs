using eshop.MessageBus;
using MassTransit;

namespace Payment.API.Consumers
{
    public class StockReservedConsumer(IPublishEndpoint publishEndpoint, ILogger<StockReservedConsumer> logger) : IConsumer<StockReservedEvent>
    {
        public Task Consume(ConsumeContext<StockReservedEvent> context)
        {
            logger.LogInformation("Stock olayı dinleniyor");
            if (checkPayment(context.Message.StockReservedCommand.CreditCardInfo, context.Message.StockReservedCommand.OrderItems))
            {
                var paymentCompletedEvent = new PaymentCompletedEvent
                {
                    PaymentCompletedCommand = new()
                    {
                        OrderId = context.Message.StockReservedCommand.OrderId
                    }
                };
                publishEndpoint.Publish(paymentCompletedEvent);

            }
            else
            {
                var failedEvent = new PaymentFailedEvent
                {
                    PaymentFailedCommand = new PaymentFailedCommand
                    {
                        OrderId = context.Message.StockReservedCommand.OrderId,
                        OrderItems = context.Message.StockReservedCommand.OrderItems,
                        Reason = "Banka reddetti"

                    }
                };
                publishEndpoint.Publish(failedEvent);

            }    
            return Task.CompletedTask;
        }

        private bool checkPayment(string? creditCardInfo, List<OrderItem> orderItems)
        {
            return true;
        }
    }
}
