using System.Collections.ObjectModel;

namespace FSH.WebApi.Shared.Authorization;

public static class FSHAction
{
    public const string View = nameof(View);
    public const string Search = nameof(Search);
    public const string Create = nameof(Create);
    public const string Update = nameof(Update);
    public const string Delete = nameof(Delete);
    public const string Export = nameof(Export);
    public const string Generate = nameof(Generate);
    public const string Clean = nameof(Clean);
    public const string UpgradeSubscription = nameof(UpgradeSubscription);
}

public static class FSHResource
{
    public const string Tenants = nameof(Tenants);
    public const string Dashboard = nameof(Dashboard);
    public const string Hangfire = nameof(Hangfire);
    public const string Users = nameof(Users);
    public const string UserRoles = nameof(UserRoles);
    public const string Roles = nameof(Roles);
    public const string RoleClaims = nameof(RoleClaims);
    public const string Products = nameof(Products);
    public const string Brands = nameof(Brands);
    public const string Category = nameof(Category);
    public const string SubCategory = nameof(SubCategory);
    public const string ProductImage = nameof(ProductImage);
    public const string ProductRating = nameof(ProductRating);
    public const string ProductReview = nameof(ProductReview);
    public const string ProductSpecification = nameof(ProductSpecification);
    public const string Seller = nameof(Seller);
    public const string SellerImage = nameof(SellerImage);
    public const string Country = nameof(Country);
    public const string State = nameof(State);
    public const string City = nameof(City);
}

