namespace FSH.WebApi.Application.Catalog.Countrys;

public class SearchCountrysRequest : PaginationFilter, IRequest<PaginationResponse<CountryDto>>
{
}

public class CountrysBySearchRequestSpec : EntitiesByPaginationFilterSpec<Country, CountryDto>
{
    public CountrysBySearchRequestSpec(SearchCountrysRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchCountrysRequestHandler : IRequestHandler<SearchCountrysRequest, PaginationResponse<CountryDto>>
{
    private readonly IReadRepository<Country> _repository;

    public SearchCountrysRequestHandler(IReadRepository<Country> repository) => _repository = repository;

    public async Task<PaginationResponse<CountryDto>> Handle(SearchCountrysRequest request, CancellationToken cancellationToken)
    {
        var spec = new CountrysBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<CountryDto>(list, count, request.PageNumber, request.PageSize);
    }
}