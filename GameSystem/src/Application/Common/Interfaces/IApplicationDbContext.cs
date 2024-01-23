using GameSystem.Domain.Entities;
using GameSystem.Domain.Entities.CardContext;
using GameSystem.Domain.Entities.GameContext;
using GameSystem.Domain.Entities.PlayerContext;
using GameSystem.Domain.Entities.TournamentContext;

namespace GameSystem.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Rules> Rules { get; }

    DbSet<TodoItem> TodoItems { get; }
    
    DbSet<TodoList> TodoLists { get; }
    
    DbSet<Game> Games { get; }
    DbSet<GameDeck> GameDecks { get; }
    DbSet<GamePoll> GamePolls { get; }
    DbSet<CardData> Cards { get; }
    
    DbSet<Tournament> Tournaments { get; }
    DbSet<TournamentNotification> Notifications { get; }
    DbSet<Player> Players { get; }
    DbSet<PlayerInTournament> PlayerInTournaments { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
