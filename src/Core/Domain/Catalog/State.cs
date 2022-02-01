using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Domain.Catalog;

public class State : AuditableEntity, IAggregateRoot
{
    public State(string? name, Guid countryId, bool isActive)
    {
        Name = name;
        CountryId = countryId;
        IsActive = isActive;
    }

    public string? Name { get; private set; }
    public virtual Country Country { get; set; } = default!;
    public Guid CountryId { get; private set; }
    public bool IsActive { get; set; }

    public void Update(string name, Guid countryId, object isActive)
    {
        throw new NotImplementedException();
    }
}

