namespace FSH.WebApi.Domain.Catalog;

public class City : AuditableEntity, IAggregateRoot
{
    public City(string name, Guid stateId, Guid countryId)
    {
        Name = name;
        StateId = stateId;
        CountryId = countryId;
    }

    public string? Name { get; private set; }
    public virtual State State { get; set; } = default!;
    public Guid StateId { get; private set; }
    public virtual Country Country { get; set; } = default!;
    public Guid CountryId { get; private set; }
    public bool IsActive { get; private set; }

    public City Update(string? name, Guid? stateId, Guid? countryId)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (stateId.HasValue && stateId.Value != Guid.Empty && !StateId.Equals(stateId.Value)) StateId = stateId.Value;
        if (countryId.HasValue && countryId.Value != Guid.Empty && !CountryId.Equals(countryId.Value)) CountryId = countryId.Value;
        return this;
    }
}
