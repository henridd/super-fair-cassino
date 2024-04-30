using Elastic.Apm.NetCoreAll;
using Microsoft.AspNetCore.Mvc;
using SuperFairCassinoAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseAllElasticApm(app.Configuration);
}

app.MapGet("/Bet", IResult ([FromQuery] Game game = Game.Blackjack) =>
{
    if (ShouldWin())
    {
        // We cannot let them win!!
        throw new Exception("Whoops! Something went wrong with the request. Please try again.");
    }

    return Results.Ok($"Sorry! You didn't win your {game} game, please bet again!");

    bool ShouldWin()
    {
        return new Random().Next(0, 10) > 5;
    }
})
.WithName("Bet")
.WithOpenApi();

app.Run();
