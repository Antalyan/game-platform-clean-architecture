using GameSystem.Application.Common.Interfaces;
using GameSystem.Application.TournamentContext.Queries.TournamentNotificationQueries;

namespace GameSystem.Application.TournamentContext.Queries.TournamentQueries;

public class GetTournamentByIdQueryHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<GetTournamentByIdQuery, TournamentDetailedDto?>
{
    private readonly IApplicationDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<TournamentDetailedDto?> Handle(GetTournamentByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Tournaments
            .Where(x => x.Id == request.TournamentId)
            .Include(x => x.GameList)
            .Include(x=> x.PlayerList)
            .Include(x => x.TournamentNotifications)
            .ProjectTo<TournamentDetailedDto>(_mapper.ConfigurationProvider)
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);
    }
}
