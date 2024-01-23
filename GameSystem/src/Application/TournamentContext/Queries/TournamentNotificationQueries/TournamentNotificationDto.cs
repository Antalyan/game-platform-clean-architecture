using GameSystem.Domain.Entities.TournamentContext;

namespace GameSystem.Application.TournamentContext.Queries.TournamentNotificationQueries;

public class TournamentNotificationDto
{
    public string? InviteText { get; init; }
    public bool IsAccepted { get; init; }
    public int TournamentId { get; init; }
    public int PlayerId { get; init; }
    
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<TournamentNotification, TournamentNotificationDto>();
        }
    }
}
