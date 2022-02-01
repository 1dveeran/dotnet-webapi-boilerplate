using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.Catalog.Products;

public class UpdateProductRequest : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public string? Tags { get; set; }
    public decimal MrpPrice { get; set; }
    public decimal SellingPrice { get; set; }
    public decimal DiscountPrice { get; set; }
    public decimal DiscountPercentage { get; set; }
    public decimal Rate { get; set; }
    public string? DiscountDetails { get; set; }
    public Guid BrandId { get; set; }
    public bool IsPublished { get; set; }
    public bool IsApproved { get; set; }
    public bool IsActive { get; set; }
}

public class UpdateProductRequestHandler : IRequestHandler<UpdateProductRequest, Guid>
{
    private readonly IRepository<Product> _repository;
    private readonly IStringLocalizer<UpdateProductRequestHandler> _localizer;

    public UpdateProductRequestHandler(IRepository<Product> repository, IStringLocalizer<UpdateProductRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Guid> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = product ?? throw new NotFoundException(string.Format(_localizer["product.notfound"], request.Id));

        // Remove old image if there is a new image uploaded
        if (request.Image != null)
        {
            string? currentProductImagePath = product.ImagePath;
            if (!string.IsNullOrEmpty(currentProductImagePath))
            {
                string root = Directory.GetCurrentDirectory();
                _file.Remove(Path.Combine(root, currentProductImagePath));
            }
        }

        string? productImagePath = request.Image is not null
            ? await _file.UploadAsync<Product>(request.Image, FileType.Image, cancellationToken)
            : null;

        var updatedProduct = product.Update(request.Name, request.Description, request.Rate, request.BrandId, productImagePath);

        // Add Domain Events to be raised after the commit
        product.DomainEvents.Add(EntityUpdatedEvent.WithEntity(product));

        await _repository.UpdateAsync(product, cancellationToken);

        return request.Id;
    }
}