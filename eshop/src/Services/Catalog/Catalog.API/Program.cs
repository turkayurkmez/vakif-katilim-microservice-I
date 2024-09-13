using Catalog.Application.Contracts.Repositories;
using Catalog.Application.Features.Product.GetAllProducts;
using Catalog.Persistence.Data;
using Catalog.Persistence.Repositories;
using MassTransit;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<GetAllProductsHandler>());

builder.Services.AddScoped<IProductRepository, ProductRepository>();

var connectionString = builder.Configuration.GetConnectionString("db");
var host = builder.Configuration.GetSection("DefaultHostName").Value;
var pass = builder.Configuration.GetSection("DefaultPassword").Value;
connectionString = connectionString.Replace("[HOST]", host)
                                   .Replace("[PASS]", pass);
builder.Services.AddDbContext<CatalogDbContext>(option => option.UseSqlServer(connectionString));

builder.Services.AddMassTransit(configure =>
{
    configure.UsingRabbitMq((context, configurator) =>
    {
        configurator.Host("rabbit-mq", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
    
        });

        configurator.ConfigureEndpoints(context);
    });

});

var app = builder.Build();

var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<CatalogDbContext>();
dbContext.Database.Migrate();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
