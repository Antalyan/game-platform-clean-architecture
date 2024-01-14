using System.ComponentModel.DataAnnotations;
using GameSystem.Application.GameContext.Queries.RulesQueries;
using GameSystem.Domain.Entities.GameContext;
using GameSystem.Domain.Enums;

namespace GameSystem.Application.GameContext.Queries.GameQueries;

public class GameSimpleDto
{
    public int Id { get; init; }
    public string? Name { get; init; }
    public RulesDto Rules { get; init; } = null!;
    
    [EnumDataType(typeof(Visibility))]
    public string? Visibility { get; init; }
    
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Game, GameSimpleDto>();
        }
    }
}
