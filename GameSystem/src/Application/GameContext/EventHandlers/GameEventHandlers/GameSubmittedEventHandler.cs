using GameSystem.Application.Common.Interfaces;
using GameSystem.Domain.Entities.GameContext;
using GameSystem.Domain.Events.GameContext;
using Microsoft.Extensions.Logging;

namespace GameSystem.Application.GameContext.EventHandlers.GameEventHandlers;

public class GameSubmittedEventHandler(ILogger<GameSubmittedEventHandler> logger, IApplicationDbContext context)
    : INotificationHandler<GameSubmittedEvent>
{
    private IList<GamePoll> _updatedPolls = new List<GamePoll>();
    
    public async Task Handle(GameSubmittedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("GameSystem Domain Event: {DomainEvent}", notification.GetType().Name);
        
        await AddGameToPolls(notification.Game, notification.SharedPlayers, cancellationToken);
        notification.Game.AddDomainEvent(new GameAppearedInPollsEvent(notification.Game, _updatedPolls));
        await context.SaveChangesAsync(cancellationToken);
    }

    private async Task AddGameToPolls(Game game, IList<string> players, CancellationToken cancellationToken)
    {
        foreach (var player in players)
        {
            var poll = await context.GamePolls
                .Include(poll => poll.SharedGames)
                .FirstOrDefaultAsync(poll => poll.CreatedBy == game.CreatedBy, cancellationToken);
            if (poll == null)
            {
                poll = new GamePoll { SharedGames = { game }, CreatedBy = player};
                context.GamePolls.Add(poll);
                _updatedPolls.Add(poll);
            }
            else
            {
                if (!poll.SharedGames.Contains(game))
                {
                    poll.SharedGames.Add(game);
                    _updatedPolls.Add(poll);
                }
            }
        }
    }
}
