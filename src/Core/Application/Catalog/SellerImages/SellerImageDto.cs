using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Catalog.SellerImages;

public class SellerImageDto : IDto
{
    public Guid Id { get; set; }
    public string ImagePath { get; set; } = default!;
    public Guid SellerId { get; set; }
    public bool IsActive { get; set; }
}
