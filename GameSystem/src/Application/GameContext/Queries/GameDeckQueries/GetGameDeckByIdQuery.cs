namespace GameSystem.Application.GameContext.Queries.GameDeckQueries;

public class GetGameDeckByIdQuery : IRequest<GameDeckDto?>
{
    public int GameDeckId { get; init; }
}

