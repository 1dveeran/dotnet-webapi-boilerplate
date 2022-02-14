namespace FSH.WebApi.Application.Catalog.ProductSpecifications;

public class GetProductSpecificationByProductIdRequest : IRequest<List<ProductSpecificationDto>>
{
    public Guid? ProductId { get; set; }
    public GetProductSpecificationByProductIdRequest(Guid productId) => ProductId = productId;
}

public class GetProductSpecificationByProductIdRequestHandler : IRequestHandler<GetProductSpecificationByProductIdRequest, List<ProductSpecificationDto>>
{
    private readonly IProductSpecificationService _productSpecificationService;

    public GetProductSpecificationByProductIdRequestHandler(IProductSpecificationService productSpecificationService) =>
        _productSpecificationService = productSpecificationService;

    public Task<List<ProductSpecificationDto>> Handle(GetProductSpecificationByProductIdRequest request, CancellationToken cancellationToken) =>
        _productSpecificationService.GetProductSpecificationByProductIdAsync(request.ProductId);
}