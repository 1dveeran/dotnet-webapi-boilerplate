using FSH.WebApi.Application.Catalog.Countrys;
using FSH.WebApi.Application.Catalog.States;

namespace FSH.WebApi.Application.Catalog.Citys;

public class CityDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public StateDto? State { get;  set; }
    public CountryDto? Country { get;  set; }
    public bool IsActive { get; set; }
}
