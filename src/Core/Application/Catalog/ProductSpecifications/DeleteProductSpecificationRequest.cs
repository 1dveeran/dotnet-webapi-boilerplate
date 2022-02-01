using FSH.WebApi.Application.Catalog.ProductSpecifications;

namespace FSH.WebApi.Application.Catalog.ProductSpecifications;

public class DeleteProductSpecificationRequest : IRequest<Guid>
{
    public Guid Id { get; set; }

    public DeleteProductSpecificationRequest(Guid id) => Id = id;
}

public class DeleteProductSpecificationRequestHandler : IRequestHandler<DeleteProductSpecificationRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<ProductSpecification> _productSpecificationRepo;
    private readonly IStringLocalizer<DeleteProductSpecificationRequestHandler> _localizer;

    public DeleteProductSpecificationRequestHandler(IRepositoryWithEvents<ProductSpecification> productSpecificationRepo, IStringLocalizer<DeleteProductSpecificationRequestHandler> localizer) =>
        (_productSpecificationRepo, _localizer) = (productSpecificationRepo, localizer);

    public async Task<Guid> Handle(DeleteProductSpecificationRequest request, CancellationToken cancellationToken)
    {
        var productSpecification = await _productSpecificationRepo.GetByIdAsync(request.Id, cancellationToken);

        _ = productSpecification ?? throw new NotFoundException(_localizer["productSpecification.notfound"]);

        await _productSpecificationRepo.DeleteAsync(productSpecification, cancellationToken);

        return request.Id;
    }
}