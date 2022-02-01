namespace FSH.WebApi.Application.Catalog.Countrys;

public class CreateCountryRequest : IRequest<Guid>
{
    public string Name { get; set; } = default!;
    public bool IsActive { get; set; }
}

public class CreateCountryRequestValidator : CustomValidator<CreateCountryRequest>
{
    public CreateCountryRequestValidator(IReadRepository<Country> repository, IStringLocalizer<CreateCountryRequestValidator> localizer) =>
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (name, ct) => await repository.GetBySpecAsync(new CountryByNameSpec(name), ct) is null)
                .WithMessage((_, name) => string.Format(localizer["country.alreadyexists"], name));
}

public class CreateCountryRequestHandler : IRequestHandler<CreateCountryRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Country> _repository;

    public CreateCountryRequestHandler(IRepositoryWithEvents<Country> repository) => _repository = repository;

    public async Task<Guid> Handle(CreateCountryRequest request, CancellationToken cancellationToken)
    {
        var country = new Country(request.Name, request.IsActive);

        await _repository.AddAsync(country, cancellationToken);

        return country.Id;
    }
}