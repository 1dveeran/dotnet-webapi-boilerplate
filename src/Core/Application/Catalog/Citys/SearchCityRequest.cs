namespace FSH.WebApi.Application.Catalog.Citys;

public class SearchCitysRequest : PaginationFilter, IRequest<PaginationResponse<CityDto>>
{
}

public class CitysBySearchRequestSpec : EntitiesByPaginationFilterSpec<City, CityDto>
{
    public CitysBySearchRequestSpec(SearchCitysRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchCitysRequestHandler : IRequestHandler<SearchCitysRequest, PaginationResponse<CityDto>>
{
    private readonly IReadRepository<City> _repository;

    public SearchCitysRequestHandler(IReadRepository<City> repository) => _repository = repository;

    public async Task<PaginationResponse<CityDto>> Handle(SearchCitysRequest request, CancellationToken cancellationToken)
    {
        var spec = new CitysBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<CityDto>(list, count, request.PageNumber, request.PageSize);
    }
}