namespace GameSystem.Domain.Entities.GameContext;

public class GameDeck: BaseAuditableEntity
{
    public int Name { get; init; }
    
    public GameType GameType { get; init; }
    
    public IList<CardInDeck> List { get; set; } = null!;
}
