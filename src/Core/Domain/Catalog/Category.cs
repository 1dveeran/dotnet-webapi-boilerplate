using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Domain.Catalog;

public class Category : AuditableEntity, IAggregateRoot
{
    public Category(string name, bool isActive)
    {
        Name = name;
        IsActive = isActive;
    }

    public string? Name { get; private set; }
    public bool IsActive { get; set; }

    public void Update(string name, bool isActive)
    {
        throw new NotImplementedException();
    }
}
