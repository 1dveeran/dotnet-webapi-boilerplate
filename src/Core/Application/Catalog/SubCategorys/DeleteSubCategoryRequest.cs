using FSH.WebApi.Application.Catalog.SubCategorys;

namespace FSH.WebApi.Application.Catalog.SubCategorys;

public class DeleteSubCategoryRequest : IRequest<Guid>
{
    public Guid Id { get; set; }

    public DeleteSubCategoryRequest(Guid id) => Id = id;
}

public class DeleteSubCategoryRequestHandler : IRequestHandler<DeleteSubCategoryRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<SubCategory> _subCategoryRepo;
    private readonly IStringLocalizer<DeleteSubCategoryRequestHandler> _localizer;

    public DeleteSubCategoryRequestHandler(IRepositoryWithEvents<SubCategory> subCategoryRepo, IStringLocalizer<DeleteSubCategoryRequestHandler> localizer) =>
        (_subCategoryRepo, _localizer) = (subCategoryRepo, localizer);

    public async Task<Guid> Handle(DeleteSubCategoryRequest request, CancellationToken cancellationToken)
    {
        var subCategory = await _subCategoryRepo.GetByIdAsync(request.Id, cancellationToken);

        _ = subCategory ?? throw new NotFoundException(_localizer["subCategory.notfound"]);

        await _subCategoryRepo.DeleteAsync(subCategory, cancellationToken);

        return request.Id;
    }
}