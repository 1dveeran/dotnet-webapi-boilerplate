namespace FSH.WebApi.Application.Catalog.Categorys;

public class CategoryByNameSpec : Specification<Category>, ISingleResultSpecification
{
    public CategoryByNameSpec(string name) =>
        Query.Where(b => b.Name == name);
}