using GameSystem.Application.Common.Interfaces;
using GameSystem.Application.TodoItems.Commands.CreateTodoItem;
using GameSystem.Domain.Events.Game.Rules;

namespace GameSystem.Application.GameContext.Commands.Rules;

public class CreateRulesCommandHandler(IApplicationDbContext context) : IRequestHandler<CreateRulesCommand, int>
{
    public async Task<int> Handle(CreateRulesCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.Rules()
        {
            Players = request.Players,
            WinningCondition = request.WinningCondition,
            CardsDrawnPerTurn = request.CardsDrawnPerTurn,
            CardsPlayedPerTurn = request.CardsPlayedPerTurn,
            CardsDrawnInitially = request.CardsDrawnInitially,
            CardsHandLimit = request.CardsHandLimit
        };

        entity.AddDomainEvent(new RulesCreatedEvent(entity));

        context.Rules.Add(entity);

        await context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
