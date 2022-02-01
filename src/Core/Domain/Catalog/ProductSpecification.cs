using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Domain.Catalog;

public class ProductSpecification : AuditableEntity, IAggregateRoot
{
    public ProductSpecification(string name, string? value, Guid productId, bool isActive)
    {
        Name = name;
        Value = value;
        ProductId = productId;
        IsActive = isActive;
    }

    public string? Name { get; private set; }
    public string? Value { get; private set; }
    public Guid ProductId { get; set; }
    public virtual Product Product { get; set; } = default!;
    public bool IsActive { get; set; }

    public void Update(string name, string? value, Guid productId, bool isActive)
    {
        throw new NotImplementedException();
    }
}

