﻿using GameSystem.Application.Common.Interfaces;
using GameSystem.Application.Game.Queries.GetRules;

namespace GameSystem.Application.GameContext.Queries.Rules;

public class GetRulesQueryHandler : IRequestHandler<GetRulesByIdQuery, RulesDto?>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetRulesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<RulesDto?> Handle(GetRulesByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Rules
            .Where(x => x.Id == request.RulesId)
            .ProjectTo<RulesDto>(_mapper.ConfigurationProvider)
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);
    }
}
