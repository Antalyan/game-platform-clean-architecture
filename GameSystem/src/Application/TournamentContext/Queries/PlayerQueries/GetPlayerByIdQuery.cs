namespace GameSystem.Application.TournamentContext.Queries.PlayerQueries;

public class GetPlayerByIdQuery : IRequest<PlayerDetailedDto?>
{
    public int PlayerId { get; init; }
}
