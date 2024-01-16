using System.Collections;
using GameSystem.Domain.Entities.GameContext;

namespace GameSystem.Domain.Events.GameContext;

public class GameAppearedInPollsEvent(Game game, IList<GamePoll> updatedPolls): BaseEvent
{
    public Game Game { get; } = game;
    public IList<GamePoll> UpdatedPolls { get; } = updatedPolls;
}

