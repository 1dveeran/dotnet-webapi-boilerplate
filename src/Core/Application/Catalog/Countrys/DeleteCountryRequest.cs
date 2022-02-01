using FSH.WebApi.Application.Catalog.Countrys;

namespace FSH.WebApi.Application.Catalog.Countrys;

public class DeleteCountryRequest : IRequest<Guid>
{
    public Guid Id { get; set; }

    public DeleteCountryRequest(Guid id) => Id = id;
}

public class DeleteCountryRequestHandler : IRequestHandler<DeleteCountryRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Country> _countryRepo;
    private readonly IStringLocalizer<DeleteCountryRequestHandler> _localizer;

    public DeleteCountryRequestHandler(IRepositoryWithEvents<Country> countryRepo, IStringLocalizer<DeleteCountryRequestHandler> localizer) =>
        (_countryRepo, _localizer) = (countryRepo, localizer);

    public async Task<Guid> Handle(DeleteCountryRequest request, CancellationToken cancellationToken)
    {
        var country = await _countryRepo.GetByIdAsync(request.Id, cancellationToken);

        _ = country ?? throw new NotFoundException(_localizer["country.notfound"]);

        await _countryRepo.DeleteAsync(country, cancellationToken);

        return request.Id;
    }
}