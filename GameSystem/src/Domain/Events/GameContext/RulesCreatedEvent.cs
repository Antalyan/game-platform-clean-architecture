namespace GameSystem.Domain.Events.GameContext;

public class RulesCreatedEvent(Entities.GameContext.Rules rule) : BaseEvent
{
    public Entities.GameContext.Rules Rules { get; } = rule;
}
