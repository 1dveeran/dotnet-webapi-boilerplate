using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Domain.Catalog;

public class ProductImage : AuditableEntity, IAggregateRoot
{
    public ProductImage(string imagePath, Guid productId, bool isActive)
    {
        ImagePath = imagePath;
        ProductId = productId;
        IsActive = isActive;
    }

    public string? ImagePath { get; set; }
    public Guid ProductId { get; set; }
    public virtual Product Product { get; set; } = default!;
    public bool IsActive { get; set; }

    public void Update(string imagePath, Guid productId, bool isActive)
    {
        throw new NotImplementedException();
    }
}
