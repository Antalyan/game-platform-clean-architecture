using GameSystem.Application.Common.Interfaces;
using GameSystem.Domain.Enums;

namespace GameSystem.Application.GameContext.Commands.GameCommands;

public class DeleteGameCommandValidator : AbstractValidator<DeleteGameCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IUser _user;
    
    public DeleteGameCommandValidator(IApplicationDbContext context, IUser user)
    {
        _context = context;
        _user = user;

        RuleFor(command => command.Id)
            .NotEmpty()
            .MustAsync((commandId, cancellationToken) =>
                _context.Games
                    .Where(g => g.Id == commandId)
                    .AllAsync(g => g.CreatedBy == _user.Id, cancellationToken))
            .WithMessage("Given id must be correspond to a game created by this user");
    }
}
