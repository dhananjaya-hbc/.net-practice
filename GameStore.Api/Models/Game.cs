namespace GameStore.Api.Models;

public class Game
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Genre { get; set; }
    public decimal Price { get; set; }
    public required string Developer { get; set; }
    public required string Publisher { get; set; }
    public DateTime ReleaseDate { get; set; }
}
