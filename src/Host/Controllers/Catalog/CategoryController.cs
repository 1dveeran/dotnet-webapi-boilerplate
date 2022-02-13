using FSH.WebApi.Application.Catalog.Categorys;

namespace FSH.WebApi.Host.Controllers.Catalog;

public class CategoryController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHPermissions.Category.Search)]
    [OpenApiOperation("Search products using available filters.", "")]
    public Task<PaginationResponse<CategoryDto>> SearchAsync(SearchCategoryRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHPermissions.Category.View)]
    [OpenApiOperation("Get product details.", "")]
    public Task<CategoryDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetCategoryRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHPermissions.Category.Create)]
    [OpenApiOperation("Create a new product.", "")]
    public Task<Guid> CreateAsync(CreateCategoryRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHPermissions.Category.Update)]
    [OpenApiOperation("Update a product.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateCategoryRequest request, Guid id)
    {
        if (id != request.Id)
        {
            return BadRequest();
        }

        return Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHPermissions.Category.Delete)]
    [OpenApiOperation("Delete a product.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteCategoryRequest(id));
    }
}