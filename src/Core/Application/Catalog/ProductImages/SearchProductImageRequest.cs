namespace FSH.WebApi.Application.Catalog.ProductImages;

public class SearchProductImagesRequest : PaginationFilter, IRequest<PaginationResponse<ProductImageDto>>
{
}

public class ProductImagesBySearchRequestSpec : EntitiesByPaginationFilterSpec<ProductImage, ProductImageDto>
{
    public ProductImagesBySearchRequestSpec(SearchProductImagesRequest request)
        : base(request) =>
        Query.OrderBy(c => c.ImagePath, !request.HasOrderBy());
}

public class SearchProductImagesRequestHandler : IRequestHandler<SearchProductImagesRequest, PaginationResponse<ProductImageDto>>
{
    private readonly IReadRepository<ProductImage> _repository;

    public SearchProductImagesRequestHandler(IReadRepository<ProductImage> repository) => _repository = repository;

    public async Task<PaginationResponse<ProductImageDto>> Handle(SearchProductImagesRequest request, CancellationToken cancellationToken)
    {
        var spec = new ProductImagesBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<ProductImageDto>(list, count, request.PageNumber, request.PageSize);
    }
}