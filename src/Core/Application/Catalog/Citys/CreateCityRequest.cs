namespace FSH.WebApi.Application.Catalog.Citys;

public class CreateCityRequest : IRequest<Guid>
{
    public string Name { get; set; } = default!;
    public Guid StateId { get; set; }
    public Guid CountryId { get; set; }
}

public class CreateCityRequestValidator : CustomValidator<CreateCityRequest>
{
    public CreateCityRequestValidator(IReadRepository<City> repository, IStringLocalizer<CreateCityRequestValidator> localizer) =>
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (name, ct) => await repository.GetBySpecAsync(new CityByNameSpec(name), ct) is null)
                .WithMessage((_, name) => string.Format(localizer["city.alreadyexists"], name));
}

public class CreateCityRequestHandler : IRequestHandler<CreateCityRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<City> _repository;

    public CreateCityRequestHandler(IRepositoryWithEvents<City> repository) => _repository = repository;

    public async Task<Guid> Handle(CreateCityRequest request, CancellationToken cancellationToken)
    {
        var city = new City(request.Name, request.StateId, request.CountryId);

        await _repository.AddAsync(city, cancellationToken);

        return city.Id;
    }
}