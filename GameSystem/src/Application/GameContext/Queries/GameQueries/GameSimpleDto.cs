﻿using GameSystem.Application.GameContext.Queries.RulesQueries;
using GameSystem.Domain.Entities.GameContext;
using GameSystem.Domain.Enums;

namespace GameSystem.Application.GameContext.Queries.GameQueries;

public class GameSimpleDto
{
    private int Id { get; init; }
    public string? Name { get; init; }
    public RulesDto Rules { get; init; } = null!;
    public Visibility Visibility { get; init; }
    
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Game, GameSimpleDto>();
        }
    }
}
