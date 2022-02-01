namespace FSH.WebApi.Application.Catalog.SubCategorys;

public class CreateSubCategoryRequest : IRequest<Guid>
{
    public string Name { get; set; } = default!;
    public Guid CategoryId { get; set; }
    public bool IsActive { get; set; }
}

public class CreateSubCategoryRequestValidator : CustomValidator<CreateSubCategoryRequest>
{
    public CreateSubCategoryRequestValidator(IReadRepository<SubCategory> repository, IStringLocalizer<CreateSubCategoryRequestValidator> localizer) =>
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (name, ct) => await repository.GetBySpecAsync(new SubCategoryByNameSpec(name), ct) is null)
                .WithMessage((_, name) => string.Format(localizer["subCategory.alreadyexists"], name));
}

public class CreateSubCategoryRequestHandler : IRequestHandler<CreateSubCategoryRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<SubCategory> _repository;

    public CreateSubCategoryRequestHandler(IRepositoryWithEvents<SubCategory> repository) => _repository = repository;

    public async Task<Guid> Handle(CreateSubCategoryRequest request, CancellationToken cancellationToken)
    {
        var subCategory = new SubCategory(request.Name, request.CategoryId, request.IsActive);

        await _repository.AddAsync(subCategory, cancellationToken);

        return subCategory.Id;
    }
}