namespace FSH.WebApi.Domain.Catalog;

public class Product : AuditableEntity, IAggregateRoot
{
    public string Name { get; private set; } = default!;
    public string? Description { get; private set; }
    public string? Tags { get; private set; }
    public decimal MrpPrice { get; private set; }
    public decimal SellingPrice { get; private set; }
    public decimal DiscountPrice { get; private set; }
    public decimal DiscountPercentage { get; private set; }
    public decimal Rate { get; private set; }
    public string? DiscountDetails { get; set; }
    public Guid BrandId { get; private set; }
    public virtual Brand Brand { get; private set; } = default!;
    public bool IsPublished { get; set; }
    public bool IsApproved { get; set; }
    public bool IsActive { get; set; }

    public Product(string name, string? description, decimal rate, Guid brandId)
    {
        Name = name;
        Description = description;
        Rate = rate;
        BrandId = brandId;
    }

    public Product(string name, string? description, string? tags, decimal mrpPrice, decimal sellingPrice, decimal discountPrice, decimal discountPercentage, decimal rate, string? discountDetails, Guid brandId, bool isPublished, bool isApproved, bool isActive)
    {
        Name = name;
        Description = description;
        Tags = tags;
        MrpPrice = mrpPrice;
        SellingPrice = sellingPrice;
        DiscountPrice = discountPrice;
        DiscountPercentage = discountPercentage;
        Rate = rate;
        DiscountDetails = discountDetails;
        BrandId = brandId;
        IsPublished = isPublished;
        IsApproved = isApproved;
        IsActive = isActive;
    }

    public object Update(string name, string? description, string? tags, decimal mrpPrice, decimal sellingPrice, decimal discountPrice, decimal discountPercentage, decimal rate, string? discountDetails, Guid brandId, bool isPublished, bool isApproved, bool isActive)
    {
        throw new NotImplementedException();
    }

    public Product Update(string? name, string? description, decimal? rate, Guid? brandId)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (description is not null && Description?.Equals(description) is not true) Description = description;
        if (rate.HasValue && Rate != rate) Rate = rate.Value;
        if (brandId.HasValue && brandId.Value != Guid.Empty && !BrandId.Equals(brandId.Value)) BrandId = brandId.Value;
        return this;
    }

    public Product ClearImagePath()
    {
        ImagePath = string.Empty;
        return this;
    }
}