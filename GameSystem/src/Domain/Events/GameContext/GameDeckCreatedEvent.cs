using GameSystem.Domain.Entities.GameContext;

namespace GameSystem.Domain.Events.GameContext;

public class GameDeckCreatedEvent(GameDeck deck) : BaseEvent
{
    public GameDeck Deck { get; } = deck;
}
