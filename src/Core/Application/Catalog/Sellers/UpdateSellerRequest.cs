namespace FSH.WebApi.Application.Catalog.Sellers;

public class UpdateSellerRequest : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string ShopName { get; set; } = default!;
    public string? GstNumber { get; set; }
    public string? Address1 { get; set; }
    public string? Address2 { get; set; }
    public Guid CountryId { get; set; }
    public Guid StateId { get; set; }
    public Guid CityId { get; set; }
    public string? Pin { get; set; }
    public string? Latitude { get; set; }
    public string? Longitude { get; set; }
    public bool IsActive { get; set; }
}

public class UpdateSellerRequestValidator : CustomValidator<UpdateSellerRequest>
{
    public UpdateSellerRequestValidator(IRepository<Seller> repository, IStringLocalizer<UpdateSellerRequestValidator> localizer) =>
        RuleFor(p => p.ShopName)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (seller, name, ct) =>
                    await repository.GetBySpecAsync(new SellerByNameSpec(name), ct)
                        is not Seller existingSeller || existingSeller.Id == seller.Id)
                .WithMessage((_, name) => string.Format(localizer["seller.alreadyexists"], name));
}

public class UpdateSellerRequestHandler : IRequestHandler<UpdateSellerRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Seller> _repository;
    private readonly IStringLocalizer<UpdateSellerRequestHandler> _localizer;

    public UpdateSellerRequestHandler(IRepositoryWithEvents<Seller> repository, IStringLocalizer<UpdateSellerRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Guid> Handle(UpdateSellerRequest request, CancellationToken cancellationToken)
    {
        var seller = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = seller ?? throw new NotFoundException(string.Format(_localizer["seller.notfound"], request.Id));

        seller.Update(request.ShopName, request.GstNumber, request.Address1, request.Address2, request.CountryId, request.StateId, request.CityId, request.Pin, request.Latitude, request.Longitude, request.IsActive);

        await _repository.UpdateAsync(seller, cancellationToken);

        return request.Id;
    }
}