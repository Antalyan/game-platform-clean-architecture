using GameSystem.Application.GameContext.Queries.GameQueries;
using GameSystem.Domain.Entities.GameContext;

namespace GameSystem.Application.GameContext.Queries.GamePollQueries;

public class GamePollDto

{
    public IReadOnlyCollection<GameSimpleDto> SharedGames { get; set; } = new List<GameSimpleDto>();

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<GamePoll, GamePollDto>();
        }
    }
}
