namespace FSH.WebApi.Application.Catalog.ProductSpecifications;

public class UpdateProductSpecificationRequest : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Value { get; set; }
    public Guid ProductId { get; set; }
    public bool IsActive { get; set; }
}

public class UpdateProductSpecificationRequestValidator : CustomValidator<UpdateProductSpecificationRequest>
{
    public UpdateProductSpecificationRequestValidator(IRepository<ProductSpecification> repository, IStringLocalizer<UpdateProductSpecificationRequestValidator> localizer) =>
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (productSpecification, name, ct) =>
                    await repository.GetBySpecAsync(new ProductSpecificationByNameSpec(name), ct)
                        is not ProductSpecification existingProductSpecification || existingProductSpecification.Id == productSpecification.Id)
                .WithMessage((_, name) => string.Format(localizer["productSpecification.alreadyexists"], name));
}

public class UpdateProductSpecificationRequestHandler : IRequestHandler<UpdateProductSpecificationRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<ProductSpecification> _repository;
    private readonly IStringLocalizer<UpdateProductSpecificationRequestHandler> _localizer;

    public UpdateProductSpecificationRequestHandler(IRepositoryWithEvents<ProductSpecification> repository, IStringLocalizer<UpdateProductSpecificationRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Guid> Handle(UpdateProductSpecificationRequest request, CancellationToken cancellationToken)
    {
        var productSpecification = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = productSpecification ?? throw new NotFoundException(string.Format(_localizer["productSpecification.notfound"], request.Id));

        productSpecification.Update(request.Name, request.Value, request.ProductId, request.IsActive);

        await _repository.UpdateAsync(productSpecification, cancellationToken);

        return request.Id;
    }
}