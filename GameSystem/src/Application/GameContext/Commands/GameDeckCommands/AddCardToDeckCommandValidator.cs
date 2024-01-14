using GameSystem.Application.Common.Interfaces;

namespace GameSystem.Application.GameContext.Commands.GameDeckCommands;

public class AddCardToDeckCommandValidator : AbstractValidator<AddCardToDeckCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IUser _user;
    
    public AddCardToDeckCommandValidator(IApplicationDbContext context, IUser user)
    {
        _context = context;
        _user = user;

        RuleFor(command => command.DeckId)
            .NotEmpty()
            .MustAsync((deckId, cancellationToken) =>
                _context.Games
                    .Where(g => g.Id == deckId)
                    .AllAsync(g => g.CreatedBy == _user.Id, cancellationToken))
            .WithMessage("Given id must be correspond to a deck created by this user");
    }
}
