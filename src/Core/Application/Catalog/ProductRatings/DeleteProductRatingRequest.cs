using FSH.WebApi.Application.Catalog.ProductRatings;

namespace FSH.WebApi.Application.Catalog.ProductRatings;

public class DeleteProductRatingRequest : IRequest<Guid>
{
    public Guid Id { get; set; }

    public DeleteProductRatingRequest(Guid id) => Id = id;
}

public class DeleteProductRatingRequestHandler : IRequestHandler<DeleteProductRatingRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<ProductRating> _productRatingRepo;
    private readonly IStringLocalizer<DeleteProductRatingRequestHandler> _localizer;

    public DeleteProductRatingRequestHandler(IRepositoryWithEvents<ProductRating> productRatingRepo, IStringLocalizer<DeleteProductRatingRequestHandler> localizer) =>
        (_productRatingRepo, _localizer) = (productRatingRepo, localizer);

    public async Task<Guid> Handle(DeleteProductRatingRequest request, CancellationToken cancellationToken)
    {
        var productRating = await _productRatingRepo.GetByIdAsync(request.Id, cancellationToken);

        _ = productRating ?? throw new NotFoundException(_localizer["productRating.notfound"]);

        await _productRatingRepo.DeleteAsync(productRating, cancellationToken);

        return request.Id;
    }
}