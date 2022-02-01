namespace FSH.WebApi.Application.Catalog.ProductImages;

public class CreateProductImageRequest : IRequest<Guid>
{
    public string ImagePath { get; set; } = default!;
    public Guid ProductId { get; set; }
    public bool IsActive { get; set; }
}

public class CreateProductImageRequestValidator : CustomValidator<CreateProductImageRequest>
{
    public CreateProductImageRequestValidator(IReadRepository<ProductImage> repository, IStringLocalizer<CreateProductImageRequestValidator> localizer) =>
        RuleFor(p => p.ImagePath)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (name, ct) => await repository.GetBySpecAsync(new ProductImageByNameSpec(name), ct) is null)
                .WithMessage((_, name) => string.Format(localizer["productImage.alreadyexists"], name));
}

public class CreateProductImageRequestHandler : IRequestHandler<CreateProductImageRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<ProductImage> _repository;

    public CreateProductImageRequestHandler(IRepositoryWithEvents<ProductImage> repository) => _repository = repository;

    public async Task<Guid> Handle(CreateProductImageRequest request, CancellationToken cancellationToken)
    {
        var productImage = new ProductImage(request.ImagePath, request.ProductId, request.IsActive);

        await _repository.AddAsync(productImage, cancellationToken);

        return productImage.Id;
    }
}