using GameSystem.Application.Common.Interfaces;
using GameSystem.Domain.Events.GameContext;

namespace GameSystem.Application.GameContext.Commands.RulesCommands;

public class CreateRulesCommandHandler(IApplicationDbContext context) : IRequestHandler<CreateRulesCommand, int>
{
    public async Task<int> Handle(CreateRulesCommand request, CancellationToken cancellationToken)
    {
        var rules = new Domain.Entities.GameContext.Rules()
        {
            Players = request.Players,
            WinningCondition = request.WinningCondition,
            GameType = request.GameType,
            CardsDrawnPerTurn = request.CardsDrawnPerTurn,
            CardsPlayedPerTurn = request.CardsPlayedPerTurn,
            CardsDrawnInitially = request.CardsDrawnInitially,
            CardsHandLimit = request.CardsHandLimit
        };

        rules.AddDomainEvent(new RulesCreatedEvent(rules));
        context.Rules.Add(rules);
        await context.SaveChangesAsync(cancellationToken);

        return rules.Id;
    }
}
