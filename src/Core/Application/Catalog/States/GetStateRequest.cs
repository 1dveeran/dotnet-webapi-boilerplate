namespace FSH.WebApi.Application.Catalog.States;

public class GetStateRequest : IRequest<StateDto>
{
    public Guid Id { get; set; }

    public GetStateRequest(Guid id) => Id = id;
}

public class StateByIdSpec : Specification<State, StateDto>, ISingleResultSpecification
{
    public StateByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetStateRequestHandler : IRequestHandler<GetStateRequest, StateDto>
{
    private readonly IRepository<State> _repository;
    private readonly IStringLocalizer<GetStateRequestHandler> _localizer;

    public GetStateRequestHandler(IRepository<State> repository, IStringLocalizer<GetStateRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<StateDto> Handle(GetStateRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<State, StateDto>)new StateByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["state.notfound"], request.Id));
}