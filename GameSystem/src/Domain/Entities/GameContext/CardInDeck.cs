namespace GameSystem.Domain.Entities.GameContext;

public class CardInDeck: BaseAuditableEntity
{
    public int CardId { get; set; }
    public int GameDeckId { get; set; }
    public int Quantity { get; set; }
}
