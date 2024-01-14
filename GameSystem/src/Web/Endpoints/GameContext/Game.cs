using GameSystem.Application.GameContext.Commands.GameCommands;

namespace GameSystem.Web.Endpoints.GameContext;

public class Game: EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            // .RequireAuthorization()
            .MapPost(SubmitGame, "submit");
    }
    
    public static async Task<int> SubmitGame(ISender sender, SubmitGameCommand command)
    {
        return await sender.Send(command);
    }
}

