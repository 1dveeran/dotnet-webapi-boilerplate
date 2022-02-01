using FSH.WebApi.Application.Catalog.Citys;
using Microsoft.AspNetCore.Mvc;

namespace FSH.WebApi.Host.Controllers.Catalog;
public class CityController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHPermissions.City.Search)]
    [OpenApiOperation("Search City using available Filters.", "")]
    public Task<PaginationResponse<CityDto>> SearchAsync(SearchCitysRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHPermissions.City.View)]
    [OpenApiOperation("Get brand details.", "")]
    public Task<CityDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetCityRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHPermissions.City.Create)]
    [OpenApiOperation("Create a new brand.", "")]
    public Task<Guid> CreateAsync(CreateCityRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHPermissions.City.Update)]
    [OpenApiOperation("Update a brand.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateCityRequest request, Guid id)
    {
        if (id != request.Id)
        {
            return BadRequest();
        }

        return Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHPermissions.City.Delete)]
    [OpenApiOperation("Delete a brand.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteCityRequest(id));
    }
}
