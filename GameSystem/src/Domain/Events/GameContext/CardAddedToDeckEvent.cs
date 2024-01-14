using GameSystem.Domain.Entities.GameContext;

namespace GameSystem.Domain.Events.GameContext;

public class CardAddedToDeckEvent(CardInDeck card, GameDeck deck) : BaseEvent
{
    public CardInDeck Card { get; } = card;
    public GameDeck Deck { get; } = deck;
}

