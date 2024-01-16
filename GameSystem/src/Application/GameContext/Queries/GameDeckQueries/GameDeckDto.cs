using GameSystem.Domain.Entities.GameContext;

namespace GameSystem.Application.GameContext.Queries.GameDeckQueries;

public class GameDeckDto
{
    public string? Name { get; init; }
    
    public IReadOnlyCollection<CardInDeckDto> CardList { get; set; } = new List<CardInDeckDto>();
    
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<GameDeck, GameDeckDto>();
        }
    }
}
