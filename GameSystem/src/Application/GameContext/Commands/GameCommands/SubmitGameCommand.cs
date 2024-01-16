using GameSystem.Domain.Enums;

namespace GameSystem.Application.GameContext.Commands.GameCommands;

public record SubmitGameCommand : IRequest<int>
{
    public string? Name { get; set; }
    public int DeckId { get; set; }
    public int RulesId { get; set; }
    public Visibility Visibility { get; set; }
    public IList<string> SharedPlayers { get; set; } = new List<string>();
}
