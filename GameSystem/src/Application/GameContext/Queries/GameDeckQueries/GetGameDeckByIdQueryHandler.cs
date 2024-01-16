using GameSystem.Application.Common.Interfaces;

namespace GameSystem.Application.GameContext.Queries.GameDeckQueries;

public class GetGameDeckByIdQueryHandler : IRequestHandler<GetGameDeckByIdQuery, GameDeckDto?>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetGameDeckByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GameDeckDto?> Handle(GetGameDeckByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.GameDecks
            .Where(x => x.Id == request.GameDeckId)
            .Include(x => x.CardList)
            .ProjectTo<GameDeckDto>(_mapper.ConfigurationProvider)
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);
    }
}

