using GameSystem.Application.TournamentContext.Queries.TournamentQueries;

namespace GameSystem.Application.TournamentContext.Queries.TournamentNotificationQueries;

public class GetNotificationByIdQuery : IRequest<TournamentNotificationDto?>
{
    public int NotificationId { get; init; }
}
