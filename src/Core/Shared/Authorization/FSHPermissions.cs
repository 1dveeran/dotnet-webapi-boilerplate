using System.ComponentModel;

namespace FSH.WebApi.Shared.Authorization;

public class FSHPermissions
{
    [DisplayName("Dashboard")]
    [Description("Dashboard Permissions")]
    public static class Dashboard
    {
        public const string View = "Permissions.Dashboard.View";
    }

    [DisplayName("AuditLogs")]
    [Description("AuditLogs Permissions")]
    public static class AuditLogs
    {
        public const string View = "Permissions.AuditLogs.View";
    }

    [DisplayName("Hangfire")]
    [Description("Hangfire Permissions")]
    public static class Hangfire
    {
        public const string View = "Permissions.Hangfire.View";
    }

    [DisplayName("Identity")]
    [Description("Identity Permissions")]
    public static class Identity
    {
        public const string Create = "Permissions.Identity.Create";
    }

    [DisplayName("Users")]
    [Description("Users Permissions")]
    public static class Users
    {
        public const string View = "Permissions.Users.View";
        public const string Create = "Permissions.Users.Create";
        public const string Update = "Permissions.Users.Update";
        public const string Delete = "Permissions.Users.Delete";
        public const string Export = "Permissions.Users.Export";
        public const string Search = "Permissions.Users.Search";
    }

    [DisplayName("Roles")]
    [Description("Roles Permissions")]
    public static class Roles
    {
        public const string View = "Permissions.Roles.View";
        public const string Create = "Permissions.Roles.Create";
        public const string Update = "Permissions.Roles.Update";
        public const string Delete = "Permissions.Roles.Delete";
    }

    [DisplayName("Role Claims")]
    [Description("Role Claims Permissions")]
    public static class RoleClaims
    {
        public const string View = "Permissions.RoleClaims.View";
        public const string Create = "Permissions.RoleClaims.Create";
        public const string Update = "Permissions.RoleClaims.Update";
        public const string Delete = "Permissions.RoleClaims.Delete";
        public const string Search = "Permissions.RoleClaims.Search";
    }

    [DisplayName("Products")]
    [Description("Products Permissions")]
    public static class Products
    {
        public const string View = "Permissions.Products.View";
        public const string Search = "Permissions.Products.Search";
        public const string Create = "Permissions.Products.Create";
        public const string Update = "Permissions.Products.Update";
        public const string Delete = "Permissions.Products.Delete";
    }

    [DisplayName("Brands")]
    [Description("Brands Permissions")]
    public static class Brands
    {
        public const string View = "Permissions.Brands.View";
        public const string Search = "Permissions.Brands.Search";
        public const string Create = "Permissions.Brands.Create";
        public const string Update = "Permissions.Brands.Update";
        public const string Delete = "Permissions.Brands.Delete";
        public const string Generate = "Permissions.Brands.Generate";
        public const string Clean = "Permissions.Brands.Clean";
    }

     [DisplayName("Country")]
    [Description("Country Permissions")]
    public static class Country
    {
        public const string View = "Permissions.Country.View";
        public const string Search = "Permissions.Country.Search";
        public const string Create = "Permissions.Country.Create";
        public const string Update = "Permissions.Country.Update";
        public const string Delete = "Permissions.Country.Delete";
    }

    [DisplayName("State")]
    [Description("State Permissions")]
    public static class State
    {
        public const string View = "Permissions.State.View";
        public const string Search = "Permissions.State.Search";
        public const string Register = "Permissions.State.Register";
        public const string Update = "Permissions.State.Update";
        public const string Remove = "Permissions.State.Remove";
    }

    [DisplayName("City")]
    [Description("City Permissions")]
    public static class City
    {
        public const string View = "Permissions.City.View";
        public const string Search = "Permissions.City.Search";
        public const string Create = "Permissions.City.Create";
        public const string Update = "Permissions.City.Update";
        public const string Delete = "Permissions.City.Delete";
    }

    [DisplayName("Category")]
    [Description("Category Permissions")]
    public static class Category
    {
        public const string View = "Permissions.Category.View";
        public const string Search = "Permissions.Category.Search";
        public const string Register = "Permissions.Category.Register";
        public const string Update = "Permissions.Category.Update";
        public const string Remove = "Permissions.Category.Remove";
    }

    [DisplayName("SubCategory")]
    [Description("SubCategory Permissions")]
    public static class SubCategory
    {
        public const string View = "Permissions.SubCategory.View";
        public const string Search = "Permissions.SubCategory.Search";
        public const string Register = "Permissions.SubCategory.Register";
        public const string Update = "Permissions.SubCategory.Update";
        public const string Remove = "Permissions.SubCategory.Remove";
    }

    [DisplayName("Seller")]
    [Description("Seller Permissions")]
    public static class Seller
    {
        public const string View = "Permissions.Seller.View";
        public const string Search = "Permissions.Seller.Search";
        public const string Register = "Permissions.Seller.Register";
        public const string Update = "Permissions.Seller.Update";
        public const string Remove = "Permissions.Seller.Remove";
    }

    [DisplayName("SellerImage")]
    [Description("SellerImage Permissions")]
    public static class SellerImage
    {
        public const string View = "Permissions.SellerImage.View";
        public const string Search = "Permissions.SellerImage.Search";
        public const string Register = "Permissions.SellerImage.Register";
        public const string Update = "Permissions.SellerImage.Update";
        public const string Remove = "Permissions.SellerImage.Remove";
    }

    [DisplayName("ProductImage")]
    [Description("ProductImage Permissions")]
    public static class ProductImage
    {
        public const string View = "Permissions.ProductImage.View";
        public const string Search = "Permissions.ProductImage.Search";
        public const string Register = "Permissions.ProductImage.Register";
        public const string Update = "Permissions.ProductImage.Update";
        public const string Remove = "Permissions.ProductImage.Remove";
    }

    [DisplayName("ProductRating")]
    [Description("ProductRating Permissions")]
    public static class ProductRating
    {
        public const string View = "Permissions.ProductRating.View";
        public const string Search = "Permissions.ProductRating.Search";
        public const string Register = "Permissions.ProductRating.Register";
        public const string Update = "Permissions.ProductRating.Update";
        public const string Remove = "Permissions.ProductRating.Remove";
    }

    [DisplayName("ProductReview")]
    [Description("ProductReview Permissions")]
    public static class ProductReview
    {
        public const string View = "Permissions.ProductReview.View";
        public const string Search = "Permissions.ProductReview.Search";
        public const string Register = "Permissions.ProductReview.Register";
        public const string Update = "Permissions.ProductReview.Update";
        public const string Remove = "Permissions.ProductReview.Remove";
    }

    [DisplayName("ProductSpecification")]
    [Description("ProductSpecification Permissions")]
    public static class ProductSpecification
    {
        public const string View = "Permissions.ProductSpecification.View";
        public const string Search = "Permissions.ProductSpecification.Search";
        public const string Register = "Permissions.ProductSpecification.Register";
        public const string Update = "Permissions.ProductSpecification.Update";
        public const string Remove = "Permissions.ProductSpecification.Remove";
    }
}