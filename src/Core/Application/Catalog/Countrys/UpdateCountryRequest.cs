namespace FSH.WebApi.Application.Catalog.Countrys;

public class UpdateCountryRequest : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public bool IsActive { get; set; }
}

public class UpdateCountryRequestValidator : CustomValidator<UpdateCountryRequest>
{
    public UpdateCountryRequestValidator(IRepository<Country> repository, IStringLocalizer<UpdateCountryRequestValidator> localizer) =>
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (country, name, ct) =>
                    await repository.GetBySpecAsync(new CountryByNameSpec(name), ct)
                        is not Country existingCountry || existingCountry.Id == country.Id)
                .WithMessage((_, name) => string.Format(localizer["country.alreadyexists"], name));
}

public class UpdateCountryRequestHandler : IRequestHandler<UpdateCountryRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Country> _repository;
    private readonly IStringLocalizer<UpdateCountryRequestHandler> _localizer;

    public UpdateCountryRequestHandler(IRepositoryWithEvents<Country> repository, IStringLocalizer<UpdateCountryRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Guid> Handle(UpdateCountryRequest request, CancellationToken cancellationToken)
    {
        var country = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = country ?? throw new NotFoundException(string.Format(_localizer["country.notfound"], request.Id));

        country.Update(request.Name, request.IsActive);

        await _repository.UpdateAsync(country, cancellationToken);

        return request.Id;
    }
}