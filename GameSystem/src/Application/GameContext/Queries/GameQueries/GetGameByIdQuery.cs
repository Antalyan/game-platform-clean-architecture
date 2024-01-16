namespace GameSystem.Application.GameContext.Queries.GameQueries;

public class GetGameByIdQuery : IRequest<GameDetailedDto?>
{
    public int GameId { get; init; }
}

