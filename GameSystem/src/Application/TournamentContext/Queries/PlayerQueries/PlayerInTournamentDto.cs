using GameSystem.Application.TournamentContext.Queries.TournamentQueries;
using GameSystem.Domain.Entities.TournamentContext;

namespace GameSystem.Application.TournamentContext.Queries.PlayerQueries;

public class PlayerInTournamentDto
{
    public PlayerDetailedDto PlayerDetailed { get; init; } = null!;
    public TournamentSimpleDto Tournament { get; init; } = null!;
    
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<PlayerInTournament, PlayerInTournamentDto>();
        }
    }
}
