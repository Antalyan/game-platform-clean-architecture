using GameSystem.Application.TournamentContext.Queries.TournamentNotificationQueries;
using GameSystem.Domain.Entities.PlayerContext;

namespace GameSystem.Application.TournamentContext.Queries.PlayerQueries;

public class PlayerDetailedDto
{
    public string? Name { get; init; }
    public string? EmailAddress { get; init; }
    public bool IsOpenToTournament { get; init; } = true;

    public IReadOnlyCollection<TournamentNotificationDto> Notifications { get; set; } =
        new List<TournamentNotificationDto>();

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Player, PlayerDetailedDto>();
        }
    }
}
