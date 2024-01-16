namespace GameSystem.Application.GameContext.Queries.GameQueries;

public class GetGameByIdQueryValidator : AbstractValidator<GetGameByIdQuery>
{
    public GetGameByIdQueryValidator()
    {
        RuleFor(q => q.GameId)
            .NotEmpty().WithMessage("Game id is required.");
    }
}
