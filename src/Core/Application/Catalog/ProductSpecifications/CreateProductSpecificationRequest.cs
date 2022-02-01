namespace FSH.WebApi.Application.Catalog.ProductSpecifications;

public class CreateProductSpecificationRequest : IRequest<Guid>
{
    public string Name { get; set; } = default!;
    public string? Value { get; set; }
    public Guid ProductId { get; set; }
    public bool IsActive { get; set; }
}

public class CreateProductSpecificationRequestValidator : CustomValidator<CreateProductSpecificationRequest>
{
    public CreateProductSpecificationRequestValidator(IReadRepository<ProductSpecification> repository, IStringLocalizer<CreateProductSpecificationRequestValidator> localizer) =>
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (name, ct) => await repository.GetBySpecAsync(new ProductSpecificationByNameSpec(name), ct) is null)
                .WithMessage((_, name) => string.Format(localizer["productSpecification.alreadyexists"], name));
}

public class CreateProductSpecificationRequestHandler : IRequestHandler<CreateProductSpecificationRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<ProductSpecification> _repository;

    public CreateProductSpecificationRequestHandler(IRepositoryWithEvents<ProductSpecification> repository) => _repository = repository;

    public async Task<Guid> Handle(CreateProductSpecificationRequest request, CancellationToken cancellationToken)
    {
        var productSpecification = new ProductSpecification(request.Name, request.Value, request.ProductId, request.IsActive);

        await _repository.AddAsync(productSpecification, cancellationToken);

        return productSpecification.Id;
    }
}