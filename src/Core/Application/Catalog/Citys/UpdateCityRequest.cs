namespace FSH.WebApi.Application.Catalog.Citys;

public class UpdateCityRequest : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public Guid StateId { get; set; }
    public Guid CountryId { get; set; }
}

public class UpdateCityRequestValidator : CustomValidator<UpdateCityRequest>
{
    public UpdateCityRequestValidator(IRepository<City> repository, IStringLocalizer<UpdateCityRequestValidator> localizer) =>
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (city, name, ct) =>
                    await repository.GetBySpecAsync(new CityByNameSpec(name), ct)
                        is not City existingCity || existingCity.Id == city.Id)
                .WithMessage((_, name) => string.Format(localizer["city.alreadyexists"], name));
}

public class UpdateCityRequestHandler : IRequestHandler<UpdateCityRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<City> _repository;
    private readonly IStringLocalizer<UpdateCityRequestHandler> _localizer;

    public UpdateCityRequestHandler(IRepositoryWithEvents<City> repository, IStringLocalizer<UpdateCityRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Guid> Handle(UpdateCityRequest request, CancellationToken cancellationToken)
    {
        var city = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = city ?? throw new NotFoundException(string.Format(_localizer["city.notfound"], request.Id));

        city.Update(request.Name, request.StateId, request.CountryId);

        await _repository.UpdateAsync(city, cancellationToken);

        return request.Id;
    }
}