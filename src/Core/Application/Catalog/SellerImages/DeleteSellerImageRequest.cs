using FSH.WebApi.Application.Catalog.SellerImages;

namespace FSH.WebApi.Application.Catalog.SellerImages;

public class DeleteSellerImageRequest : IRequest<Guid>
{
    public Guid Id { get; set; }

    public DeleteSellerImageRequest(Guid id) => Id = id;
}

public class DeleteSellerImageRequestHandler : IRequestHandler<DeleteSellerImageRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<SellerImage> _sellerImageRepo;
    private readonly IStringLocalizer<DeleteSellerImageRequestHandler> _localizer;

    public DeleteSellerImageRequestHandler(IRepositoryWithEvents<SellerImage> sellerImageRepo, IStringLocalizer<DeleteSellerImageRequestHandler> localizer) =>
        (_sellerImageRepo, _localizer) = (sellerImageRepo, localizer);

    public async Task<Guid> Handle(DeleteSellerImageRequest request, CancellationToken cancellationToken)
    {
        var sellerImage = await _sellerImageRepo.GetByIdAsync(request.Id, cancellationToken);

        _ = sellerImage ?? throw new NotFoundException(_localizer["sellerImage.notfound"]);

        await _sellerImageRepo.DeleteAsync(sellerImage, cancellationToken);

        return request.Id;
    }
}