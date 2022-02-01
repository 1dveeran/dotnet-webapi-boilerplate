namespace FSH.WebApi.Application.Catalog.ProductImages;

public class GetProductImageRequest : IRequest<ProductImageDto>
{
    public Guid Id { get; set; }

    public GetProductImageRequest(Guid id) => Id = id;
}

public class ProductImageByIdSpec : Specification<ProductImage, ProductImageDto>, ISingleResultSpecification
{
    public ProductImageByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetProductImageRequestHandler : IRequestHandler<GetProductImageRequest, ProductImageDto>
{
    private readonly IRepository<ProductImage> _repository;
    private readonly IStringLocalizer<GetProductImageRequestHandler> _localizer;

    public GetProductImageRequestHandler(IRepository<ProductImage> repository, IStringLocalizer<GetProductImageRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<ProductImageDto> Handle(GetProductImageRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<ProductImage, ProductImageDto>)new ProductImageByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["productImage.notfound"], request.Id));
}