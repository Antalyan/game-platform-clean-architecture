namespace GameSystem.Application.GameContext.Queries.RulesQueries;

public class GetRulesByIdQuery : IRequest<RulesDto?>
{
    public int RulesId { get; init; }
}
