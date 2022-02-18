using FSH.WebApi.Application.Catalog.SubCategorys;

namespace FSH.WebApi.Host.Controllers.Catalog;

public class SubCategoryController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.SubCategory)]
    [OpenApiOperation("Search products using available filters.", "")]
    public Task<PaginationResponse<SubCategoryDto>> SearchAsync(SearchSubCategorysRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.SubCategory)]
    [OpenApiOperation("Get product details.", "")]
    public Task<SubCategoryDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetSubCategoryRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.SubCategory)]
    [OpenApiOperation("Create a new product.", "")]
    public Task<Guid> CreateAsync(CreateSubCategoryRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.SubCategory)]
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
    [MustHavePermission(FSHAction.Delete, FSHResource.SubCategory)]
    [OpenApiOperation("Delete a product.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteSubCategoryRequest(id));
    }
}