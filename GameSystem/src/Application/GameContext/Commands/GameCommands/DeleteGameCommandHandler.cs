using GameSystem.Application.Common.Interfaces;
using GameSystem.Domain.Events.GameContext;

namespace GameSystem.Application.GameContext.Commands.GameCommands;

public class DeleteGameCommandHandler(IApplicationDbContext context) : IRequestHandler<DeleteGameCommand>
{
    public async Task Handle(DeleteGameCommand request, CancellationToken cancellationToken)
    {
        var game = await context.Games
            .Where(g => g.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        Guard.Against.NotFound(request.Id, game);

        context.Games.Remove(game);
        
        game.AddDomainEvent(new GameDeletedEvent(game));

        await context.SaveChangesAsync(cancellationToken);
    }
}

