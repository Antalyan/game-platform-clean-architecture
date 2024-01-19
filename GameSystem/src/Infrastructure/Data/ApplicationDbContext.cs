﻿using System.Reflection;
using GameSystem.Application.Common.Interfaces;
using GameSystem.Domain.Entities;
using GameSystem.Domain.Entities.CardContext;
using GameSystem.Domain.Entities.GameContext;
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
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        base.OnModelCreating(builder);
    }
}
