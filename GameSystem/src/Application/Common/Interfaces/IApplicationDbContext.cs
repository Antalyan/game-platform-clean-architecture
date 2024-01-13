using GameSystem.Domain.Entities;

namespace GameSystem.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Rules> Rules { get; }

    DbSet<TodoItem> TodoItems { get; }
    
    DbSet<TodoList> TodoLists { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
