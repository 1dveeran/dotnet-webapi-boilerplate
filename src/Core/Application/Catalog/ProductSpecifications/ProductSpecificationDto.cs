using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Catalog.ProductSpecifications;

public class ProductSpecificationDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Value { get; set; }
    public Guid ProductId { get; set; }
    public bool IsActive { get; set; }
}
