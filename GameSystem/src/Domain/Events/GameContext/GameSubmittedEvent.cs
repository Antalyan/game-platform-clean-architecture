using GameSystem.Domain.Entities.GameContext;

namespace GameSystem.Domain.Events.GameContext;

public class GameSubmittedEvent(Game game, IList<string> players) : BaseEvent
{
    public Game Game { get; } = game;
    public IList<string> SharedPlayers { get; } = players;
}
