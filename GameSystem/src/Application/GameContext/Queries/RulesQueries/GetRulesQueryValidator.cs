namespace GameSystem.Application.GameContext.Queries.RulesQueries;

public class GetRulesQueryValidator : AbstractValidator<GetRulesByIdQuery>
{
    public GetRulesQueryValidator()
    {
        RuleFor(x => x.RulesId)
            .NotEmpty().WithMessage("Rule id is required.");
    }
}
