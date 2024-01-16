using GameSystem.Application.Common.Interfaces;

namespace GameSystem.Application.GameContext.Queries.GameQueries;

public class GetGameByIdQueryHandler : IRequestHandler<GetGameByIdQuery, GameDetailedDto?>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetGameByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GameDetailedDto?> Handle(GetGameByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Games
            .Where(x => x.Id == request.GameId)
            .Include(x => x.Rules)
            .Include(x => x.Deck.CardList)
            .ProjectTo<GameDetailedDto>(_mapper.ConfigurationProvider)
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);
    }
}

