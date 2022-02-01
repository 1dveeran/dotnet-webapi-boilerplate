using FSH.WebApi.Application.Catalog.ProductImages;

namespace FSH.WebApi.Application.Catalog.ProductImages;

public class DeleteProductImageRequest : IRequest<Guid>
{
    public Guid Id { get; set; }

    public DeleteProductImageRequest(Guid id) => Id = id;
}

public class DeleteProductImageRequestHandler : IRequestHandler<DeleteProductImageRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<ProductImage> _productImageRepo;
    private readonly IStringLocalizer<DeleteProductImageRequestHandler> _localizer;

    public DeleteProductImageRequestHandler(IRepositoryWithEvents<ProductImage> productImageRepo, IStringLocalizer<DeleteProductImageRequestHandler> localizer) =>
        (_productImageRepo, _localizer) = (productImageRepo, localizer);

    public async Task<Guid> Handle(DeleteProductImageRequest request, CancellationToken cancellationToken)
    {
        var productImage = await _productImageRepo.GetByIdAsync(request.Id, cancellationToken);

        _ = productImage ?? throw new NotFoundException(_localizer["productImage.notfound"]);

        await _productImageRepo.DeleteAsync(productImage, cancellationToken);

        return request.Id;
    }
}