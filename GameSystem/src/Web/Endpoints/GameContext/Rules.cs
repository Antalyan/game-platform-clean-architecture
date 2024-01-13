using GameSystem.Application.Game.Queries.GetRules;
using GameSystem.Application.GameContext.Commands.Rules;
using GameSystem.Application.GameContext.Queries.Rules;

namespace GameSystem.Web.Endpoints;

public class Rules : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetRules)
            .MapPost(CreateRules);
    }

    public static async Task<RulesDto?> GetRules(ISender sender, [AsParameters] GetRulesByIdQuery byIdQuery)
    {
        return await sender.Send(byIdQuery);
    }
    
    public static async Task<int> CreateRules(ISender sender, CreateRulesCommand command)
    {
        return await sender.Send(command);
    }
}
