namespace GameStore.Api.Dtos;
public record UpdateGameDto
(
    int Id,
    string Title,
    string Genre,
    decimal Price,
    string Developer,
    string Publisher,
    DateTime ReleaseDate
);