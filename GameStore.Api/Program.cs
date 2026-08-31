using GameStore.Api.Data;
using GameStore.Api.Dtos;
using GameStore.Api.Mapping;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlite<GameStoreContext>(
    builder.Configuration.GetConnectionString("GameStoreConnection"));

var app = builder.Build();

//Get all games
app.MapGet("/games", (GameStoreContext dbContext) =>
    dbContext.Games.Select(game => game.ToDto()).ToList());

//Get a game by id
app.MapGet("/games/{id}", (int id, GameStoreContext dbContext) =>
{
    var game = dbContext.Games.Find(id);
    return game is not null ? Results.Ok(game.ToDto()) : Results.NotFound();
});

//Create a new game
app.MapPost("/games", (CreateGameDto newGame, GameStoreContext dbContext) =>
{
    var game = newGame.ToEntity();

    dbContext.Games.Add(game);
    dbContext.SaveChanges();

    return Results.Created($"/games/{game.Id}", game.ToDto());
});

//Update a game
app.MapPut("/games/{id}", (int id, CreateGameDto updatedGame, GameStoreContext dbContext) =>
{
    var game = dbContext.Games.Find(id);
    if (game is null)
    {
        return Results.NotFound();
    }

    game.Title = updatedGame.Title;
    game.Genre = updatedGame.Genre;
    game.Price = updatedGame.Price;
    game.Developer = updatedGame.Developer;
    game.Publisher = updatedGame.Publisher;
    game.ReleaseDate = updatedGame.ReleaseDate;

    dbContext.SaveChanges();

    return Results.Ok(game.ToDto());
});

app.Run();