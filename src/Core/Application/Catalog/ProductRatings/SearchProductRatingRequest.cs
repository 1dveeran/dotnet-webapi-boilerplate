namespace FSH.WebApi.Application.Catalog.ProductRatings;

public class SearchProductRatingsRequest : PaginationFilter, IRequest<PaginationResponse<ProductRatingDto>>
{
}

public class ProductRatingsBySearchRequestSpec : EntitiesByPaginationFilterSpec<ProductRating, ProductRatingDto>
{
    public ProductRatingsBySearchRequestSpec(SearchProductRatingsRequest request)
        : base(request) =>
        Query.OrderBy(c => c.ProductId, !request.HasOrderBy());
}

public class SearchProductRatingsRequestHandler : IRequestHandler<SearchProductRatingsRequest, PaginationResponse<ProductRatingDto>>
{
    private readonly IReadRepository<ProductRating> _repository;

    public SearchProductRatingsRequestHandler(IReadRepository<ProductRating> repository) => _repository = repository;

    public async Task<PaginationResponse<ProductRatingDto>> Handle(SearchProductRatingsRequest request, CancellationToken cancellationToken)
    {
        var spec = new ProductRatingsBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<ProductRatingDto>(list, count, request.PageNumber, request.PageSize);
    }
}