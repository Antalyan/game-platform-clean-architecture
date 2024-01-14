using GameSystem.Application.GameContext.Commands.GameDeckCommands;

namespace GameSystem.Web.Endpoints.GameContext;

public class GameDeck : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapPost(CreateDeck, "create")
            .MapPost(AddCardToDeck, "addCard/{id}");
    }
    
    public static async Task<int> CreateDeck(ISender sender, CreateDeckCommand command)
    {
        return await sender.Send(command);
    }
    
    public static async Task<IResult> AddCardToDeck(ISender sender, int id, AddCardToDeckCommand command)
    {
        if (id != command.DeckId) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }
}
