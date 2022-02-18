using FSH.WebApi.Application.Catalog.States;

namespace FSH.WebApi.Host.Controllers.Catalog;
public class StateController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.State)]
    [OpenApiOperation("Search products using available filters.", "")]
    public Task<PaginationResponse<StateDto>> SearchAsync(SearchStatesRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.State)]
    [OpenApiOperation("Get product details.", "")]
    public Task<StateDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetStateRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.State)]
    [OpenApiOperation("Create a new product.", "")]
    public Task<Guid> CreateAsync(CreateStateRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.State)]
    [OpenApiOperation("Update a product.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateStateRequest request, Guid id)
    {
        if (id != request.Id)
        {
            return BadRequest();
        }

        return Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.State)]
    [OpenApiOperation("Delete a product.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteStateRequest(id));
    }
}
