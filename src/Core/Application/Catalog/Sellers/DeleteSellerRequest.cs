using FSH.WebApi.Application.Catalog.Sellers;

namespace FSH.WebApi.Application.Catalog.Sellers;

public class DeleteSellerRequest : IRequest<Guid>
{
    public Guid Id { get; set; }

    public DeleteSellerRequest(Guid id) => Id = id;
}

public class DeleteSellerRequestHandler : IRequestHandler<DeleteSellerRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Seller> _sellerRepo;
    private readonly IStringLocalizer<DeleteSellerRequestHandler> _localizer;

    public DeleteSellerRequestHandler(IRepositoryWithEvents<Seller> sellerRepo, IStringLocalizer<DeleteSellerRequestHandler> localizer) =>
        (_sellerRepo, _localizer) = (sellerRepo, localizer);

    public async Task<Guid> Handle(DeleteSellerRequest request, CancellationToken cancellationToken)
    {
        var seller = await _sellerRepo.GetByIdAsync(request.Id, cancellationToken);

        _ = seller ?? throw new NotFoundException(_localizer["seller.notfound"]);

        await _sellerRepo.DeleteAsync(seller, cancellationToken);

        return request.Id;
    }
}