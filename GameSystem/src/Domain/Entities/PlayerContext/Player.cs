using GameSystem.Domain.Entities.TournamentContext;

namespace GameSystem.Domain.Entities.PlayerContext;

public class Player: BaseAuditableEntity
{
    public string? Name { get; init; }
    public string? EmailAddress { get; init; }
    public bool IsOpenToTournament { get; set; } = true;
    public IList<TournamentNotification> Notifications { get; set; } = new List<TournamentNotification>();
}
