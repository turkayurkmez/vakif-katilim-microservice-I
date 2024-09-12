using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Server;
using Server.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();
builder.Services.AddSingleton<TicketRepository>();
builder.Services.AddAuthorization(option =>
{
    //Burada; authorize olabilmesi için; Name claim'inin zorunlu olduğunu belirttik.
    option.AddPolicy(JwtBearerDefaults.AuthenticationScheme, policy =>
    {
        policy.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
        policy.RequireClaim(ClaimTypes.Name);
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = true,
                        ValidAudience="Server",
                        ValidIssuer="Client",
                        ValidateIssuer = true,
                        ValidateActor = false,
                        ValidateLifetime = true,
                        IssuerSigningKey = symmetricSecurityKey
                      
                    };
                });

var app = builder.Build();


//app.UseGrpcWeb();
app.UseAuthentication();
app.UseAuthorization();
app.MapGrpcService<TicketerService>();//.EnableGrpcWeb();



app.MapGet("/generateJwtToken", (context) => {
    return context.Response.WriteAsync(GenerateJwtToken(context.Request.Query["name"]!));
});


app.Run();

static string GenerateJwtToken(string name)
{
    if (string.IsNullOrEmpty(name))
    {
        throw new InvalidOperationException("Name bilgisi zorunlu");
    }
    var claims = new[] { new Claim(ClaimTypes.Name, name) };
    var credential = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
    var token = new JwtSecurityToken(
        issuer: "Server",
        audience: "Client",
        claims: claims,
        notBefore: DateTime.Now,
        expires: DateTime.Now.AddDays(1),
        signingCredentials: credential
        );
    return  jwtSecurityTokenHandler.WriteToken(token);


}

public partial class Program
{
   private static readonly JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
   private static readonly SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("bu-bir-256-bitlik-gizli-ifadedir"));
   
}
