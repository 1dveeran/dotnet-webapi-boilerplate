using Finbuckle.MultiTenant.EntityFrameworkCore;
using FSH.WebApi.Domain.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FSH.WebApi.Infrastructure.Persistence.Configuration;

public class BrandConfig : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.IsMultiTenant();

        builder
            .Property(b => b.Name)
                .HasMaxLength(256);
        builder
            .Property(b => b.Description)
                .HasColumnType("text");
        builder
            .Property(b => b.IsActive)
                .HasColumnType("boolean")
                .HasDefaultValue(true);
    }
}

public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.IsMultiTenant();

        builder
            .Property(b => b.Name)
                .HasMaxLength(1024);
        builder
           .Property(b => b.Description)
               .HasColumnType("text");
        builder
           .Property(b => b.Tags)
               .HasColumnType("text");
        builder
           .Property(b => b.MrpPrice)
               .HasColumnType("numeric(15,6)")
               .HasDefaultValue(0);
        builder
           .Property(b => b.SellingPrice)
               .HasColumnType("numeric(15,6)")
               .HasDefaultValue(0);
        builder
           .Property(b => b.DiscountPrice)
               .HasColumnType("numeric(15,6)")
               .HasDefaultValue(0);
        builder
           .Property(b => b.DiscountPercentage)
               .HasColumnType("numeric(5,2)")
               .HasDefaultValue(0);
        builder
           .Property(b => b.Rate)
               .HasColumnType("numeric(15,6)")
               .HasDefaultValue(0);
        builder
           .Property(b => b.DiscountDetails)
               .HasColumnType("text");
        builder
            .Property(b => b.IsPublished)
                .HasColumnType("boolean")
                .HasDefaultValue(false);
        builder
            .Property(b => b.IsApproved)
                .HasColumnType("boolean")
                .HasDefaultValue(false);
        builder
            .Property(b => b.IsActive)
                .HasColumnType("boolean")
                .HasDefaultValue(true);
    }
}

public class CountryConfig : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder
            .Property(b => b.Name)
                .HasMaxLength(256);
        builder
            .Property(b => b.IsActive)
                .HasColumnType("boolean")
                .HasDefaultValue(true);
    }
}

public class StateConfig : IEntityTypeConfiguration<State>
{
    public void Configure(EntityTypeBuilder<State> builder)
    {
        builder
            .Property(b => b.Name)
                .HasMaxLength(256);
        builder
            .Property(b => b.IsActive)
                .HasColumnType("boolean")
                .HasDefaultValue(true);
    }
}

public class CityConfig : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder
            .Property(b => b.Name)
                .HasMaxLength(256);
        builder
           .Property(b => b.IsActive)
               .HasColumnType("boolean")
               .HasDefaultValue(true);
    }
}

public class CategoryConfig : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.IsMultiTenant();

        builder
            .Property(b => b.Name)
                .HasMaxLength(256);
        builder
           .Property(b => b.IsActive)
               .HasColumnType("boolean")
               .HasDefaultValue(true);
    }
}

public class SubCategoryConfig : IEntityTypeConfiguration<SubCategory>
{
    public void Configure(EntityTypeBuilder<SubCategory> builder)
    {
        builder.IsMultiTenant();

        builder
            .Property(b => b.Name)
                .HasMaxLength(256);
        builder
            .Property(b => b.IsActive)
                .HasColumnType("boolean")
                .HasDefaultValue(true);
    }
}

public class ProdutImageConfig : IEntityTypeConfiguration<ProductImage>
{
    public void Configure(EntityTypeBuilder<ProductImage> builder)
    {
        builder.IsMultiTenant();

        builder
            .Property(b => b.ImagePath)
                .HasColumnType("text");
        builder
           .Property(b => b.IsActive)
               .HasColumnType("boolean")
               .HasDefaultValue(true);
    }
}

public class ProductRatingConfig : IEntityTypeConfiguration<ProductRating>
{
    public void Configure(EntityTypeBuilder<ProductRating> builder)
    {
        builder.IsMultiTenant();

        builder
           .Property(b => b.Rating)
               .HasColumnType("numeric(5,2)")
               .HasDefaultValue(0);
        builder
           .Property(b => b.IsActive)
               .HasColumnType("boolean")
               .HasDefaultValue(true);
    }
}

public class ProductReviewConfig : IEntityTypeConfiguration<ProductReview>
{
    public void Configure(EntityTypeBuilder<ProductReview> builder)
    {
        builder.IsMultiTenant();

        builder
            .Property(b => b.Comment)
                .HasColumnType("text");
        builder
            .Property(b => b.Username)
                .HasMaxLength(256);
        builder
           .Property(b => b.IsActive)
               .HasColumnType("boolean")
               .HasDefaultValue(true);
    }
}

public class ProductSpecificationConfig : IEntityTypeConfiguration<ProductSpecification>
{
    public void Configure(EntityTypeBuilder<ProductSpecification> builder)
    {
        builder.IsMultiTenant();

        builder
            .Property(b => b.Name)
                .HasMaxLength(256);
        builder
            .Property(b => b.Value)
                .HasColumnType("text");
        builder
           .Property(b => b.IsActive)
               .HasColumnType("boolean")
               .HasDefaultValue(true);
    }
}

public class SellerConfig : IEntityTypeConfiguration<Seller>
{
    public void Configure(EntityTypeBuilder<Seller> builder)
    {
        builder.IsMultiTenant();

        builder
            .Property(b => b.ShopName)
                .HasMaxLength(1024);
        builder
            .Property(b => b.GstNumber)
                .HasMaxLength(256);
        builder
            .Property(b => b.Address1)
                .HasColumnType("text");
        builder
            .Property(b => b.Address2)
                .HasColumnType("text");
        builder
            .Property(b => b.Pin)
                .HasMaxLength(256);
        builder
            .Property(b => b.Latitude)
                .HasMaxLength(256);
        builder
            .Property(b => b.Longitude)
                .HasMaxLength(256);
        builder
           .Property(b => b.IsActive)
               .HasColumnType("boolean")
               .HasDefaultValue(true);
    }
}

public class SellerImageConfig : IEntityTypeConfiguration<SellerImage>
{
    public void Configure(EntityTypeBuilder<SellerImage> builder)
    {
        builder.IsMultiTenant();

        builder
            .Property(b => b.ImagePath)
                .HasColumnType("text");
        builder
           .Property(b => b.IsActive)
               .HasColumnType("boolean")
               .HasDefaultValue(true);
    }
}

public class SearchConfig : IEntityTypeConfiguration<SearchItem>
{
    public void Configure(EntityTypeBuilder<SearchItem> builder)
    {
        builder
            .Property(b => b.Name)
                .HasColumnType("text");
        builder
            .Property(b => b.IsActive)
                .HasColumnType("boolean")
                .HasDefaultValue(true);
    }
}
