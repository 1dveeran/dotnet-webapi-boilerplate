namespace FSH.WebApi.Application.Catalog.Countrys;

public class GetCountryRequest : IRequest<CountryDto>
{
    public Guid Id { get; set; }

    public GetCountryRequest(Guid id) => Id = id;
}

public class CountryByIdSpec : Specification<Country, CountryDto>, ISingleResultSpecification
{
    public CountryByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetCountryRequestHandler : IRequestHandler<GetCountryRequest, CountryDto>
{
    private readonly IRepository<Country> _repository;
    private readonly IStringLocalizer<GetCountryRequestHandler> _localizer;

    public GetCountryRequestHandler(IRepository<Country> repository, IStringLocalizer<GetCountryRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<CountryDto> Handle(GetCountryRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<Country, CountryDto>)new CountryByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["country.notfound"], request.Id));
}