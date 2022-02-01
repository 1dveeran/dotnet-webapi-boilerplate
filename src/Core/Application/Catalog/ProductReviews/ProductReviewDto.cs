using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Catalog.ProductReviews;

public class ProductReviewDto : IDto
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public string? Username { get; set; }
    public string? Comment { get; set; }
    public bool IsActive { get; set; }
}
