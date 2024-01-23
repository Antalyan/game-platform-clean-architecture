using GameSystem.Domain.Entities.PlayerContext;
using GameSystem.Domain.Entities.TournamentContext;

namespace GameSystem.Domain.Events.TournamentContext;

public class TournamentPlayersInvitedEvent(Tournament tournament):BaseEvent
{
    public Tournament Tournament { get; } = tournament;
}
