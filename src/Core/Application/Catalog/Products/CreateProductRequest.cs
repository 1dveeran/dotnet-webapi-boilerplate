using FSH.WebApi.Domain.Common.Events;

namespace FSH.WebApi.Application.Catalog.Products;

public class CreateProductRequest : IRequest<Guid>
{
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

public class CreateProductRequestHandler : IRequestHandler<CreateProductRequest, Guid>
{
    private readonly IRepository<Product> _repository;

    public CreateProductRequestHandler(IRepository<Product> repository) =>
        _repository = repository;

    public async Task<Guid> Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
        // string productImagePath = await _file.UploadAsync<Product>(request.Image, FileType.Image, cancellationToken);

        var product = new Product(request.Name, request.Description, request.Tags, request.MrpPrice, request.SellingPrice, request.DiscountPrice, request.DiscountPercentage, request.Rate, request.DiscountDetails, request.BrandId, request.IsPublished, request.IsApproved, request.IsActive);

        // Add Domain Events to be raised after the commit
        product.DomainEvents.Add(EntityCreatedEvent.WithEntity(product));

        await _repository.AddAsync(product, cancellationToken);

        return product.Id;
    }
}