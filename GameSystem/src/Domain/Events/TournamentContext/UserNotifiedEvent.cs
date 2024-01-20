using GameSystem.Domain.Entities.PlayerContext;
using GameSystem.Domain.Entities.TournamentContext;

namespace GameSystem.Domain.Events.TournamentContext;

public class UserNotifiedEvent(Player player, Tournament tournament)
{
    public Player Player { get; } = player;
    public Tournament Tournament { get; } = tournament;
}
