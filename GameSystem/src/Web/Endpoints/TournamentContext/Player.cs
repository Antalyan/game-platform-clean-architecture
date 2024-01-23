using GameSystem.Application.TournamentContext.Queries.PlayerQueries;

namespace GameSystem.Web.Endpoints.TournamentContext;

public class Player : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetPlayer, "detail");
    }

    public static async Task<PlayerDetailedDto?> GetPlayer(ISender sender, [AsParameters] GetPlayerByIdQuery command)
    {
        return await sender.Send(command);
    }
}
