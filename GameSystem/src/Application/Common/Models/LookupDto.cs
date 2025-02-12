﻿using GameSystem.Application.GameContext.Queries.RulesQueries;
using GameSystem.Domain.Entities;
using GameSystem.Domain.Entities.GameContext;

namespace GameSystem.Application.Common.Models;

public class LookupDto
{
    public int Id { get; init; }

    public string? Title { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<TodoList, LookupDto>();
            CreateMap<TodoItem, LookupDto>();
            CreateMap<Rules, RulesDto>();
        }
    }
}
