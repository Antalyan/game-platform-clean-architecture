using GameSystem.Domain.Enums;

namespace GameSystem.Application.GameContext.Queries.GameQueries;

public record GetAvailableGamesQuery() : IRequest<IReadOnlyCollection<GameSimpleDto>>
{
    public Visibility? Visibility { get; set; }
}
