using GameSystem.Application.Common.Interfaces;
using GameSystem.Application.GameContext.Commands.GameDeckCommands;
using GameSystem.Domain.Entities.GameContext;
using GameSystem.Domain.Entities.TournamentContext;
using GameSystem.Domain.Events.GameContext;
using GameSystem.Domain.Events.TournamentContext;

namespace GameSystem.Application.TournamentContext.Commands.TournamentCommands;


public class CreateTournamentCommandHandler(IApplicationDbContext context) : IRequestHandler<CreateTournamentCommand, int>
{
    public async Task<int> Handle(CreateTournamentCommand request, CancellationToken cancellationToken)
    {
      
        var tournament = new Tournament { Name = request.Name, Description = request.Description };
        tournament.AddDomainEvent(new TournamentCreatedEvent(tournament));

        context.Tournaments.Add(tournament);

        await context.SaveChangesAsync(cancellationToken);

        return tournament.Id;
    }
}
