using GameSystem.Domain.Entities.GameContext;

namespace GameSystem.Domain.Events.GameContext;

public class GameDeletedEvent(Game game) : BaseEvent
{
    public Game Game { get; } = game;
}
