using GameSystem.Application.Common.Interfaces;
using GameSystem.Domain.Entities.GameContext;

namespace GameSystem.Application.GameContext.Commands.GameDeckCommands;

public class AddCardToDeckCommandHandler(IApplicationDbContext context) : IRequestHandler<AddCardToDeckCommand>
{
    public async Task Handle(AddCardToDeckCommand request, CancellationToken cancellationToken)
    {
        var deckList = await context.GameDecks
            .Include(deck => deck.CardList)
            .FirstOrDefaultAsync(deck => deck.Id == request.DeckId, cancellationToken);
        Guard.Against.NotFound(request.DeckId, deckList);

        var newCard = await context.Cards
            .FindAsync([request.CardId], cancellationToken);
        Guard.Against.NotFound(request.CardId, newCard);
        
        Guard.Against.AgainstExpression(_ => newCard.GameType == deckList.GameType, deckList.GameType,
            $"Card with game type: {newCard.GameType} cannot be assigned to a game of different type: {deckList.GameType}");

        var cardInList = deckList.CardList.FirstOrDefault(card => card.CardId == newCard.Id);
        if (cardInList == null)
        {
            deckList.CardList.Add(new CardInDeck{CardId = newCard.Id, Quantity = 1, GameDeckId = deckList.Id});
        }
        else
        {
            cardInList.Quantity += 1;
        }
        await context.SaveChangesAsync(cancellationToken);
    }
}
