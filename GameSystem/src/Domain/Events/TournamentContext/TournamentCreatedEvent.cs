using GameSystem.Domain.Entities.TournamentContext;

namespace GameSystem.Domain.Events.TournamentContext;

public class TournamentCreatedEvent(Tournament tournament, PlayerInTournament playerInTournament) : BaseEvent
{
    public Tournament Tournament { get; } = tournament;
    public PlayerInTournament PlayerInTournament { get; } = playerInTournament;
}
