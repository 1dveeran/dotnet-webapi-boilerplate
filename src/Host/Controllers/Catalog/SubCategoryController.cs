using FSH.WebApi.Application.Catalog.SubCategorys;

namespace FSH.WebApi.Host.Controllers.Catalog;

public class SubCategoryController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHPermissions.SubCategory.Search)]
    [OpenApiOperation("Search products using available filters.", "")]
    public Task<PaginationResponse<SubCategoryDto>> SearchAsync(SearchSubCategorysRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHPermissions.SubCategory.View)]
    [OpenApiOperation("Get product details.", "")]
    public Task<SubCategoryDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetSubCategoryRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHPermissions.SubCategory.Create)]
    [OpenApiOperation("Create a new product.", "")]
    public Task<Guid> CreateAsync(CreateSubCategoryRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHPermissions.SubCategory.Update)]
    [OpenApiOperation("Update a product.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateSubCategoryRequest request, Guid id)
    {
        if (id != request.Id)
        {
            return BadRequest();
        }

        return Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHPermissions.SubCategory.Delete)]
    [OpenApiOperation("Delete a product.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteSubCategoryRequest(id));
    }
}