using CloudDesignPatterns.Ambassador.API.ContaCorrente.Business;
using CloudDesignPatterns.Ambassador.API.ContaCorrente.Business.Interface;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API Conta Corrente",
        Version = "v1"
    });
});

builder.Services.AddSingleton<ISaldo, Saldo>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
