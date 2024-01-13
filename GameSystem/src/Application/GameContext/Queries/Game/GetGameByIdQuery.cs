using GameSystem.Application.Common.Interfaces;
using GameSystem.Application.Game.Queries.GetRules;

namespace GameSystem.Application.GameContext.Queries.Rules;

public class GetGameByIdQuery : IRequest<RulesDto?>
{
    public int RulesId { get; init; }
}

