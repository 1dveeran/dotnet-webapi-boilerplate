namespace FSH.WebApi.Application.Catalog.ProductImages;

public class ProductImageByNameSpec : Specification<ProductImage>, ISingleResultSpecification
{
    public ProductImageByNameSpec(string name) =>
        Query.Where(b => b.ImagePath == name);
}