namespace FSH.WebApi.Application.Catalog.ProductImages;

public class UpdateProductImageRequest : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string ImagePath { get; set; } = default!;
    public Guid ProductId { get; set; }
    public bool IsActive { get; set; }
}

public class UpdateProductImageRequestValidator : CustomValidator<UpdateProductImageRequest>
{
    public UpdateProductImageRequestValidator(IRepository<ProductImage> repository, IStringLocalizer<UpdateProductImageRequestValidator> localizer) =>
        RuleFor(p => p.ImagePath)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (productImage, name, ct) =>
                    await repository.GetBySpecAsync(new ProductImageByNameSpec(name), ct)
                        is not ProductImage existingProductImage || existingProductImage.Id == productImage.Id)
                .WithMessage((_, name) => string.Format(localizer["productImage.alreadyexists"], name));
}

public class UpdateProductImageRequestHandler : IRequestHandler<UpdateProductImageRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<ProductImage> _repository;
    private readonly IStringLocalizer<UpdateProductImageRequestHandler> _localizer;

    public UpdateProductImageRequestHandler(IRepositoryWithEvents<ProductImage> repository, IStringLocalizer<UpdateProductImageRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Guid> Handle(UpdateProductImageRequest request, CancellationToken cancellationToken)
    {
        var productImage = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = productImage ?? throw new NotFoundException(string.Format(_localizer["productImage.notfound"], request.Id));

        productImage.Update(request.ImagePath, request.ProductId, request.IsActive);

        await _repository.UpdateAsync(productImage, cancellationToken);

        return request.Id;
    }
}