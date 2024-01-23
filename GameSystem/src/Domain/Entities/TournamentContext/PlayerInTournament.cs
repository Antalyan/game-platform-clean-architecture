using GameSystem.Domain.Entities.PlayerContext;

namespace GameSystem.Domain.Entities.TournamentContext;

public class PlayerInTournament:BaseAuditableEntity
{
    public Player Player { get; set; } = null!;
    public Tournament Tournament { get; set; } = null!;
}
