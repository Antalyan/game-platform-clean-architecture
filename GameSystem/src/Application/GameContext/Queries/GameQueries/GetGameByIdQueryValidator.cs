namespace GameSystem.Application.GameContext.Queries.GameQueries;

public class GetGameByIdQueryValidator : AbstractValidator<GetGameByIdQuery>
{
    public GetGameByIdQueryValidator()
    {
        RuleFor(x => x.GetType())
            .NotEmpty().WithMessage("Rule id is required.");
    }
}
