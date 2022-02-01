namespace FSH.WebApi.Application.Catalog.SubCategorys;

public class GetSubCategoryRequest : IRequest<SubCategoryDto>
{
    public Guid Id { get; set; }

    public GetSubCategoryRequest(Guid id) => Id = id;
}

public class SubCategoryByIdSpec : Specification<SubCategory, SubCategoryDto>, ISingleResultSpecification
{
    public SubCategoryByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetSubCategoryRequestHandler : IRequestHandler<GetSubCategoryRequest, SubCategoryDto>
{
    private readonly IRepository<SubCategory> _repository;
    private readonly IStringLocalizer<GetSubCategoryRequestHandler> _localizer;

    public GetSubCategoryRequestHandler(IRepository<SubCategory> repository, IStringLocalizer<GetSubCategoryRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<SubCategoryDto> Handle(GetSubCategoryRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<SubCategory, SubCategoryDto>)new SubCategoryByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["subCategory.notfound"], request.Id));
}