namespace GameStore.Api.Dtos;

public record CreateGameDto
    (
        int Id,
        string Title,
        string Genre,
        decimal Price,
        string Developer,
        string Publisher,
        DateTime ReleaseDate
    );
