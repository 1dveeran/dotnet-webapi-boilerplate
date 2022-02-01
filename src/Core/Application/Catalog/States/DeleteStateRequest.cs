using FSH.WebApi.Application.Catalog.States;

namespace FSH.WebApi.Application.Catalog.States;

public class DeleteStateRequest : IRequest<Guid>
{
    public Guid Id { get; set; }

    public DeleteStateRequest(Guid id) => Id = id;
}

public class DeleteStateRequestHandler : IRequestHandler<DeleteStateRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<State> _stateRepo;
    private readonly IStringLocalizer<DeleteStateRequestHandler> _localizer;

    public DeleteStateRequestHandler(IRepositoryWithEvents<State> stateRepo, IStringLocalizer<DeleteStateRequestHandler> localizer) =>
        (_stateRepo, _localizer) = (stateRepo, localizer);

    public async Task<Guid> Handle(DeleteStateRequest request, CancellationToken cancellationToken)
    {
        var state = await _stateRepo.GetByIdAsync(request.Id, cancellationToken);

        _ = state ?? throw new NotFoundException(_localizer["state.notfound"]);

        await _stateRepo.DeleteAsync(state, cancellationToken);

        return request.Id;
    }
}