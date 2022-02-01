using FSH.WebApi.Application.Catalog.ProductReviews;

namespace FSH.WebApi.Application.Catalog.ProductReviews;

public class DeleteProductReviewRequest : IRequest<Guid>
{
    public Guid Id { get; set; }

    public DeleteProductReviewRequest(Guid id) => Id = id;
}

public class DeleteProductReviewRequestHandler : IRequestHandler<DeleteProductReviewRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<ProductReview> _productReviewRepo;
    private readonly IStringLocalizer<DeleteProductReviewRequestHandler> _localizer;

    public DeleteProductReviewRequestHandler(IRepositoryWithEvents<ProductReview> productReviewRepo, IStringLocalizer<DeleteProductReviewRequestHandler> localizer) =>
        (_productReviewRepo, _localizer) = (productReviewRepo, localizer);

    public async Task<Guid> Handle(DeleteProductReviewRequest request, CancellationToken cancellationToken)
    {
        var productReview = await _productReviewRepo.GetByIdAsync(request.Id, cancellationToken);

        _ = productReview ?? throw new NotFoundException(_localizer["productReview.notfound"]);

        await _productReviewRepo.DeleteAsync(productReview, cancellationToken);

        return request.Id;
    }
}