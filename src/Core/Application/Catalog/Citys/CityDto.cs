namespace FSH.WebApi.Application.Catalog.Citys;

public class CityDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public Guid StateId { get;  set; }
    public Guid CountryId { get;  set; }
    public bool IsActive { get; set; }
}
