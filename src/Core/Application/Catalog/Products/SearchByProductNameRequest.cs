namespace FSH.WebApi.Application.Catalog.Products;

public class SearchByProductNameRequest : PaginationFilter, IRequest<PaginationResponse<ProductDto>>
{
    public decimal? MinimumRate { get; set; }
    public decimal? MaximumRate { get; set; }
}

public class SearchByProductNameRequestHandler : IRequestHandler<SearchByProductNameRequest, PaginationResponse<ProductDto>>
{
    private readonly IReadRepository<Product> _repository;

    public SearchByProductNameRequestHandler(IReadRepository<Product> repository) => _repository = repository;

    public async Task<PaginationResponse<ProductDto>> Handle(SearchByProductNameRequest request, CancellationToken cancellationToken)
    {
        var spec = new ProductsBySearchRequestWithNameSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken: cancellationToken);
    }
}