namespace GameSystem.Domain.Entities.CardContext;

public class CardData: BaseAuditableEntity
{
    public string? Name { get; init; }
    
    public string? Text { get; init; }
    
    public GameType GameType { get; init; }
}
