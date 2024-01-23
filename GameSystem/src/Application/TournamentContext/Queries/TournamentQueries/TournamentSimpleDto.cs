using System.ComponentModel.DataAnnotations;
using GameSystem.Application.GameContext.Queries.GameQueries;
using GameSystem.Domain.Entities.GameContext;
using GameSystem.Domain.Entities.TournamentContext;
using GameSystem.Domain.Enums;

namespace GameSystem.Application.TournamentContext.Queries.TournamentQueries;

public class TournamentSimpleDto
{
    public string? Name { get; init; }
    public string? Description { get; init; }
    public int? MaximalPlayersCount { get; set; }

    [EnumDataType(typeof(TournamentState))]
    public string? TournamentState { get; init; }
    
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Tournament, TournamentSimpleDto>();
        }
    }
}
