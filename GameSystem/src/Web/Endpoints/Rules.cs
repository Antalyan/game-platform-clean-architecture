using GameSystem.Application.Game.Queries.GetRules;
using GameSystem.Application.TodoItems.Commands.CreateTodoItem;

namespace GameSystem.Web.Endpoints;

public class Rules : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetRules)
            .MapPost(CreateRules);
    }

    public static async Task<RulesDto?> GetRules(ISender sender, [AsParameters] GetRulesQuery query)
    {
        return await sender.Send(query);
    }
    
    public static async Task<int> CreateRules(ISender sender, CreateRulesCommand command)
    {
        return await sender.Send(command);
    }
}
