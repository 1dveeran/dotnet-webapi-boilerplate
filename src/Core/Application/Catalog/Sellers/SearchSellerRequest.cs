namespace FSH.WebApi.Application.Catalog.Sellers;

public class SearchSellersRequest : PaginationFilter, IRequest<PaginationResponse<SellerDto>>
{
}

public class SellersBySearchRequestSpec : EntitiesByPaginationFilterSpec<Seller, SellerDto>
{
    public SellersBySearchRequestSpec(SearchSellersRequest request)
        : base(request) =>
        Query.OrderBy(c => c.ShopName, !request.HasOrderBy());
}

public class SearchSellersRequestHandler : IRequestHandler<SearchSellersRequest, PaginationResponse<SellerDto>>
{
    private readonly IReadRepository<Seller> _repository;

    public SearchSellersRequestHandler(IReadRepository<Seller> repository) => _repository = repository;

    public async Task<PaginationResponse<SellerDto>> Handle(SearchSellersRequest request, CancellationToken cancellationToken)
    {
        var spec = new SellersBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<SellerDto>(list, count, request.PageNumber, request.PageSize);
    }
}