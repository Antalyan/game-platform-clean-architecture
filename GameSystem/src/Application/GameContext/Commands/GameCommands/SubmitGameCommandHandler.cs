using GameSystem.Application.Common.Interfaces;
using GameSystem.Application.GameContext.Commands.GameDeckCommands;
using GameSystem.Domain.Entities.GameContext;
using GameSystem.Domain.Events.GameContext;

namespace GameSystem.Application.GameContext.Commands.GameCommands;

public class SubmitGameCommandHandler(IApplicationDbContext context) : IRequestHandler<SubmitGameCommand, int>
{
    public async Task<int> Handle(SubmitGameCommand request, CancellationToken cancellationToken)
    {
        var deck = await context.GameDecks
            .FirstOrDefaultAsync(deck => deck.Id == request.DeckId, cancellationToken);
        Guard.Against.NotFound(request.DeckId, deck);

        var rules = await context.Rules
            .FindAsync([request.RulesId], cancellationToken);
        Guard.Against.NotFound(request.RulesId, rules);
        
        Guard.Against.AgainstExpression(_ => deck.GameType == rules.GameType, deck.GameType,
            $"Rules with game type: {rules.GameType} cannot be assigned to a deck with of a different game type: {deck.GameType}");
        
        var newGame = new Game { Deck = deck, Rules = rules, Name = request.Name, Visibility = request.Visibility };
        context.Games.Add(newGame);
        
        newGame.AddDomainEvent(new GameSubmittedEvent(newGame, request.SharedPlayers));
        
        await context.SaveChangesAsync(cancellationToken);
        
        return newGame.Id;
    }
}

