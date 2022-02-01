namespace FSH.WebApi.Application.Catalog.ProductReviews;

public class SearchProductReviewsRequest : PaginationFilter, IRequest<PaginationResponse<ProductReviewDto>>
{
}

public class ProductReviewsBySearchRequestSpec : EntitiesByPaginationFilterSpec<ProductReview, ProductReviewDto>
{
    public ProductReviewsBySearchRequestSpec(SearchProductReviewsRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Username, !request.HasOrderBy());
}

public class SearchProductReviewsRequestHandler : IRequestHandler<SearchProductReviewsRequest, PaginationResponse<ProductReviewDto>>
{
    private readonly IReadRepository<ProductReview> _repository;

    public SearchProductReviewsRequestHandler(IReadRepository<ProductReview> repository) => _repository = repository;

    public async Task<PaginationResponse<ProductReviewDto>> Handle(SearchProductReviewsRequest request, CancellationToken cancellationToken)
    {
        var spec = new ProductReviewsBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<ProductReviewDto>(list, count, request.PageNumber, request.PageSize);
    }
}