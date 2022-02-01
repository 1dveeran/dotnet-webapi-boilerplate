namespace FSH.WebApi.Application.Catalog.SubCategorys;

public class SubCategoryByNameSpec : Specification<SubCategory>, ISingleResultSpecification
{
    public SubCategoryByNameSpec(string name) =>
        Query.Where(b => b.Name == name);
}