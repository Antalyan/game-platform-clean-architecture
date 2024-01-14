namespace GameSystem.Application.GameContext.Queries.GameDeckQueries;

public class GetGameDeckByIdQueryValidator : AbstractValidator<GetGameDeckByIdQuery>
{
    public GetGameDeckByIdQueryValidator()
    {
        RuleFor(q => q.GameDeckId)
            .NotEmpty().WithMessage("Game deck id is required.");
    }
}
