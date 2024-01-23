namespace GameSystem.Domain.Entities.TournamentContext;

public class TournamentNotification: BaseAuditableEntity
{
    public string? InviteText { get; init; }
    public bool IsAccepted { get; set; } = false;
    public int TournamentId { get; init; }
    public int PlayerId { get; init; }
    
}
