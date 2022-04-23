namespace FSH.WebApi.Application.Catalog.ProductImages;

public class GetProductImageByProductIdRequest : IRequest<ProductImageDto>
{
    public Guid Id { get; set; }

    public GetProductImageByProductIdRequest(Guid id) => Id = id;
}

public class ProductImageByProductIdSpec : Specification<ProductImage, ProductImageDto>, ISingleResultSpecification
{
    public ProductImageByProductIdSpec(Guid id) =>
        Query.Where(p => p.ProductId == id);
}

public class GetProductImageByProductIdRequestHandler : IRequestHandler<GetProductImageByProductIdRequest, ProductImageDto>
{
    private readonly IRepository<ProductImage> _repository;
    private readonly IStringLocalizer<GetProductImageByProductIdRequestHandler> _localizer;

    public GetProductImageByProductIdRequestHandler(IRepository<ProductImage> repository, IStringLocalizer<GetProductImageByProductIdRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<ProductImageDto> Handle(GetProductImageByProductIdRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<ProductImage, ProductImageDto>)new ProductImageByProductIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["productImage.notfound"], request.Id));
}