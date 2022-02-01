namespace FSH.WebApi.Application.Catalog.Sellers;

public class GetSellerRequest : IRequest<SellerDto>
{
    public Guid Id { get; set; }

    public GetSellerRequest(Guid id) => Id = id;
}

public class SellerByIdSpec : Specification<Seller, SellerDto>, ISingleResultSpecification
{
    public SellerByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetSellerRequestHandler : IRequestHandler<GetSellerRequest, SellerDto>
{
    private readonly IRepository<Seller> _repository;
    private readonly IStringLocalizer<GetSellerRequestHandler> _localizer;

    public GetSellerRequestHandler(IRepository<Seller> repository, IStringLocalizer<GetSellerRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<SellerDto> Handle(GetSellerRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<Seller, SellerDto>)new SellerByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["seller.notfound"], request.Id));
}