using GameSystem.Domain.Entities.PlayerContext;
using GameSystem.Domain.Entities.TournamentContext;

namespace GameSystem.Domain.Events.TournamentContext;

public class PlayerNotifiedEvent(TournamentNotification notification, Player player)
{
    public Player Player { get; } = player;
    public TournamentNotification Notification { get; } = notification;
}
