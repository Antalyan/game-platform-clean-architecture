namespace GameSystem.Domain.Events.Game.Rules;

public class RulesCreatedEvent(Entities.Rules rule) : BaseEvent
{
    public Entities.Rules Rules { get; } = rule;
}
