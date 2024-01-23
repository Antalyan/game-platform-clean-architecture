using GameSystem.Application.Common.Interfaces;
using GameSystem.Application.TournamentContext.Commands.TournamentCommands;
using GameSystem.Domain.Entities.TournamentContext;
using GameSystem.Domain.Enums;
using GameSystem.Domain.Events.TournamentContext;

namespace GameSystem.Application.TournamentContext.Commands.TournamentNotificationCommands;

public class InvitePlayersToTournamentCommandHandler(IApplicationDbContext context) : IRequestHandler<InvitePlayersToTournamentCommand, int>
{
    public async Task<int> Handle(InvitePlayersToTournamentCommand request, CancellationToken cancellationToken)
    {
        var tournament =
            await context.Tournaments.FirstOrDefaultAsync
                (tournament => tournament.Id == request.TournamentId, cancellationToken: cancellationToken);
        Guard.Against.NotFound(request.TournamentId, tournament);
        tournament.TournamentState ??= TournamentState.OpenToPlayers;
        
        Guard.Against.AgainstExpression(_ => tournament.TournamentState != TournamentState.OpenToPlayers,
            tournament.PlayerList.Count,
            "Game is closed to the new players");
        
        Guard.Against.AgainstExpression(_ => tournament.PlayerList.Count < tournament.MaximalPlayersCount,
            tournament.PlayerList.Count,
            "Game is already Full");
        
    
        tournament.AddDomainEvent(new TournamentPlayersInvitedEvent(tournament));
        await context.SaveChangesAsync(cancellationToken);
        return tournament.Id;
    }
}
