using GameSystem.Domain.Entities;
using GameSystem.Domain.Enums;

namespace GameSystem.Application.Game.Queries.GetRules;

public class RulesDto
{
    public int Id { get; init; }

    public int Players { get; init; }
    
    public WinningCondition WinningCondition { get; init; }
    
    public int CardsDrawnPerTurn { get; init; }
    
    public int CardsDrawnInitially { get; init; }
    
    public int CardsPlayedPerTurn { get; init; }

    public int CardsHandLimit { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Rules, RulesDto>();
        }
    }
}
