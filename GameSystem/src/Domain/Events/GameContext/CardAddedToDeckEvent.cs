using GameSystem.Domain.Entities.GameContext;

namespace GameSystem.Domain.Events.GameContext;

public class CardAddedToDeckEvent(GameDeck deck) : BaseEvent
{
    public GameDeck Deck { get; } = deck;
}

