using GameSystem.Application.GameContext.Queries.Rules;

namespace GameSystem.Application.Game.Queries.GetRules;

public class GetGameByIdQueryValidator : AbstractValidator<GetRulesByIdQuery>
{
    public GetGameByIdQueryValidator()
    {
        RuleFor(x => x.RulesId)
            .NotEmpty().WithMessage("Rule id is required.");
    }
}
