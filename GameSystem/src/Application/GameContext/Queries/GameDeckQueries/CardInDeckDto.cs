using GameSystem.Domain.Entities.GameContext;

namespace GameSystem.Application.GameContext.Queries.GameDeckQueries;

public class CardInDeckDto
{
    public string? Name { get; init; }
    public string? Text { get; init; }
    public int Quantity { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<CardInDeck, CardInDeckDto>()
                .ForMember(deckCard => deckCard.Name,
                    opt => opt.MapFrom(card => card.CardData.Name))
                .ForMember(deckCard => deckCard.Text,
                    opt => opt.MapFrom(card => card.CardData.Text));
        }
    }
}
