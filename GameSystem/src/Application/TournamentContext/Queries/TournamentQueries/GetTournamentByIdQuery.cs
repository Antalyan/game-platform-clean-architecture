using GameSystem.Application.TournamentContext.Queries.TournamentQueries;

namespace GameSystem.Application.TournamentContext.Queries.TournamentNotificationQueries;

public class GetTournamentByIdQuery : IRequest<TournamentDetailedDto?>
{
    public int TournamentId { get; init; }
}
