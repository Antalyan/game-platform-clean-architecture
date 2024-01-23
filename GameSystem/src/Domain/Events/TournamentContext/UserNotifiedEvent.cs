using GameSystem.Domain.Entities.PlayerContext;
using GameSystem.Domain.Entities.TournamentContext;

namespace GameSystem.Domain.Events.TournamentContext;

public class UserNotifiedEvent(IList<Player> players, Tournament tournament): BaseEvent
{
    public IList<Player> Players { get; } = players;
    public Tournament Tournament { get; } = tournament;
}
