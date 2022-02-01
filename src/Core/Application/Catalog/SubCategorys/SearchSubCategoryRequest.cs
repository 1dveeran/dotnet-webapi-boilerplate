namespace FSH.WebApi.Application.Catalog.SubCategorys;

public class SearchSubCategorysRequest : PaginationFilter, IRequest<PaginationResponse<SubCategoryDto>>
{
}

public class SubCategorysBySearchRequestSpec : EntitiesByPaginationFilterSpec<SubCategory, SubCategoryDto>
{
    public SubCategorysBySearchRequestSpec(SearchSubCategorysRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchSubCategorysRequestHandler : IRequestHandler<SearchSubCategorysRequest, PaginationResponse<SubCategoryDto>>
{
    private readonly IReadRepository<SubCategory> _repository;

    public SearchSubCategorysRequestHandler(IReadRepository<SubCategory> repository) => _repository = repository;

    public async Task<PaginationResponse<SubCategoryDto>> Handle(SearchSubCategorysRequest request, CancellationToken cancellationToken)
    {
        var spec = new SubCategorysBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<SubCategoryDto>(list, count, request.PageNumber, request.PageSize);
    }
}