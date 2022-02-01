using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Catalog.Sellers;

public class SellerDto : IDto
{
    public Guid Id { get; set; }
    public string ShopName { get;  set; } = default!;
    public string? GstNumber { get;  set; }
    public string? Address1 { get;  set; }
    public string? Address2 { get;  set; }
    public Guid CountryId { get; set; }
    public Guid StateId { get; set; }
    public Guid CityId { get; set; }
    public string? Pin { get;  set; }
    public string? Latitude { get;  set; }
    public string? Longitude { get;  set; }
    public bool IsActive { get; set; }
}
