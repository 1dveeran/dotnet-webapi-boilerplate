namespace FSH.WebApi.Application.Catalog.States;

public class SearchStatesRequest : PaginationFilter, IRequest<PaginationResponse<StateDto>>
{
}

public class StatesBySearchRequestSpec : EntitiesByPaginationFilterSpec<State, StateDto>
{
    public StatesBySearchRequestSpec(SearchStatesRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchStatesRequestHandler : IRequestHandler<SearchStatesRequest, PaginationResponse<StateDto>>
{
    private readonly IReadRepository<State> _repository;

    public SearchStatesRequestHandler(IReadRepository<State> repository) => _repository = repository;

    public async Task<PaginationResponse<StateDto>> Handle(SearchStatesRequest request, CancellationToken cancellationToken)
    {
        var spec = new StatesBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<StateDto>(list, count, request.PageNumber, request.PageSize);
    }
}