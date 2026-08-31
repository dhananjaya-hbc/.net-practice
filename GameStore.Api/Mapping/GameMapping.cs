using GameStore.Api.Dtos;
using GameStore.Api.Models;

namespace GameStore.Api.Mapping;

public static class GameMapping
{
    public static GameDto ToDto(this Game game)
    {
        return new GameDto(
            game.Id,
            game.Title,
            game.Genre,
            game.Price,
            game.Developer,
            game.Publisher,
            game.ReleaseDate
        );
    }

    public static Game ToEntity(this CreateGameDto createGameDto)
    {
        return new Game
        {
            Title = createGameDto.Title,
            Genre = createGameDto.Genre,
            Price = createGameDto.Price,
            Developer = createGameDto.Developer,
            Publisher = createGameDto.Publisher,
            ReleaseDate = createGameDto.ReleaseDate
        };
    }
}
