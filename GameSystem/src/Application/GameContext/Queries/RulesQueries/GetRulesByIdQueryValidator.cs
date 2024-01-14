namespace GameSystem.Application.GameContext.Queries.RulesQueries;

public class GetRulesByIdQueryValidator : AbstractValidator<GetRulesByIdQuery>
{
    public GetRulesByIdQueryValidator()
    {
        RuleFor(x => x.RulesId)
            .NotEmpty().WithMessage("Rule id is required.");
    }
}
