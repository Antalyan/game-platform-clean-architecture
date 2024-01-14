using GameSystem.Application.Common.Interfaces;
using GameSystem.Domain.Enums;

namespace GameSystem.Application.GameContext.Commands.GameCommands;

public class SubmitGameCommandValidator : AbstractValidator<SubmitGameCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IUser _user;
    
    public SubmitGameCommandValidator(IApplicationDbContext context, IUser user)
    {
        _context = context;
        _user = user;

        RuleFor(command => command.Name)
            .MaximumLength(200)
            .NotEmpty()
            .MustAsync((name, cancellationToken) =>
                _context.Games
                    .Where(g => g.CreatedBy == user.Id)
                    .AllAsync(g => g.Name != name, cancellationToken))
            .WithMessage("'{PropertyName}' must be unique for each user.")
            .WithErrorCode("Unique");

        RuleFor(command => command.Visibility)
            .Must((command, visibility) =>
                (visibility == Visibility.Shared && command.SharedPlayers.Count > 0)
                || (visibility != Visibility.Shared && command.SharedPlayers.Count == 0))
            .WithMessage("Players to share are required only if the visibility is shared");
        
        RuleFor(command => command.SharedPlayers)
            .Must(items => items == null || items.Distinct().Count() == items.Count)
            .WithMessage("Each item must be present only once in the list.");
    }
}
