using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Domain.Catalog;

public class Seller : AuditableEntity, IAggregateRoot
{
    public Seller(string shopName, string? gstNumber, string? address1, string? address2, Guid countryId, Guid stateId, Guid cityId, string? pin, string? latitude, string? longitude, bool isActive)
    {
        ShopName = shopName;
        GstNumber = gstNumber;
        Address1 = address1;
        Address2 = address2;
        CountryId = countryId;
        StateId = stateId;
        CityId = cityId;
        Pin = pin;
        Latitude = latitude;
        Longitude = longitude;
        IsActive = isActive;
    }

    public string? ShopName { get; private set; }
    public string? GstNumber { get; private set; }
    public string? Address1 { get; private set; }
    public string? Address2 { get; private set; }
    public Guid CountryId { get; set; }
    public virtual Country Country { get; set; } = default!;
    public Guid StateId { get; set; }
    public virtual State State { get; set; } = default!;
    public Guid CityId { get; set; }
    public virtual City City { get; set; } = default!;
    public string? Pin { get; private set; }
    public string? Latitude { get; private set; }
    public string? Longitude { get; private set; }
    public bool IsActive { get; set; }

    public void Update(string shopName, string? gstNumber, string? address1, string? address2, Guid countryId, Guid stateId, object cityId, string? pin, string? latitude, string? longitude, bool isActive)
    {
        throw new NotImplementedException();
    }
}
