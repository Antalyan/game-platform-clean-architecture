using GameSystem.Application.Common.Interfaces;

namespace GameSystem.Application.TournamentContext.Commands.TournamentCommands;

public class AcceptTournamentOfferCommandValidator : AbstractValidator<AcceptTournamentOfferCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IUser _user;

    public AcceptTournamentOfferCommandValidator(IApplicationDbContext context, IUser user)
    {
        _context = context;
        _user = user;

        RuleFor(command => command.TournamentNotificationId)
            .NotEmpty()
            .MustAsync((notificationId, cancellationToken) =>
                _context.Notifications
                    .Where(g => g.Id == notificationId)
                    .AllAsync(g => g.CreatedBy == _user.Id && g.IsAccepted, cancellationToken))
            .WithMessage(
                "Given id must be correspond to a Notification created by this user and Notification must be accepted");
    }
}
