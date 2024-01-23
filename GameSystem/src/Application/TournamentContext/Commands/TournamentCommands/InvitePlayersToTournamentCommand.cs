namespace GameSystem.Application.TournamentContext.Commands.TournamentNotificationCommands;

public class InvitePlayersToTournamentCommand: IRequest<int>
{
     
     public int TournamentId { get; init; }
     
}
