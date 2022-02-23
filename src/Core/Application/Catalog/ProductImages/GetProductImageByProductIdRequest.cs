namespace FSH.WebApi.Application.Catalog.ProductImages;

public class GetProductImageByProductIdRequest : IRequest<List<ProductImageDto>>
{
    public Guid? ProductId { get; set; }
    public GetProductImageByProductIdRequest(Guid productId) => ProductId = productId;
}

public class GetProductImageByProductIdRequestHandler : IRequestHandler<GetProductImageByProductIdRequest, List<ProductImageDto>>
{
    private readonly IProductImageService _productImageService;

    public GetProductImageByProductIdRequestHandler(IProductImageService productImageService) =>
        _productImageService = productImageService;

    public Task<List<ProductImageDto>> Handle(GetProductImageByProductIdRequest request, CancellationToken cancellationToken) =>
        _productImageService.GetProductImageByProductIdAsync(request.ProductId);
}