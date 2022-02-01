using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Domain.Catalog;

public class SellerImage : AuditableEntity, IAggregateRoot
{
    public SellerImage(string imagePath, Guid sellerId, bool isActive)
    {
        ImagePath = imagePath;
        SellerId = sellerId;
        IsActive = isActive;
    }

    public string? ImagePath { get; set; }
    public Guid SellerId { get; set; }
    public virtual Seller Seller { get; set; } = default!;
    public bool IsActive { get; set; }

    public void Update(string imagePath, Guid sellerId, bool isActive)
    {
        throw new NotImplementedException();
    }
}
