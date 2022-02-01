using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Domain.Catalog;
public class SubCategory : AuditableEntity, IAggregateRoot
{
    public SubCategory(string name, Guid categoryId, bool isActive)
    {
        Name = name;
        CategoryId = categoryId;
        IsActive = isActive;
    }

    public string? Name { get; private set; }
    public virtual Category Category { get; set; } = default!;
    public Guid CategoryId { get; private set; }
    public bool IsActive { get; set; }

    public void Update(string name, Guid categoryId, bool isActive)
    {
        throw new NotImplementedException();
    }
}
