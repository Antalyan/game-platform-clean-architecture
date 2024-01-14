using GameSystem.Application.Common.Interfaces;
using GameSystem.Domain.Entities.GameContext;
using GameSystem.Domain.Events.GameContext;

namespace GameSystem.Application.GameContext.Commands.GameDeckCommands;

public class AddCardToDeckCommandHandler(IApplicationDbContext context) : IRequestHandler<AddCardToDeckCommand>
{
    public async Task Handle(AddCardToDeckCommand request, CancellationToken cancellationToken)
    {
        var deck = await context.GameDecks
            .Include(deck => deck.CardList)
            .FirstOrDefaultAsync(deck => deck.Id == request.DeckId, cancellationToken);
        Guard.Against.NotFound(request.DeckId, deck);

        var newCard = await context.Cards
            .FindAsync([request.CardId], cancellationToken);
        Guard.Against.NotFound(request.CardId, newCard);
        
        Guard.Against.AgainstExpression(_ => newCard.GameType == deck.GameType, deck.GameType,
            $"Card with game type: {newCard.GameType} cannot be assigned to a game of different type: {deck.GameType}");

        var cardInList = deck.CardList.FirstOrDefault(card => card.CardData.Id == newCard.Id);
        if (cardInList == null)
        {
            var addedCard = new CardInDeck { CardData = newCard, Quantity = 1, GameDeckId = deck.Id };
            deck.CardList.Add(addedCard);
            addedCard.AddDomainEvent(new CardAddedToDeckEvent(addedCard, deck));
        }
        else
        {
            cardInList.Quantity += 1;
            cardInList.AddDomainEvent(new CardAddedToDeckEvent(cardInList, deck));
        }
        
        await context.SaveChangesAsync(cancellationToken);
    }
}
