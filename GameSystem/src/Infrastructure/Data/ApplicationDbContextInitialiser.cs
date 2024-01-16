using System.Runtime.InteropServices;
using GameSystem.Domain.Constants;
using GameSystem.Domain.Entities;
using GameSystem.Domain.Entities.CardContext;
using GameSystem.Domain.Entities.GameContext;
using GameSystem.Domain.Enums;
using GameSystem.Infrastructure.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace GameSystem.Infrastructure.Data;

public static class InitialiserExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();

        await initialiser.InitialiseAsync();

        await initialiser.SeedAsync();
    }
}

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // Default roles
        var administratorRole = new IdentityRole(Roles.Administrator);

        if (_roleManager.Roles.All(r => r.Name != administratorRole.Name))
        {
            await _roleManager.CreateAsync(administratorRole);
        }

        // Default users
        var administrator = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

        if (_userManager.Users.All(u => u.UserName != administrator.UserName))
        {
            await _userManager.CreateAsync(administrator, "Administrator1!");
            if (!string.IsNullOrWhiteSpace(administratorRole.Name))
            {
                await _userManager.AddToRolesAsync(administrator, new [] { administratorRole.Name });
            }
        }
        
        // Default data
        // Seed, if necessary

        if (!_context.Rules.Any())
        {
            _context.Rules.Add(new Rules
            {
                Id = 1,
                WinningCondition = WinningCondition.FullHand,
                Players = 4,
                CardsDrawnPerTurn = 4,
                CardsDrawnInitially = 2,
                CardsPlayedPerTurn = 3,
                CardsHandLimit = 1,
                GameType = 0
            });
            _context.Rules.Add(new Rules
            {
                Id = 2,
                WinningCondition = WinningCondition.EmptyHand,
                Players = 3,
                CardsDrawnPerTurn = 3,
                CardsDrawnInitially = 3,
                CardsPlayedPerTurn = 3,
                CardsHandLimit = 3,
                GameType = GameType.Uno
            });
        }
        
        if (!_context.Cards.Any())
        {
            var cardNames = Enumerable.Range(1, 10).Select(val => val.ToString()).ToList();
            cardNames.AddRange(new List<string>{"Q", "K", "J", "A"});
            for (int i = 0; i < cardNames.Count; i++)
            {
                var name = cardNames[i];
                _context.Cards.Add(new CardData
                {
                    Id = i + 1,
                    Name = $"{name}",
                    Text = "Common card",
                    GameType = GameType.MauMau
                });
            }
            _context.Cards.Add(new CardData
            {
                Name = $"Bang",
                Text = "BANG!",
                GameType = GameType.SimpleBang
            });
            _context.Cards.Add(new CardData
            {
                Name = $"Miss",
                Text = "Play to avoid bang effect",
                GameType = GameType.SimpleBang
            });
        }

        if (!_context.GameDecks.Any())
        {
            _context.GameDecks.Add(new GameDeck
            {
                Id = 3,
                Name = "Let it rain",
                GameType = 0
            });
        }

        if (!_context.TodoLists.Any())
        {
            _context.TodoLists.Add(new TodoList
            {
                Title = "Todo List",
                Items =
                {
                    new TodoItem { Title = "Make a todo list 📃" },
                    new TodoItem { Title = "Check off the first item ✅" },
                    new TodoItem { Title = "Realise you've already done two things on the list! 🤯"},
                    new TodoItem { Title = "Reward yourself with a nice, long nap 🏆" },
                }
            });

            await _context.SaveChangesAsync();
        }
    }
}
