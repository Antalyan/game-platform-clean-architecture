namespace GameSystem.Domain.Entities.CardContext;

public class Card: BaseAuditableEntity
{
    public string? Name { get; init; }
    
    public string? Text { get; init; }
    
    public GameType GameType { get; init; }
}
