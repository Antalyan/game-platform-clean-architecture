namespace GameSystem.Application.TournamentContext.Queries.PlayerQueries;

public class GetPlayerByIdQueryValidator : AbstractValidator<GetPlayerByIdQuery>
{
    public GetPlayerByIdQueryValidator()
    {
        RuleFor(q => q.PlayerId)
            .NotEmpty().WithMessage("Player id is required.");
    }
}
