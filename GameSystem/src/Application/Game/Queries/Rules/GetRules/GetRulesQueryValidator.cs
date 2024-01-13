namespace GameSystem.Application.Game.Queries.GetRules;

public class GetRulesQueryValidator : AbstractValidator<GetRulesQuery>
{
    public GetRulesQueryValidator()
    {
        RuleFor(x => x.RulesId)
            .NotEmpty().WithMessage("Rule id is required.");
    }
}
