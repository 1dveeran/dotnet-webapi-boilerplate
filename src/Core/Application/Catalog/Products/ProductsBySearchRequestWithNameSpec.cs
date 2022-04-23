namespace FSH.WebApi.Application.Catalog.Products;

public class ProductsBySearchRequestWithNameSpec : EntitiesByPaginationFilterSpec<Product, ProductDto>
{
    public ProductsBySearchRequestWithNameSpec(SearchByProductNameRequest request)
        : base(request) =>
        Query
            .Include(p => p.Brand)
            .OrderBy(c => c.Name, !request.HasOrderBy())
            .Where(p => p.Rate >= request.MinimumRate!.Value, request.MinimumRate.HasValue)
            .Where(p => p.Rate <= request.MaximumRate!.Value, request.MaximumRate.HasValue);
}