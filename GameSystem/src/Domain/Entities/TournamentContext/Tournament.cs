using GameSystem.Domain.Entities.GameContext;
using GameSystem.Domain.Entities.PlayerContext;

namespace GameSystem.Domain.Entities.TournamentContext;

public class Tournament: BaseAuditableEntity
{
    public string? Name { get; init; }
    public string? Description { get; init; }
    public int? MaximalPlayersCount { get; set; }
    public TournamentState? TournamentState { get; set; }
    public IList<PlayerInTournament> PlayerList { get; set; } = new List<PlayerInTournament>();
    
    public IList<Game> GameList { get; set; } = new List<Game>();
    public IList<TournamentNotification> TournamentNotifications { get; set; } = new List<TournamentNotification>();
}
