namespace FSH.WebApi.Application.Catalog.Sellers;

public class SellerByNameSpec : Specification<Seller>, ISingleResultSpecification
{
    public SellerByNameSpec(string name) =>
        Query.Where(b => b.ShopName == name);
}