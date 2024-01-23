using GameSystem.Domain.Entities.PlayerContext;
using GameSystem.Domain.Entities.TournamentContext;
using GameSystem.Domain.Events.TournamentContext;

namespace GameSystem.Application.TournamentContext.EventHandlers;

using GameSystem.Application.Common.Interfaces;
using GameSystem.Domain.Entities.GameContext;
using GameSystem.Domain.Events.GameContext;
using Microsoft.Extensions.Logging;

public class TournamentPlayersInvitedEventHandler(ILogger<TournamentPlayersInvitedEventHandler> logger,
        IApplicationDbContext context)
    : INotificationHandler<TournamentPlayersInvitedEvent>
{

    public async Task Handle(TournamentPlayersInvitedEvent eventTournamentPlayersInvitedEvent, CancellationToken cancellationToken)
    {
        
        logger.LogInformation("Invite free open players");
        var players = context.Players.Where(player => player.IsOpenToTournament).ToList();
        var tournament = eventTournamentPlayersInvitedEvent.Tournament;
        context.Notifications.AddRange(await CreateNotifications(tournament, players, cancellationToken));
        eventTournamentPlayersInvitedEvent.Tournament.AddDomainEvent(new UserNotifiedEvent(players,tournament));
        logger.LogInformation("Notification sent");
        await context.SaveChangesAsync(cancellationToken);
    }

    private async Task<IList<TournamentNotification>> CreateNotifications(Tournament tournament, IList<Player> players, CancellationToken cancellationToken)
    {
        IList<TournamentNotification> notifications = new List<TournamentNotification>();
        foreach (var player in players)
        {
            var inviteText = $"Hi {player.Name}, I 'd like to invite you to {tournament.Name}";
            var notification = new TournamentNotification
            {
                InviteText = inviteText,
                PlayerId = player.Id,
                TournamentId = tournament.Id,
                IsAccepted = false
            };
            notifications.Add(notification);
            
        }
        await context.SaveChangesAsync(cancellationToken);
        return notifications;

    }
}
