using GameSystem.Application.Game.Queries.GetRules;

namespace GameSystem.Application.GameContext.Queries.Rules;

public class GetRulesByIdQuery : IRequest<RulesDto?>
{
    public int RulesId { get; init; }
}
