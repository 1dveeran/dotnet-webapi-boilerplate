namespace FSH.WebApi.Application.Catalog.Categorys;

public class CreateCategoryRequest : IRequest<Guid>
{
    public string Name { get; set; } = default!;
    public bool IsActive { get; set; }
}

public class CreateCategoryRequestValidator : CustomValidator<CreateCategoryRequest>
{
    public CreateCategoryRequestValidator(IReadRepository<Category> repository, IStringLocalizer<CreateCategoryRequestValidator> localizer) =>
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (name, ct) => await repository.GetBySpecAsync(new CategoryByNameSpec(name), ct) is null)
                .WithMessage((_, name) => string.Format(localizer["category.alreadyexists"], name));
}

public class CreateCategoryRequestHandler : IRequestHandler<CreateCategoryRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Category> _repository;

    public CreateCategoryRequestHandler(IRepositoryWithEvents<Category> repository) => _repository = repository;

    public async Task<Guid> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        var category = new Category(request.Name, request.IsActive);

        await _repository.AddAsync(category, cancellationToken);

        return category.Id;
    }
}