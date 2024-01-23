using GameSystem.Application.Common.Interfaces;

namespace GameSystem.Application.TournamentContext.Queries.TournamentNotificationQueries;

public class GetNotificationByIdQueryHandler : IRequestHandler<GetNotificationByIdQuery, TournamentNotificationDto?>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetNotificationByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public async Task<TournamentNotificationDto?> Handle(GetNotificationByIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _context.Notifications
            .Where(x => x.Id == request.NotificationId)
            .ProjectTo<TournamentNotificationDto>(_mapper.ConfigurationProvider)
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);
    }
}