public static class FSHPermissions
{
    private static readonly FSHPermission[] _all = new FSHPermission[]
    {
        new("View Dashboard", FSHAction.View, FSHResource.Dashboard),
        new("View Hangfire", FSHAction.View, FSHResource.Hangfire),
        new("View Users", FSHAction.View, FSHResource.Users),
        new("Search Users", FSHAction.Search, FSHResource.Users),
        new("Create Users", FSHAction.Create, FSHResource.Users),
        new("Update Users", FSHAction.Update, FSHResource.Users),
        new("Delete Users", FSHAction.Delete, FSHResource.Users),
        new("Export Users", FSHAction.Export, FSHResource.Users),
        new("View UserRoles", FSHAction.View, FSHResource.UserRoles),
        new("Update UserRoles", FSHAction.Update, FSHResource.UserRoles),
        new("View Roles", FSHAction.View, FSHResource.Roles),
        new("Create Roles", FSHAction.Create, FSHResource.Roles),
        new("Update Roles", FSHAction.Update, FSHResource.Roles),
        new("Delete Roles", FSHAction.Delete, FSHResource.Roles),
        new("View RoleClaims", FSHAction.View, FSHResource.RoleClaims),
        new("Update RoleClaims", FSHAction.Update, FSHResource.RoleClaims),
        new("View Products", FSHAction.View, FSHResource.Products, IsBasic: true),
        new("Search Products", FSHAction.Search, FSHResource.Products, IsBasic: true),
        new("Create Products", FSHAction.Create, FSHResource.Products),
        new("Update Products", FSHAction.Update, FSHResource.Products),
        new("Delete Products", FSHAction.Delete, FSHResource.Products),
        new("Export Products", FSHAction.Export, FSHResource.Products),
        new("View Product Image", FSHAction.View, FSHResource.ProductImage, IsBasic: true),
        new("Search Product Image", FSHAction.Search, FSHResource.ProductImage, IsBasic: true),
        new("Create Product Image", FSHAction.Create, FSHResource.ProductImage),
        new("Update Product Image", FSHAction.Update, FSHResource.ProductImage),
        new("Delete Product Image", FSHAction.Delete, FSHResource.ProductImage),
        new("Export Product Image", FSHAction.Export, FSHResource.ProductImage),
        new("View Product Review", FSHAction.View, FSHResource.ProductReview, IsBasic: true),
        new("Search Product Review", FSHAction.Search, FSHResource.ProductReview, IsBasic: true),
        new("Create Product Review", FSHAction.Create, FSHResource.ProductReview),
        new("Update Product Review", FSHAction.Update, FSHResource.ProductReview),
        new("Delete Product Review", FSHAction.Delete, FSHResource.ProductReview),
        new("Export Product Review", FSHAction.Export, FSHResource.ProductReview),
        new("View Product Rating", FSHAction.View, FSHResource.ProductRating, IsBasic: true),
        new("Search Product Rating", FSHAction.Search, FSHResource.ProductRating, IsBasic: true),
        new("Create Product Rating", FSHAction.Create, FSHResource.ProductRating),
        new("Update Product Rating", FSHAction.Update, FSHResource.ProductRating),
        new("Delete Product Rating", FSHAction.Delete, FSHResource.ProductRating),
        new("Export Product Rating", FSHAction.Export, FSHResource.ProductRating),
        new("View Product Specification", FSHAction.View, FSHResource.ProductSpecification, IsBasic: true),
        new("Search Product Specification", FSHAction.Search, FSHResource.ProductSpecification, IsBasic: true),
        new("Create Product Specification", FSHAction.Create, FSHResource.ProductSpecification),
        new("Update Product Specification", FSHAction.Update, FSHResource.ProductSpecification),
        new("Delete Product Specification", FSHAction.Delete, FSHResource.ProductSpecification),
        new("Export Product Specification", FSHAction.Export, FSHResource.ProductSpecification),
        new("View Seller", FSHAction.View, FSHResource.Seller, IsBasic: true),
        new("Search Seller", FSHAction.Search, FSHResource.Seller, IsBasic: true),
        new("Create Seller", FSHAction.Create, FSHResource.Seller),
        new("Update Seller", FSHAction.Update, FSHResource.Seller),
        new("Delete Seller", FSHAction.Delete, FSHResource.Seller),
        new("Export Seller", FSHAction.Export, FSHResource.Seller),
        new("View SellerImage", FSHAction.View, FSHResource.SellerImage, IsBasic: true),
        new("Search SellerImage", FSHAction.Search, FSHResource.SellerImage, IsBasic: true),
        new("Create SellerImage", FSHAction.Create, FSHResource.SellerImage),
        new("Update SellerImage", FSHAction.Update, FSHResource.SellerImage),
        new("Delete SellerImage", FSHAction.Delete, FSHResource.SellerImage),
        new("Export SellerImage", FSHAction.Export, FSHResource.SellerImage),
        new("View Category", FSHAction.View, FSHResource.Category, IsBasic: true),
        new("Search Category", FSHAction.Search, FSHResource.Category, IsBasic: true),
        new("Create Category", FSHAction.Create, FSHResource.Category),
        new("Update Category", FSHAction.Update, FSHResource.Category),
        new("Delete Category", FSHAction.Delete, FSHResource.Category),
        new("Export Category", FSHAction.Export, FSHResource.Category),
        new("View SubCategory", FSHAction.View, FSHResource.SubCategory, IsBasic: true),
        new("Search SubCategory", FSHAction.Search, FSHResource.SubCategory, IsBasic: true),
        new("Create SubCategory", FSHAction.Create, FSHResource.SubCategory),
        new("Update SubCategory", FSHAction.Update, FSHResource.SubCategory),
        new("Delete SubCategory", FSHAction.Delete, FSHResource.SubCategory),
        new("Export SubCategory", FSHAction.Export, FSHResource.SubCategory),
        new("View Country", FSHAction.View, FSHResource.Country, IsBasic: true),
        new("Search Country", FSHAction.Search, FSHResource.Country, IsBasic: true),
        new("Create Country", FSHAction.Create, FSHResource.Country),
        new("Update Country", FSHAction.Update, FSHResource.Country),
        new("Delete Country", FSHAction.Delete, FSHResource.Country),
        new("Export Country", FSHAction.Export, FSHResource.Country),
        new("View State", FSHAction.View, FSHResource.State, IsBasic: true),
        new("Search State", FSHAction.Search, FSHResource.State, IsBasic: true),
        new("Create State", FSHAction.Create, FSHResource.State),
        new("Update State", FSHAction.Update, FSHResource.State),
        new("Delete State", FSHAction.Delete, FSHResource.State),
        new("Export State", FSHAction.Export, FSHResource.State),
        new("View City", FSHAction.View, FSHResource.City, IsBasic: true),
        new("Search City", FSHAction.Search, FSHResource.City, IsBasic: true),
        new("Create City", FSHAction.Create, FSHResource.City),
        new("Update City", FSHAction.Update, FSHResource.City),
        new("Delete City", FSHAction.Delete, FSHResource.City),
        new("Export City", FSHAction.Export, FSHResource.City),
        new("View Brands", FSHAction.View, FSHResource.Brands, IsBasic: true),
        new("Search Brands", FSHAction.Search, FSHResource.Brands, IsBasic: true),
        new("Create Brands", FSHAction.Create, FSHResource.Brands),
        new("Update Brands", FSHAction.Update, FSHResource.Brands),
        new("Delete Brands", FSHAction.Delete, FSHResource.Brands),
        new("Generate Brands", FSHAction.Generate, FSHResource.Brands),
        new("Clean Brands", FSHAction.Clean, FSHResource.Brands),
        new("View Tenants", FSHAction.View, FSHResource.Tenants, IsRoot: true),
        new("Create Tenants", FSHAction.Create, FSHResource.Tenants, IsRoot: true),
        new("Update Tenants", FSHAction.Update, FSHResource.Tenants, IsRoot: true),
        new("Upgrade Tenant Subscription", FSHAction.UpgradeSubscription, FSHResource.Tenants, IsRoot: true)
    };

    public static IReadOnlyList<FSHPermission> All { get; } = new ReadOnlyCollection<FSHPermission>(_all);
    public static IReadOnlyList<FSHPermission> Root { get; } = new ReadOnlyCollection<FSHPermission>(_all.Where(p => p.IsRoot).ToArray());
    public static IReadOnlyList<FSHPermission> Admin { get; } = new ReadOnlyCollection<FSHPermission>(_all.Where(p => !p.IsRoot).ToArray());
    public static IReadOnlyList<FSHPermission> Basic { get; } = new ReadOnlyCollection<FSHPermission>(_all.Where(p => p.IsBasic).ToArray());
}

public record FSHPermission(string Description, string Action, string Resource, bool IsBasic = false, bool IsRoot = false)
{
    public string Name => NameFor(Action, Resource);
    public static string NameFor(string action, string resource) => $"Permissions.{resource}.{action}";
}
