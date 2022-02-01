using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Domain.Catalog;

public class ProductRating : AuditableEntity, IAggregateRoot
{
    public ProductRating(decimal rating, Guid productId, bool isActive)
    {
        Rating = rating;
        ProductId = productId;
        IsActive = isActive;
    }

    public decimal Rating { get; set; }
    public Guid ProductId { get; set; }
    public virtual Product Product { get; set; } = default!;
    public bool IsActive { get; set; }

    public void Update(decimal rating, Guid productId, bool isActive)
    {
        throw new NotImplementedException();
    }
}

