using GameStore.Api.Data;
using GameStore.Api.Dtos;
using GameStore.Api.Mapping;

namespace GameStore.Api.Endpoints;

public static class GamesEndpoints
{
    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/games");

        group.MapGet("/", (GameStoreContext dbContext) =>
            dbContext.Games.Select(game => game.ToDto()).ToList());

        group.MapGet("/{id}", (int id, GameStoreContext dbContext) =>
        {
            var game = dbContext.Games.Find(id);
            return game is not null ? Results.Ok(game.ToDto()) : Results.NotFound();
        });

        group.MapPost("/", (CreateGameDto newGame, GameStoreContext dbContext) =>
        {
            var game = newGame.ToEntity();

            dbContext.Games.Add(game);
            dbContext.SaveChanges();

            return Results.Created($"/games/{game.Id}", game.ToDto());
        });

        group.MapPut("/{id}", (int id, CreateGameDto updatedGame, GameStoreContext dbContext) =>
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

        return group;
    }
}
