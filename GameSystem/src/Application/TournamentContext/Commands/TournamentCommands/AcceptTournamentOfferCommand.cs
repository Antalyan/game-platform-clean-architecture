namespace GameSystem.Application.TournamentContext.Commands.TournamentCommands;

public class AcceptTournamentOfferCommand : IRequest
{
    public int TournamentNotificationId { get; init; }
}
