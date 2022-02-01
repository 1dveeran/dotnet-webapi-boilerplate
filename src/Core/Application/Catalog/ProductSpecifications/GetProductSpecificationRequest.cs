namespace FSH.WebApi.Application.Catalog.ProductSpecifications;

public class GetProductSpecificationRequest : IRequest<ProductSpecificationDto>
{
    public Guid Id { get; set; }

    public GetProductSpecificationRequest(Guid id) => Id = id;
}

public class ProductSpecificationByIdSpec : Specification<ProductSpecification, ProductSpecificationDto>, ISingleResultSpecification
{
    public ProductSpecificationByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetProductSpecificationRequestHandler : IRequestHandler<GetProductSpecificationRequest, ProductSpecificationDto>
{
    private readonly IRepository<ProductSpecification> _repository;
    private readonly IStringLocalizer<GetProductSpecificationRequestHandler> _localizer;

    public GetProductSpecificationRequestHandler(IRepository<ProductSpecification> repository, IStringLocalizer<GetProductSpecificationRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<ProductSpecificationDto> Handle(GetProductSpecificationRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<ProductSpecification, ProductSpecificationDto>)new ProductSpecificationByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["productSpecification.notfound"], request.Id));
}