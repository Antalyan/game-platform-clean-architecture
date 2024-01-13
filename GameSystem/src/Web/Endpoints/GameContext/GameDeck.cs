using GameSystem.Application.GameContext.Commands.GameDeckCommands;

namespace GameSystem.Web.Endpoints.GameContext;

public class GameDeck : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapPost(CreateDeck);
    }
    
    public static async Task<int> CreateDeck(ISender sender, CreateDeckCommand command)
    {
        return await sender.Send(command);
    }
}
