using GameSystem.Domain.Entities.TournamentContext;

namespace GameSystem.Domain.Events.TournamentContext;

public class PlayerAddedToTournamentEvent(PlayerInTournament player, Tournament tournament) : BaseEvent
{
    public PlayerInTournament PlayerInTournament { get; } = player;
    public Tournament Tournament { get; } = tournament;
}
