namespace GameSystem.Application.TournamentContext.Commands.TournamentCommands;

public class CreateTournamentCommand:  IRequest<int>
{
    public string? Name { get; init; }
    public string? Description { get; init; }
    
}
