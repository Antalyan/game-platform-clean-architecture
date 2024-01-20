using GameSystem.Application.Common.Interfaces;
using GameSystem.Application.TournamentContext.Commands.TournamentCommands;
using GameSystem.Domain.Entities.TournamentContext;
using GameSystem.Domain.Events.TournamentContext;

namespace GameSystem.Application.TournamentContext.Commands.TournamentNotificationCommands;

public class CreateTournamentNotificationCommandHandler(IApplicationDbContext context) : IRequestHandler<CreateTournamentNotificationCommand, int>
{
    public async Task<int> Handle(CreateTournamentNotificationCommand request, CancellationToken cancellationToken)
    {
        var notification = new TournamentNotification
        {
            InviteText = request.InviteText,
            PlayerId = request.PlayerId,
            TournamentId = request.TournamentId,
            IsAccepted = false
        };
            
        var tournament =
            await context.Tournaments.FirstOrDefaultAsync
                (tournament => tournament.Id == notification.TournamentId);
        Guard.Against.NotFound(notification.TournamentId, tournament);
        
        Guard.Against.AgainstExpression(_ => notification.IsAccepted == false, notification.IsAccepted,
            $"You already accept offer");
        Guard.Against.AgainstExpression(_ => tournament.PlayerList.Count < tournament.MaximalPlayersCount,
            tournament.PlayerList.Count,
            "Game is already Full");
        
        var playerInTournament = new PlayerInTournament { };
        tournament.PlayerList.Add(playerInTournament);
        notification.IsAccepted = true;
        notification.AddDomainEvent(new TournamentPlayersInvitedEvent(notification));
     
        
        await context.SaveChangesAsync(cancellationToken);
        return notification.Id;
    }
}
