using FSH.WebApi.Application.Catalog.Brands;

namespace FSH.WebApi.Application.Catalog.Products;

public class ProductDetailsDto : IDto
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
    public BrandDto Brand { get; set; } = default!;
    public bool IsPublished { get; set; }
    public bool IsApproved { get; set; }
    public bool IsActive { get; set; }
}