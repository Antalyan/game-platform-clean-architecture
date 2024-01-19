using GameSystem.Domain.Entities.TournamentContext;

namespace GameSystem.Domain.Events.TournamentContext;

public class TournamentOfferAcceptedEvent(Tournament tournament, PlayerInTournament playerInTournament)
{
    public Tournament Tournament { get; } = tournament;
    public PlayerInTournament PlayerInTournament { get; } = playerInTournament;
}
