using GameSystem.Application.TournamentContext.Commands.TournamentCommands;
using GameSystem.Application.TournamentContext.Commands.TournamentNotificationCommands;
using GameSystem.Application.TournamentContext.Queries.TournamentNotificationQueries;
using GameSystem.Application.TournamentContext.Queries.TournamentQueries;

namespace GameSystem.Web.Endpoints.TournamentContext;

public class Tournament: EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapPost(CreateTournament, "submit")
            .MapGet(GetTournament, "detail")
            .MapPut(InvitePlayersToTournament, "invite");
    }
    public static async Task<int> CreateTournament(ISender sender, CreateTournamentCommand command)
    {
        return await sender.Send(command);
    }

    public static async Task<TournamentDetailedDto?> GetTournament(ISender sender,
        [AsParameters] GetTournamentByIdQuery byIdQuery)
    {
        return await sender.Send(byIdQuery);
    }

    public static async Task<int> InvitePlayersToTournament(ISender sender, InvitePlayersToTournamentCommand command)
    {
        return await sender.Send(command);
    }
    
}
