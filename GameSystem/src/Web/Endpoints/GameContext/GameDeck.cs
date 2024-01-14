using GameSystem.Application.GameContext.Commands.GameDeckCommands;
using GameSystem.Application.GameContext.Queries.GameDeckQueries;

namespace GameSystem.Web.Endpoints.GameContext;

public class GameDeck : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapPost(CreateDeck, "create")
            .MapPost(AddCardToDeck, "addCard")
            .MapGet(GetGameDeck);
    }
    
    public static async Task<int> CreateDeck(ISender sender, CreateDeckCommand command)
    {
        return await sender.Send(command);
    }
    
    public static async Task<IResult> AddCardToDeck(ISender sender, AddCardToDeckCommand command)
    {
        await sender.Send(command);
        return Results.NoContent();
    }
    
    public static async Task<GameDeckDto?> GetGameDeck(ISender sender, [AsParameters] GetGameDeckByIdQuery byIdQuery)
    {
        return await sender.Send(byIdQuery);
    }
}
