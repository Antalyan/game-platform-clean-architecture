using GameSystem.Application.Common.Interfaces;
using GameSystem.Domain.Entities;
using GameSystem.Domain.Enums;
using GameSystem.Domain.Events;
using GameSystem.Domain.Events.Game.Rules;

namespace GameSystem.Application.TodoItems.Commands.CreateTodoItem;

public class CreateRulesCommand : IRequest<int>
{
    public int Players { get; init; }
    
    public WinningCondition WinningCondition { get; init; }
    
    public int CardsDrawnPerTurn { get; init; }
    
    public int CardsDrawnInitially { get; init; }
    
    public int CardsPlayedPerTurn { get; init; }

    public int CardsHandLimit { get; init; }
}

public class CreateRulesCommandHandler : IRequestHandler<CreateRulesCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateRulesCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateRulesCommand request, CancellationToken cancellationToken)
    {
        var entity = new Rules()
        {
            Players = request.Players,
            WinningCondition = request.WinningCondition,
            CardsDrawnPerTurn = request.CardsDrawnPerTurn,
            CardsPlayedPerTurn = request.CardsPlayedPerTurn,
            CardsDrawnInitially = request.CardsDrawnInitially,
            CardsHandLimit = request.CardsHandLimit
        };

        entity.AddDomainEvent(new RulesCreatedEvent(entity));

        _context.Rules.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
