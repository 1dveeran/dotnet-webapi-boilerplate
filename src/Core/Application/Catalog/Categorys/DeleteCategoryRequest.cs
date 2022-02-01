using FSH.WebApi.Application.Catalog.Categorys;

namespace FSH.WebApi.Application.Catalog.Categorys;

public class DeleteCategoryRequest : IRequest<Guid>
{
    public Guid Id { get; set; }

    public DeleteCategoryRequest(Guid id) => Id = id;
}

public class DeleteCategoryRequestHandler : IRequestHandler<DeleteCategoryRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Category> _categoryRepo;
    private readonly IStringLocalizer<DeleteCategoryRequestHandler> _localizer;

    public DeleteCategoryRequestHandler(IRepositoryWithEvents<Category> categoryRepo, IStringLocalizer<DeleteCategoryRequestHandler> localizer) =>
        (_categoryRepo, _localizer) = (categoryRepo, localizer);

    public async Task<Guid> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepo.GetByIdAsync(request.Id, cancellationToken);

        _ = category ?? throw new NotFoundException(_localizer["category.notfound"]);

        await _categoryRepo.DeleteAsync(category, cancellationToken);

        return request.Id;
    }
}