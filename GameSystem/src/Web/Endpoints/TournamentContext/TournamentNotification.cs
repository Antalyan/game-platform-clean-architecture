using GameSystem.Application.TournamentContext.Commands.TournamentCommands;
using GameSystem.Application.TournamentContext.Queries.TournamentNotificationQueries;

namespace GameSystem.Web.Endpoints.TournamentContext;

public class TournamentNotification : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetNotification, "detail")
            .MapPut(AcceptNotification, "invite");
    }

    public static async Task<TournamentNotificationDto?> GetNotification(ISender sender, [AsParameters] GetNotificationByIdQuery getNotificationById)
    {
        return await sender.Send(getNotificationById);
    }

    public static async Task<IResult> AcceptNotification(ISender sender, AcceptTournamentOfferCommand command)
    {
        await sender.Send(command);
        return Results.NoContent();
    }
}
