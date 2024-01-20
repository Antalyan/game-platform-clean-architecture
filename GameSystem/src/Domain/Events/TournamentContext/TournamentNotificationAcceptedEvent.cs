using GameSystem.Domain.Entities.TournamentContext;

namespace GameSystem.Domain.Events.TournamentContext;

public class TournamentNotificationAcceptedEvent(TournamentNotification notification):BaseEvent
{
    public TournamentNotification Notification { get; } = notification;
}
