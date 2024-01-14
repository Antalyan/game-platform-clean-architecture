using GameSystem.Domain.Enums;

namespace GameSystem.Application.GameContext.Commands.GameCommands;

public class SubmitGameCommandValidator : AbstractValidator<SubmitGameCommand>
{
    public SubmitGameCommandValidator()
    {
        RuleFor(g => g.Name)
            .MaximumLength(200)
            .NotEmpty();
        RuleFor(g => g.Visibility)
            .Must((command, visibility) => 
                (visibility == Visibility.Shared && command.SharedPlayers.Count > 0)
                || (visibility != Visibility.Shared && command.SharedPlayers.Count == 0))
            .WithMessage("Players to share are allowed only if visibility is shared");
    }
}
