namespace GameSystem.Domain.Entities.GameContext;

public class GameDeck: BaseAuditableEntity
{
    public string? Name { get; init; }
    
    public GameType GameType { get; init; }
    
    public IList<CardInDeck> CardList { get; set; } = new List<CardInDeck>();
}
