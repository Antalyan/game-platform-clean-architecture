namespace GameSystem.Domain.Entities.GameContext;

public class GamePoll: BaseAuditableEntity
{
    public IList<Game> SharedGames { get; set; } = new List<Game>();
}
