namespace FSH.WebApi.Application.Catalog.Categorys;

public class SearchCategorysRequest : PaginationFilter, IRequest<PaginationResponse<CategoryDto>>
{
}

public class CategorysBySearchRequestSpec : EntitiesByPaginationFilterSpec<Category, CategoryDto>
{
    public CategorysBySearchRequestSpec(SearchCategorysRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchCategorysRequestHandler : IRequestHandler<SearchCategorysRequest, PaginationResponse<CategoryDto>>
{
    private readonly IReadRepository<Category> _repository;

    public SearchCategorysRequestHandler(IReadRepository<Category> repository) => _repository = repository;

    public async Task<PaginationResponse<CategoryDto>> Handle(SearchCategorysRequest request, CancellationToken cancellationToken)
    {
        var spec = new CategorysBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<CategoryDto>(list, count, request.PageNumber, request.PageSize);
    }
}