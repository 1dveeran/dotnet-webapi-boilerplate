using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Domain.Catalog;

public class ProductReview : AuditableEntity, IAggregateRoot
{
    public ProductReview(Guid productId, string? username, string? comment, bool isActive)
    {
        ProductId = productId;
        Username = username;
        Comment = comment;
        IsActive = isActive;
    }

    public Guid ProductId { get; set; }
    public virtual Product Product { get; set; } = default!;
    public string? Username { get; set; }
    public string? Comment { get; set; }
    public bool IsActive { get; set; }

    public void Update(Guid productId, string? username, string? comment, bool isActive)
    {
        throw new NotImplementedException();
    }
}
