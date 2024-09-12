using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Ticket;


namespace Server.Services
{
    public class TicketerService(TicketRepository ticketRepository) : Ticketer.TicketerBase
    {
        public override Task<AvailableTicketResponse> GetAvailableTickets(Empty request, ServerCallContext context)
        {
            return Task.FromResult(new AvailableTicketResponse
            {
                Count = ticketRepository.GetAvailableTickets()
            });
        }

        [Authorize]
        public override Task<BuyTicketsResponse> BuyTickets(BuyTicketsRequest request, ServerCallContext context)
        {
            var user = context.GetHttpContext().User;

             return Task.FromResult(new BuyTicketsResponse
            {
                Success = ticketRepository.BuyTickets(user.Identity!.Name!, request.Count)
            });
        }
    }
}
