using System.Reflection;
using GameSystem.Application.Common.Interfaces;
using GameSystem.Domain.Entities;
using GameSystem.Domain.Entities.CardContext;
using GameSystem.Domain.Entities.GameContext;
using GameSystem.Domain.Entities.PlayerContext;
using GameSystem.Domain.Entities.TournamentContext;
using GameSystem.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameSystem.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<TodoList> TodoLists => Set<TodoList>();

    
    public DbSet<TodoItem> TodoItems => Set<TodoItem>();
    
    public DbSet<Rules> Rules => Set<Rules>();
    
    public DbSet<Game> Games => Set<Game>();

    public DbSet<GameDeck> GameDecks => Set<GameDeck>();

    public DbSet<GamePoll> GamePolls => Set<GamePoll>();
    
    public DbSet<CardData> Cards => Set<CardData>();

    public DbSet<Tournament> Tournaments => Set<Tournament>();
    public DbSet<Player> Players => Set<Player>();
    public DbSet<TournamentNotification> Notifications => Set<TournamentNotification>();
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        base.OnModelCreating(builder);
    }
}
