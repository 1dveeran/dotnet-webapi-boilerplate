namespace FSH.WebApi.Application.Catalog.Countrys;

public class CountryByNameSpec : Specification<Country>, ISingleResultSpecification
{
    public CountryByNameSpec(string name) =>
        Query.Where(b => b.Name == name);
}