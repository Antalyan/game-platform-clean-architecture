using GameSystem.Application.Common.Interfaces;

namespace GameSystem.Application.Game.Queries.GetRules;

public class GetRulesQuery : IRequest<RulesDto?>
{
    public int RulesId { get; init; }
}

public class GetRulesQueryHandler : IRequestHandler<GetRulesQuery, RulesDto?>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetRulesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<RulesDto?> Handle(GetRulesQuery request, CancellationToken cancellationToken)
    {
        return await _context.Rules
            .Where(x => x.Id == request.RulesId)
            .ProjectTo<RulesDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
