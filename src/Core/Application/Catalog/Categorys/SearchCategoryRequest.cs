namespace FSH.WebApi.Application.Catalog.Categorys;

public class SearchCategoryRequest : PaginationFilter, IRequest<PaginationResponse<CategoryDto>>
{
}

public class CategorysBySearchRequestSpec : EntitiesByPaginationFilterSpec<Category, CategoryDto>
{
    public CategorysBySearchRequestSpec(SearchCategoryRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchCategoryRequestHandler : IRequestHandler<SearchCategoryRequest, PaginationResponse<CategoryDto>>
{
    private readonly IReadRepository<Category> _repository;

    public SearchCategoryRequestHandler(IReadRepository<Category> repository) => _repository = repository;

    public async Task<PaginationResponse<CategoryDto>> Handle(SearchCategoryRequest request, CancellationToken cancellationToken)
    {
        var spec = new CategorysBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<CategoryDto>(list, count, request.PageNumber, request.PageSize);
    }
}