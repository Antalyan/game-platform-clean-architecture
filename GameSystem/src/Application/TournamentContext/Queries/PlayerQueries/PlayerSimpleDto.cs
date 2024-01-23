using GameSystem.Domain.Entities.PlayerContext;

namespace GameSystem.Application.TournamentContext.Queries.PlayerQueries;

public class PlayerSimpleDto
{
    public string? Name { get; init; }
    public string? EmailAddress { get; init; }
    public bool IsOpenToTournament { get; init; } = true;
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Player, PlayerSimpleDto>();
        }
    }
}
