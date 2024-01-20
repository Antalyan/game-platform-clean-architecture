namespace GameSystem.Application.TournamentContext.Commands.TournamentNotificationCommands;

public class CreateTournamentNotificationCommand: IRequest<int>
{
     public string? InviteText { get; init; }
     public int TournamentId { get; init; }
     public int PlayerId { get; init; }
}
