using GameSystem.Application.Common.Interfaces;
using GameSystem.Domain.Entities.PlayerContext;

namespace GameSystem.Application.TournamentContext.Queries.PlayerQueries;

public class GetPlayerByIdQueryHandler : IRequestHandler<GetPlayerByIdQuery, PlayerDetailedDto?>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPlayerByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PlayerDetailedDto?> Handle(GetPlayerByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Players
            .Where(x => x.Id == request.PlayerId)
            .Include(x => x.Notifications)
            .ProjectTo<PlayerDetailedDto>(_mapper.ConfigurationProvider)
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);
    }
}
