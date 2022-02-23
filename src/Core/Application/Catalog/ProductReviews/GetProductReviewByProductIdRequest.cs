namespace FSH.WebApi.Application.Catalog.ProductReviews;

public class GetProductReviewByProductIdRequest : IRequest<List<ProductReviewDto>>
{
    public Guid? ProductId { get; set; }
    public GetProductReviewByProductIdRequest(Guid productId) => ProductId = productId;
}

public class GetProductReviewByProductIdRequestHandler : IRequestHandler<GetProductReviewByProductIdRequest, List<ProductReviewDto>>
{
    private readonly IProductReviewService _productReviewService;

    public GetProductReviewByProductIdRequestHandler(IProductReviewService productReviewService) =>
        _productReviewService = productReviewService;

    public Task<List<ProductReviewDto>> Handle(GetProductReviewByProductIdRequest request, CancellationToken cancellationToken) =>
        _productReviewService.GetProductReviewByProductIdAsync(request.ProductId);
}