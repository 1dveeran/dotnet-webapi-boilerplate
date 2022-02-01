namespace FSH.WebApi.Application.Catalog.Citys;

public class GetCityRequest : IRequest<CityDto>
{
    public Guid Id { get; set; }

    public GetCityRequest(Guid id) => Id = id;
}

public class CityByIdSpec : Specification<City, CityDto>, ISingleResultSpecification
{
    public CityByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetCityRequestHandler : IRequestHandler<GetCityRequest, CityDto>
{
    private readonly IRepository<City> _repository;
    private readonly IStringLocalizer<GetCityRequestHandler> _localizer;

    public GetCityRequestHandler(IRepository<City> repository, IStringLocalizer<GetCityRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<CityDto> Handle(GetCityRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<City, CityDto>)new CityByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["city.notfound"], request.Id));
}