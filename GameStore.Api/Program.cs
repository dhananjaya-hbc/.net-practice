using GameStore.Api.Data;
using GameStore.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlite<GameStoreContext>(
    builder.Configuration.GetConnectionString("GameStoreConnection"));

var app = builder.Build();

app.MapGamesEndpoints();

app.Run();
