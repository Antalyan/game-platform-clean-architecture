using GameSystem.Domain.Entities.PlayerContext;
using GameSystem.Domain.Entities.TournamentContext;

namespace GameSystem.Domain.Events.TournamentContext;

public class TournamentPlayersInvitedEvent(TournamentNotification notification):BaseEvent
{
    public TournamentNotification Notification { get; } = notification;
}
