using System.ComponentModel.DataAnnotations;
using GameSystem.Application.GameContext.Queries.GameQueries;
using GameSystem.Application.TournamentContext.Queries.PlayerQueries;
using GameSystem.Application.TournamentContext.Queries.TournamentNotificationQueries;
using GameSystem.Domain.Entities.GameContext;
using GameSystem.Domain.Entities.TournamentContext;
using GameSystem.Domain.Enums;

namespace GameSystem.Application.TournamentContext.Queries.TournamentQueries;

public class TournamentDetailedDto
{
    public string? Name { get; init; }
    public string? Description { get; init; }
    public int? MaximalPlayersCount { get; set; }

    [EnumDataType(typeof(TournamentState))]
    public string? TournamentState { get; init; }
    
    public IReadOnlyCollection<PlayerInTournamentDto> PlayerList { get; set; } = new List<PlayerInTournamentDto>();
    
    public IReadOnlyCollection<GameSimpleDto> GameList { get; set; } = new List<GameSimpleDto>();
    public IReadOnlyCollection<TournamentNotificationDto> TournamentNotifications { get; set; } = new List<TournamentNotificationDto>();

    
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Tournament, TournamentDetailedDto>();
        }
    }
}
