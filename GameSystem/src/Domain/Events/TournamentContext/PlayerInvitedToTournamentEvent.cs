using GameSystem.Domain.Entities.PlayerContext;
using GameSystem.Domain.Entities.TournamentContext;

namespace GameSystem.Domain.Events.TournamentContext;

public class PlayerInvitedToTournamentEvent(Player player, Tournament tournament)
{
    public Player Player { get; } = player;
    public Tournament Tournament { get; } = tournament;
}
