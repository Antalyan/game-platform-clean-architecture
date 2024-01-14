using GameSystem.Application.GameContext.Queries.GameDeckQueries;
using GameSystem.Application.GameContext.Queries.RulesQueries;
using GameSystem.Domain.Entities.GameContext;
using GameSystem.Domain.Enums;

namespace GameSystem.Application.GameContext.Queries.GameQueries;

public class GameDetailedDto
{
    private int Id { get; init; }
    public string? Name { get; init; }
    public GameDeckDto Deck { get; init; } = null!;
    public RulesDto Rules { get; init; } = null!;
    public Visibility Visibility { get; init; }
    
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Game, GameDetailedDto>();
        }
    }
}
