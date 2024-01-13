using GameSystem.Application.GameContext.Queries.Rules;

namespace GameSystem.Application.Game.Queries.GetRules;

public class GetRulesQueryValidator : AbstractValidator<GetRulesByIdQuery>
{
    public GetRulesQueryValidator()
    {
        RuleFor(x => x.RulesId)
            .NotEmpty().WithMessage("Rule id is required.");
    }
}
