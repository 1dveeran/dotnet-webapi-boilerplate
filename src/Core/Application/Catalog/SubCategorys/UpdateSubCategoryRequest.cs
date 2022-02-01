namespace FSH.WebApi.Application.Catalog.SubCategorys;

public class UpdateSubCategoryRequest : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public Guid CategoryId { get; set; }
    public bool IsActive { get; set; }
}

    public class UpdateSubCategoryRequestValidator : CustomValidator<UpdateSubCategoryRequest>
{
    public UpdateSubCategoryRequestValidator(IRepository<SubCategory> repository, IStringLocalizer<UpdateSubCategoryRequestValidator> localizer) =>
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (subCategory, name, ct) =>
                    await repository.GetBySpecAsync(new SubCategoryByNameSpec(name), ct)
                        is not SubCategory existingSubCategory || existingSubCategory.Id == subCategory.Id)
                .WithMessage((_, name) => string.Format(localizer["subCategory.alreadyexists"], name));
}

public class UpdateSubCategoryRequestHandler : IRequestHandler<UpdateSubCategoryRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<SubCategory> _repository;
    private readonly IStringLocalizer<UpdateSubCategoryRequestHandler> _localizer;

    public UpdateSubCategoryRequestHandler(IRepositoryWithEvents<SubCategory> repository, IStringLocalizer<UpdateSubCategoryRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Guid> Handle(UpdateSubCategoryRequest request, CancellationToken cancellationToken)
    {
        var subCategory = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = subCategory ?? throw new NotFoundException(string.Format(_localizer["subCategory.notfound"], request.Id));

        subCategory.Update(request.Name, request.CategoryId, request.IsActive);

        await _repository.UpdateAsync(subCategory, cancellationToken);

        return request.Id;
    }
}