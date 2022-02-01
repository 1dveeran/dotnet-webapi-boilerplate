namespace FSH.WebApi.Application.Catalog.ProductSpecifications;

public class SearchProductSpecificationsRequest : PaginationFilter, IRequest<PaginationResponse<ProductSpecificationDto>>
{
}

public class ProductSpecificationsBySearchRequestSpec : EntitiesByPaginationFilterSpec<ProductSpecification, ProductSpecificationDto>
{
    public ProductSpecificationsBySearchRequestSpec(SearchProductSpecificationsRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchProductSpecificationsRequestHandler : IRequestHandler<SearchProductSpecificationsRequest, PaginationResponse<ProductSpecificationDto>>
{
    private readonly IReadRepository<ProductSpecification> _repository;

    public SearchProductSpecificationsRequestHandler(IReadRepository<ProductSpecification> repository) => _repository = repository;

    public async Task<PaginationResponse<ProductSpecificationDto>> Handle(SearchProductSpecificationsRequest request, CancellationToken cancellationToken)
    {
        var spec = new ProductSpecificationsBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<ProductSpecificationDto>(list, count, request.PageNumber, request.PageSize);
    }
}