namespace FSH.WebApi.Application.Catalog.States;

public class StateByNameSpec : Specification<State>, ISingleResultSpecification
{
    public StateByNameSpec(string name) =>
        Query.Where(p => p.Name == name);
}
