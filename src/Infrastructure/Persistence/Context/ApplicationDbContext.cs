using Finbuckle.MultiTenant;
using FSH.WebApi.Application.Common.Events;
using FSH.WebApi.Application.Common.Interfaces;
using FSH.WebApi.Domain.Catalog;
using FSH.WebApi.Infrastructure.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FSH.WebApi.Infrastructure.Persistence.Context;

public class ApplicationDbContext : BaseDbContext
{
    public ApplicationDbContext(ITenantInfo currentTenant, DbContextOptions options, ICurrentUser currentUser, ISerializerService serializer, IOptions<DatabaseSettings> dbSettings, IEventService eventService)
        : base(currentTenant, options, currentUser, serializer, dbSettings, eventService)
    {
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Brand> Brands => Set<Brand>();
    public DbSet<Category> Categorys => Set<Category>();
    public DbSet<City> Citys => Set<City>();
    public DbSet<Country> Countrys => Set<Country>();
    public DbSet<ProductImage> ProductImages => Set<ProductImage>();
    public DbSet<ProductRating> ProductRatings => Set<ProductRating>();
    public DbSet<ProductReview> ProductReviews => Set<ProductReview>();
    public DbSet<ProductSpecification> ProductSpecifications => Set<ProductSpecification>();
    public DbSet<SellerImage> SellerImages => Set<SellerImage>();
    public DbSet<Seller> Sellers => Set<Seller>();
    public DbSet<State> States => Set<State>();
    public DbSet<SubCategory> SubCategorys => Set<SubCategory>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema(SchemaNames.Catalog);
    }
}