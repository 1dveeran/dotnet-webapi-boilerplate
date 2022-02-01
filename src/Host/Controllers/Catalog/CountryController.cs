using FSH.WebApi.Application.Catalog.Countrys;
using Microsoft.AspNetCore.Mvc;

namespace FSH.WebApi.Host.Controllers.Catalog;
public class CountryController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHPermissions.Country.Search)]
    [OpenApiOperation("Search Country using available Filters.", "")]
    public Task<PaginationResponse<CountryDto>> SearchAsync(SearchCountrysRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHPermissions.Country.View)]
    [OpenApiOperation("Get brand details.", "")]
    public Task<CountryDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetCountryRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHPermissions.Country.Create)]
    [OpenApiOperation("Create a new brand.", "")]
    public Task<Guid> CreateAsync(CreateCountryRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHPermissions.Country.Update)]
    [OpenApiOperation("Update a brand.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateCountryRequest request, Guid id)
    {
        if (id != request.Id)
        {
            return BadRequest();
        }

        return Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHPermissions.Country.Delete)]
    [OpenApiOperation("Delete a brand.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteCountryRequest(id));
    }
}
