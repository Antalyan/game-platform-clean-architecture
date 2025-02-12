﻿using GameSystem.Application.GameContext.Commands.RulesCommands;
using GameSystem.Application.GameContext.Queries.RulesQueries;

namespace GameSystem.Web.Endpoints.GameContext;

public class Rules : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
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
