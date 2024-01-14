using GameSystem.Application.Common.Interfaces;
using GameSystem.Application.Common.Mappings;
using GameSystem.Domain.Enums;

namespace GameSystem.Application.GameContext.Queries.GameQueries;

public class
    GetAvailableGamesQueryHandler : IRequestHandler<GetAvailableGamesQuery,
    IReadOnlyCollection<GameSimpleDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IUser _user;

    public GetAvailableGamesQueryHandler(IApplicationDbContext context, IMapper mapper, IUser user)
    {
        _context = context;
        _mapper = mapper;
        _user = user;
    }

    public async Task<IReadOnlyCollection<GameSimpleDto>> Handle(GetAvailableGamesQuery request,
        CancellationToken cancellationToken)
    {
        Guard.Against.Null(_user.Id);

        List<GameSimpleDto> availableGames = [];

        if (request.Visibility is null or Visibility.Public)
        {
            availableGames.AddRange(await _context.Games.Where(g => g.Visibility == Visibility.Public)
                .ProjectToListAsync<GameSimpleDto>(_mapper.ConfigurationProvider));
        }

        if (request.Visibility is null or Visibility.Shared)
        {
            availableGames.AddRange(await _context.GamePolls
                .Where(poll => poll.CreatedBy == _user.Id)
                .Select(poll => poll.SharedGames.Where(g => g.Visibility == Visibility.Shared))
                .ProjectToListAsync<GameSimpleDto>(_mapper.ConfigurationProvider));
        }

        if (request.Visibility is null or Visibility.Private)
        {
            availableGames.AddRange(await _context.Games.Where(g => g.CreatedBy == _user.Id && g.Visibility == Visibility.Private)
                .ProjectToListAsync<GameSimpleDto>(_mapper.ConfigurationProvider));
        }

        return availableGames;
    }
}
