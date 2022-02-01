namespace FSH.WebApi.Application.Catalog.Sellers;

public class CreateSellerRequest : IRequest<Guid>
{
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

public class CreateSellerRequestValidator : CustomValidator<CreateSellerRequest>
{
    public CreateSellerRequestValidator(IReadRepository<Seller> repository, IStringLocalizer<CreateSellerRequestValidator> localizer) =>
        RuleFor(p => p.ShopName)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (name, ct) => await repository.GetBySpecAsync(new SellerByNameSpec(name), ct) is null)
                .WithMessage((_, name) => string.Format(localizer["seller.alreadyexists"], name));
}

public class CreateSellerRequestHandler : IRequestHandler<CreateSellerRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Seller> _repository;

    public CreateSellerRequestHandler(IRepositoryWithEvents<Seller> repository) => _repository = repository;

    public async Task<Guid> Handle(CreateSellerRequest request, CancellationToken cancellationToken)
    {
        var seller = new Seller(request.ShopName, request.GstNumber, request.Address1, request.Address2, request.CountryId, request.StateId, request.CityId, request.Pin, request.Latitude, request.Longitude, request.IsActive);

        await _repository.AddAsync(seller, cancellationToken);

        return seller.Id;
    }
}