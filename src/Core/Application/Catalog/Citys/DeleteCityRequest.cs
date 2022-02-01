using FSH.WebApi.Application.Catalog.Citys;

namespace FSH.WebApi.Application.Catalog.Citys;

public class DeleteCityRequest : IRequest<Guid>
{
    public Guid Id { get; set; }

    public DeleteCityRequest(Guid id) => Id = id;
}

public class DeleteCityRequestHandler : IRequestHandler<DeleteCityRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<City> _cityRepo;
    private readonly IStringLocalizer<DeleteCityRequestHandler> _localizer;

    public DeleteCityRequestHandler(IRepositoryWithEvents<City> cityRepo, IStringLocalizer<DeleteCityRequestHandler> localizer) =>
        (_cityRepo, _localizer) = (cityRepo, localizer);

    public async Task<Guid> Handle(DeleteCityRequest request, CancellationToken cancellationToken)
    {
        var city = await _cityRepo.GetByIdAsync(request.Id, cancellationToken);

        _ = city ?? throw new NotFoundException(_localizer["city.notfound"]);

        await _cityRepo.DeleteAsync(city, cancellationToken);

        return request.Id;
    }
}