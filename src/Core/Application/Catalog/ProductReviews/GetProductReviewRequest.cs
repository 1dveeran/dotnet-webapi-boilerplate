namespace FSH.WebApi.Application.Catalog.ProductReviews;

public class GetProductReviewRequest : IRequest<ProductReviewDto>
{
    public Guid Id { get; set; }

    public GetProductReviewRequest(Guid id) => Id = id;
}

public class ProductReviewByIdSpec : Specification<ProductReview, ProductReviewDto>, ISingleResultSpecification
{
    public ProductReviewByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetProductReviewRequestHandler : IRequestHandler<GetProductReviewRequest, ProductReviewDto>
{
    private readonly IRepository<ProductReview> _repository;
    private readonly IStringLocalizer<GetProductReviewRequestHandler> _localizer;

    public GetProductReviewRequestHandler(IRepository<ProductReview> repository, IStringLocalizer<GetProductReviewRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<ProductReviewDto> Handle(GetProductReviewRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<ProductReview, ProductReviewDto>)new ProductReviewByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["productReview.notfound"], request.Id));
}