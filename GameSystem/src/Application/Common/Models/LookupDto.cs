using GameSystem.Application.Game.Queries.GetRules;
using GameSystem.Domain.Entities;

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
