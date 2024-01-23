using GameSystem.Application.Common.Interfaces;
using GameSystem.Application.GameContext.Commands.GameDeckCommands;
using GameSystem.Domain.Entities.GameContext;
using GameSystem.Domain.Entities.TournamentContext;
using GameSystem.Domain.Events.GameContext;
using GameSystem.Domain.Events.TournamentContext;

namespace GameSystem.Application.TournamentContext.Commands.TournamentCommands;

public class AcceptTournamentOfferCommandHandler
    (IApplicationDbContext context) : IRequestHandler<AcceptTournamentOfferCommand>
{
    public async Task Handle(AcceptTournamentOfferCommand request, CancellationToken cancellationToken)
    {
        var notification =
            await context.Notifications.FirstOrDefaultAsync(
                notification => notification.Id == request.TournamentNotificationId, cancellationToken);
        Guard.Against.NotFound(request.TournamentNotificationId, notification);
        var tournament =
            await context.Tournaments.FirstOrDefaultAsync
                (tournament => tournament.Id == notification.TournamentId);
        Guard.Against.NotFound(notification.TournamentId, tournament);

        Guard.Against.AgainstExpression(_ => notification.IsAccepted == false, notification.IsAccepted,
            $"You already accept offer");
        Guard.Against.AgainstExpression(_ => tournament.PlayerList.Count < tournament.MaximalPlayersCount,
            tournament.PlayerList.Count,
            "Game is already Full");

        notification.IsAccepted = true;
        notification.AddDomainEvent(new TournamentNotificationAcceptedEvent(notification));


        await context.SaveChangesAsync(cancellationToken);
    }
}
