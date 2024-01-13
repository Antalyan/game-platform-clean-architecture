using GameSystem.Domain.Entities;
using GameSystem.Domain.Entities.CardContext;
using GameSystem.Domain.Entities.GameContext;

namespace GameSystem.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Rules> Rules { get; }

    DbSet<TodoItem> TodoItems { get; }
    
    DbSet<TodoList> TodoLists { get; }
    
    DbSet<Domain.Entities.GameContext.Game> Games { get; }
    DbSet<GameDeck> GameDecks { get; }
    DbSet<GamePoll> GamePolls { get; }
    DbSet<Card> Cards { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
