using GameSystem.Application.Common.Interfaces;
using GameSystem.Domain.Entities.GameContext;
using GameSystem.Domain.Events.GameContext;

namespace GameSystem.Application.GameContext.Commands.GameDeckCommands;

public class CreateDeckCommandHandler(IApplicationDbContext context) : IRequestHandler<CreateDeckCommand, int>
{
    public async Task<int> Handle(CreateDeckCommand request, CancellationToken cancellationToken)
    {
        var deck = new GameDeck
        {
           Name = request.Name,
           GameType = request.GameType
        };

        deck.AddDomainEvent(new GameDeckCreatedEvent(deck));

        context.GameDecks.Add(deck);

        await context.SaveChangesAsync(cancellationToken);

        return deck.Id;
    }
}

