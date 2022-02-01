namespace FSH.WebApi.Application.Catalog.ProductReviews;

public class ProductReviewByNameSpec : Specification<ProductReview>, ISingleResultSpecification
{
    public ProductReviewByNameSpec(string name) =>
        Query.Where(b => b.Username == name);
}