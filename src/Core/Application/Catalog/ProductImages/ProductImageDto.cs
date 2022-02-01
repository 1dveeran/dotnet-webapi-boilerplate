using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Catalog.ProductImages;

public class ProductImageDto : IDto
{
    public Guid Id { get; set; }
    public string ImagePath { get; set; } = default!;
    public Guid ProductId { get; set; }
    public bool IsActive { get; set; }
}
