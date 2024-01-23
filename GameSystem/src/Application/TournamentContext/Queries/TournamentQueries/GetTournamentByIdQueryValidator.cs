using GameSystem.Application.TournamentContext.Queries.TournamentNotificationQueries;

namespace GameSystem.Application.TournamentContext.Queries.TournamentQueries;

public class GetTournamentByIdQueryValidator : AbstractValidator<GetTournamentByIdQuery>
{
    public GetTournamentByIdQueryValidator()
    {
        RuleFor(q => q.TournamentId)
            .NotEmpty().WithMessage("Tournament id is required.");
    }
}
