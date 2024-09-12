// See https://aka.ms/new-console-template for more information

using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using System.Net.Security;
using System.Web;
using Ticket;

using var channel = GrpcChannel.ForAddress("https://localhost:5181");
var client = new Ticketer.TicketerClient(channel);

Console.WriteLine("gRPC ile Bilet işlemleri");
Console.WriteLine("--------------------");
Console.WriteLine("1. Uygun Bilet sayısı");
Console.WriteLine("2. Bilet satın al");
Console.WriteLine("3. Oturum aç");
Console.WriteLine("4. Çıkış");
Console.WriteLine();

string? token = null;
var exiting = false;
while (!exiting)
{
    var keyInfo = Console.ReadKey(intercept: true);
    switch (keyInfo.KeyChar)
    {
        case '1':
            await GetAvailableTickets(client);
            break;
        case '2':
            await PurchaseTicket(client, token);
            break;
        case '3':
            token = await Authenticate();
            break;
        case '4':
            exiting = true;
            break;

        default:
            break;
    }
}

async Task<string?> Authenticate()
{
    string user = "turkay";
    using var httpClient = new HttpClient();
    using var request = new HttpRequestMessage
    {
        
        Method = HttpMethod.Get,
        RequestUri = new Uri($"https://localhost:5181/generateJwtToken?name={HttpUtility.UrlEncode(user)}"),
        Version = new Version(2,0)
    };

  
    using var tokenResponse = await httpClient.SendAsync(request);
    tokenResponse.EnsureSuccessStatusCode();
    var token = await tokenResponse.Content.ReadAsStringAsync();
    Console.WriteLine("Oturum açma başarılı");
    return token;

}

async Task PurchaseTicket(Ticketer.TicketerClient client, string? token)
{
    Console.WriteLine("Bilet satın alınıyor");
    try
    {
        Metadata? headers=null;
        if (token!= null)
        {
            headers = new Metadata();
            headers!.Add("Authorization", $"Bearer {token}");

        }

        var response = await client.BuyTicketsAsync(new BuyTicketsRequest { Count = 1 }, headers);
          if (response.Success)
        {
            Console.WriteLine("Satın alma başarılı");
        }
        else
        {
            Console.WriteLine("Yeterli bilet yok");
        }



    }
    catch (RpcException ex)
    {

        Console.WriteLine($"Bilet alınamadı. Hata: {ex.Status.StatusCode}");
    }
    catch(Exception ex) 
    {
        Console.WriteLine($"Bilet alınamadı. Hata: {ex.ToString()}");
    }
}

async Task GetAvailableTickets(Ticketer.TicketerClient client)
{
    Console.WriteLine("Bilet bilgisi alınıyor....");
    var response = await client.GetAvailableTicketsAsync(new Empty());
    Console.WriteLine($"Kalan bilet: {response.Count}");
}
