namespace GameSystem.Application.GameContext.Commands.GameDeckCommands;

public record AddCardToDeckCommand: IRequest
{
    public int DeckId { get; init; }
    
    public int CardId { get; init; }
}
