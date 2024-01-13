using GameSystem.Application.GameContext.Queries.RulesQueries;

namespace GameSystem.Application.GameContext.Queries.GameQueries;

public class GetGameByIdQuery : IRequest<RulesDto?>
{
    public int RulesId { get; init; }
}

