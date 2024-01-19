namespace GameSystem.Domain.Entities.PlayerContext;

public class Player: BaseAuditableEntity
{
    public string? Name { get; init; }
    public string? EmailAddress { get; init; }
    public DateTime RegisterDate { get; init; }
    public bool IsOpenToTournament { get; set; } = true;
}
