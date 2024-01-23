using GameSystem.Application.Common.Interfaces;
using GameSystem.Domain.Entities.TournamentContext;
using GameSystem.Domain.Events.TournamentContext;
using Microsoft.Extensions.Logging;

namespace GameSystem.Application.TournamentContext.EventHandlers;

public class TournamentNotificationAcceptedHandler(ILogger<TournamentNotificationAcceptedHandler> logger,
        IApplicationDbContext context)
    : INotificationHandler<TournamentNotificationAcceptedEvent>
{
    public async Task Handle(TournamentNotificationAcceptedEvent tournamentNotificationAcceptedEvent,
        CancellationToken cancellationToken)
    {
        var player =
            await context.Players.FirstOrDefaultAsync(p =>
                p.Id == tournamentNotificationAcceptedEvent.Notification.PlayerId);
        if (player == null)
        {
            logger.LogInformation("Player not exist");
            return;
        }

        var tournament = await
            context.Tournaments.FirstOrDefaultAsync(t =>
                t.Id == tournamentNotificationAcceptedEvent.Notification.TournamentId);
        if (tournament == null)
        {
            logger.LogInformation("Tournament not exist");
            return;
        }

        var playerInTournament = new PlayerInTournament { Player = player, Tournament = tournament };
        tournament.PlayerList.Add(playerInTournament);
        playerInTournament.AddDomainEvent(new PlayerAddedToTournamentEvent(playerInTournament,tournament));
    }
}
