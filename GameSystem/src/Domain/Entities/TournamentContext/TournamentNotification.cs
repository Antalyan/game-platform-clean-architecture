namespace GameSystem.Domain.Entities.TournamentContext;

public class TournamentNotification: BaseAuditableEntity
{
    public string? InviteText { get; init; }
    public bool IsValid { get; set; } = true;
    public Tournament? Tournament { get; init; }
    public int PlayerId { get; init; }
    
}
