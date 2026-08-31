using GameStore.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<GameDto> games = [
    new(1, "The Legend of Zelda: Breath of the Wild", "Action-adventure", 59.99m, "Nintendo", "Nintendo", new DateTime(2017, 3, 3)),
    new(2, "Super Mario Odyssey", "Platform", 59.99m, "Nintendo", "Nintendo", new DateTime(2017, 10, 27)),
    new(3, "Red Dead Redemption 2", "Action-adventure", 59.99m, "Rockstar Games", "Rockstar Games", new DateTime(2018, 10, 26))
];

//Get all games
app.MapGet("/games", () => games);

//Get a game by id
app.MapGet("/games/{id}", (int id) =>
{
    var game = games.FirstOrDefault(g => g.Id == id);
    return game is not null ? Results.Ok(game) : Results.NotFound();
});

//Create a new game
app.MapPost("/games", (CreateGameDto newGame) =>
{
    var game = new GameDto(
        Id: games.Max(g => g.Id) + 1,
        Title: newGame.Title,
        Genre: newGame.Genre,
        Price: newGame.Price,
        Developer: newGame.Developer,
        Publisher: newGame.Publisher,
        ReleaseDate: newGame.ReleaseDate
    );

    games.Add(game);
    return Results.Created($"/games/{game.Id}", game);
});

//Update a game
app.MapPut("/games/{id}", (int id, CreateGameDto updatedGame) =>
{
    var game = games.FirstOrDefault(g => g.Id == id);
    if (game is null)
    {
        return Results.NotFound();
    }

    var updatedGameDto = new GameDto(
        Id: game.Id,
        Title: updatedGame.Title,
        Genre: updatedGame.Genre,
        Price: updatedGame.Price,
        Developer: updatedGame.Developer,
        Publisher: updatedGame.Publisher,
        ReleaseDate: updatedGame.ReleaseDate
    );

    games[games.IndexOf(game)] = updatedGameDto;
    return Results.Ok(updatedGameDto);
});

app.Run();
