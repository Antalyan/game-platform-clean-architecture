using GameSystem.Application.Common.Interfaces;
using GameSystem.Domain.Events.GameContext;

namespace GameSystem.Application.GameContext.Commands.GameDeckCommands;

public class CreateDeckCommandHandler(IApplicationDbContext context) : IRequestHandler<CreateDeckCommand, int>
{
    public async Task<int> Handle(CreateDeckCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.GameContext.GameDeck
        {
           Name = request.Name,
           GameType = request.GameType
        };

        entity.AddDomainEvent(new GameDeckCreatedEvent(entity));

        context.GameDecks.Add(entity);

        await context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}

