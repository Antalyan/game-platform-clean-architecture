using GameSystem.Domain.Entities.TournamentContext;

namespace GameSystem.Domain.Events.TournamentContext;

public class TournamentCreatedEvent(Tournament tournament) : BaseEvent
{
    public Tournament Tournament { get; } = tournament;
}
