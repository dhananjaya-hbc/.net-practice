using GameStore.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<GameDto> games = [
    new(1, "The Legend of Zelda: Breath of the Wild", "Action-adventure", 59.99m, "Nintendo", "Nintendo", new DateTime(2017, 3, 3)),
    new(2, "Super Mario Odyssey", "Platform", 59.99m, "Nintendo", "Nintendo", new DateTime(2017, 10, 27)),
    new(3, "Red Dead Redemption 2", "Action-adventure", 59.99m, "Rockstar Games", "Rockstar Games", new DateTime(2018, 10, 26))
];

app.MapGet("/games", () => games);

app.Run();
