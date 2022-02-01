using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Catalog.ProductRatings;

public class ProductRatingDto : IDto
{
    public Guid Id { get; set; }
    public decimal Rating { get; set; }
    public Guid ProductId { get; set; }
    public bool IsActive { get; set; }
}
