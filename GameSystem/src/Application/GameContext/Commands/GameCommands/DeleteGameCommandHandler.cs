using GameSystem.Application.Common.Interfaces;

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

        await context.SaveChangesAsync(cancellationToken);
    }
}

