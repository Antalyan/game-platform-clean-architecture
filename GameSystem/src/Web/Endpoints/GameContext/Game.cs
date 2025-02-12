﻿using GameSystem.Application.GameContext.Commands.GameCommands;
using GameSystem.Application.GameContext.Queries.GameQueries;

namespace GameSystem.Web.Endpoints.GameContext;

public class Game: EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapPost(SubmitGame, "submit")
            .MapDelete(DeleteGame, "{id}")
            .MapGet(GetGame, "detail")
            .MapGet(GetGames, "available");
    }
    
    public static async Task<int> SubmitGame(ISender sender, SubmitGameCommand command)
    {
        return await sender.Send(command);
    }
    
    public async Task<IResult> DeleteGame(ISender sender, int id)
    {
        await sender.Send(new DeleteGameCommand(id));
        return Results.NoContent();
    }
    
    public static async Task<GameDetailedDto?> GetGame(ISender sender, [AsParameters] GetGameByIdQuery byIdQuery)
    {
        return await sender.Send(byIdQuery);
    }
    
    public static async Task<IReadOnlyCollection<GameSimpleDto>> GetGames(ISender sender, [AsParameters] GetAvailableGamesQuery byUserAndVisibilityQuery)
    {
        return await sender.Send(byUserAndVisibilityQuery);
    }
}

