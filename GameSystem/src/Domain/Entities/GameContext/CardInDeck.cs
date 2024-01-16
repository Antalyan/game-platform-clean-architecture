using GameSystem.Domain.Entities.CardContext;

namespace GameSystem.Domain.Entities.GameContext;

public class CardInDeck: BaseAuditableEntity
{
    public CardData CardData { get; set; } = null!;
    public int GameDeckId { get; set; }
    public int Quantity { get; set; }
}
