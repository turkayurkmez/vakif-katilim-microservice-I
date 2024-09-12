using BasketGrpc.Protos;
using Grpc.Core;

namespace BasketGrpc.Services
{
    public class BasketService(ILogger<BasketService> logger) : Basket.BasketBase
    {
        public override Task<CustomerBasketResponse> UpdateBasket(UpdateBasketRequest request, ServerCallContext context)
        {
            logger.LogInformation("grpc protokolünden UpdateBasket fonksiyonuna istek geldi! ");
           
            var response = new CustomerBasketResponse();

            logger.LogInformation($"Talep gelen rpc fonksiyonu: {context.Method}");
            
            logger.LogInformation($"Gelen istek detayları: {string.Join(",", request.Items.Select(r => r.ProductId).ToArray())}");
            foreach (var item in request.Items)
            {
                response.Items.Add(item);
            }

            return Task.FromResult(response);
        }

        public override Task<CustomerBasketResponse> GetBasket(GetBasketRequest request, ServerCallContext context)
        {
            
            return base.GetBasket(request, context);
        }
    }
}
