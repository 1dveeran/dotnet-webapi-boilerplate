namespace FSH.WebApi.Application.Catalog.ProductReviews;

public class GetProductReviewByProductIdRequest : IRequest<ProductReviewDto>
{
    public Guid Id { get; set; }

    public GetProductReviewByProductIdRequest(Guid id) => Id = id;
}

public class ProductReviewByProductIdSpec : Specification<ProductReview, ProductReviewDto>, ISingleResultSpecification
{
    public ProductReviewByProductIdSpec(Guid id) =>
        Query.Where(p => p.ProductId == id);
}

public class GetProductReviewByProductIdRequestHandler : IRequestHandler<GetProductReviewByProductIdRequest, ProductReviewDto>
{
    private readonly IRepository<ProductReview> _repository;
    private readonly IStringLocalizer<GetProductReviewByProductIdRequestHandler> _localizer;

    public GetProductReviewByProductIdRequestHandler(IRepository<ProductReview> repository, IStringLocalizer<GetProductReviewByProductIdRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<ProductReviewDto> Handle(GetProductReviewByProductIdRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<ProductReview, ProductReviewDto>)new ProductReviewByProductIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["productReview.notfound"], request.Id));
}