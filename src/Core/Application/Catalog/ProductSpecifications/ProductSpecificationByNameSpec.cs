namespace FSH.WebApi.Application.Catalog.ProductSpecifications;

public class ProductSpecificationByNameSpec : Specification<ProductSpecification>, ISingleResultSpecification
{
    public ProductSpecificationByNameSpec(string name) =>
        Query.Where(b => b.Name == name);
}