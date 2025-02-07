﻿using System.ComponentModel.DataAnnotations;
using GameSystem.Domain.Entities.GameContext;
using GameSystem.Domain.Enums;

namespace GameSystem.Application.GameContext.Queries.RulesQueries;

public class RulesDto
{
    public int Id { get; init; }

    public int Players { get; init; }
    
    [EnumDataType(typeof(WinningCondition))]
    public string? WinningCondition { get; init; }
    
    [EnumDataType(typeof(GameType))]
    public string? GameType { get; init; }
    
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
