namespace FSH.WebApi.Application.Catalog.Citys;

public class CityByNameSpec : Specification<City>, ISingleResultSpecification
{
    public CityByNameSpec(string name) =>
        Query.Where(b => b.Name == name);
}