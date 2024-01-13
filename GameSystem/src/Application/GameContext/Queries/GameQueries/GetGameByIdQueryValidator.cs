using GameSystem.Application.GameContext.Queries.RulesQueries;

namespace GameSystem.Application.GameContext.Queries.GameQueries;

public class GetGameByIdQueryValidator : AbstractValidator<GetRulesByIdQuery>
{
    public GetGameByIdQueryValidator()
    {
        RuleFor(x => x.RulesId)
            .NotEmpty().WithMessage("Rule id is required.");
    }
}
