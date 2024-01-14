namespace GameSystem.Domain.Entities.GameContext;

public class Game: BaseAuditableEntity
{
    public string? Name { get; set; }
    public GameDeck Deck { get; set; } = null!;
    public Rules Rules { get; set; } = null!;
    public Visibility Visibility { get; set; }
}
